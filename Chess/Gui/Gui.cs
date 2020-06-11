using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Gui : Form
    {
        Field[,] fields;
        Engine engine;

        string whitePlayerName;
        string blackPlayerName;

        bool isClickedOnce;
        Tuple<int, int> firstField;

        public Gui()
        {
            engine = new Engine();
            fields = new Field[8, 8];
            isClickedOnce = false;
            firstField = null;

            InitializeComponent();
        }

        private void Gui_Load(object sender, EventArgs e)
        {
            new StartDialog().ShowDialog();

            if (StartDialog.whitePlayerName == null && StartDialog.blackPlayerName == null)
            {
                Close();
            }
            else
            {
                whitePlayerName = StartDialog.whitePlayerName;
                blackPlayerName = StartDialog.blackPlayerName;

                whitePlayerName = char.ToUpper(whitePlayerName[0]) + whitePlayerName.Substring(1).ToLower();
                blackPlayerName = char.ToUpper(blackPlayerName[0]) + blackPlayerName.Substring(1).ToLower();

                InitGuiElements();
            }

        }

        private void InitGuiElements()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Field myField = new Field(i, j, Util.GetBaseBackColor(i, j),
                        Util.GetFigureImage(engine.figureTable[i, j]));
                    myField.Click += MyField_Click;

                    fields[i, j] = myField;
                    flowLayoutPanel1.Controls.Add(fields[i, j]);
                }

            white_Name.Text = whitePlayerName;
            black_Name.Text = blackPlayerName;
            onMove_Label.Text = "On move: " + whitePlayerName;
            check_Label.Text = "";
        }

        private void RefreshGui()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    fields[i, j].Image = Util.GetFigureImage(engine.figureTable[i, j]);
                    fields[i, j].BackColor = fields[i, j].BaseBackColor;
                }

            onMove_Label.Text = "On move: " + (engine.onMove == PlayerType.WHITE ? whitePlayerName : blackPlayerName);
            check_Label.Text = "";

            Refresh();                                 
        }

        private void RefreshSelectedFields(int x, int y, List<Tuple<int, int>> possibleMoves)
        {
            fields[x, y].BackColor = Util.GetSelectedFieldColor(x, y);

            foreach (var move in possibleMoves)
                fields[move.Item1, move.Item2].BackColor = Util.GetPossibleMovesFieldColor(move.Item1, move.Item2);         

            Refresh();
        }

        private void MyField_Click(object sender, EventArgs e)
        {
            Field field = sender as Field;

            if (!isClickedOnce)
            {
                if (engine.IsSelectedFieldValid(field.PosX, field.PosY, out string message))
                {

                    List<Tuple<int, int>> possibleMoves = engine.GetPossibleMoves(field.PosX, field.PosY);
                    RefreshSelectedFields(field.PosX, field.PosY, possibleMoves);

                    isClickedOnce = true;
                    firstField = new Tuple<int, int>(field.PosX, field.PosY);
                }
                else
                {
                    MessageBox.Show(string.Format(message, GetPlayerName(engine.onMove)), 
                            "Bad move", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                engine.Move(firstField.Item1, firstField.Item2, field.PosX, field.PosY);
                RefreshGui();

                isClickedOnce = false;
                firstField = null;

                if (engine.IsCheck())
                {
                    check_Label.Text = "Check!";
                }

                if (engine.IsCheckMate(out PlayerType? winner))
                {
                    check_Label.Text = "Checkmate!!!";

                    string text = "Checkmate! Winner is " + GetPlayerName(winner.Value) + ".";
                    new EndGame(text).ShowDialog();

                    if (EndGame.Status < 0)
                    {
                        Close();
                    }
                    else if (EndGame.Status > 0)
                    {
                        engine.Initialize();
                        RefreshGui();
                    }
                }

                if (engine.IsStaleMate())
                {
                    check_Label.Text = "Stalemate!!!";

                    string text = "Stalemate! There is no winner.";
                    new EndGame(text).ShowDialog();

                    if (EndGame.Status < 0)
                    {
                        Close();
                    }
                    else if (EndGame.Status > 0)
                    {
                        engine.Initialize();
                        RefreshGui();
                    }
                }
            }
            
        }

        private string GetPlayerName(PlayerType player)
        {
            if (player == PlayerType.WHITE)
                return whitePlayerName;

            return blackPlayerName;
        }

        private void newGame_Button_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want new game?",
                    "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                engine.Initialize();
                RefreshGui();
            }
        }

        private void draw_Button_Click(object sender, EventArgs e)
        {
            string text = "Draw! There is no winner.";
            new EndGame(text).ShowDialog();

            if (EndGame.Status < 0)
            {
                Close();
            }
            else if (EndGame.Status > 0)
            {
                engine.Initialize();
                RefreshGui();
            }
        }

        private void resign_Button_Click(object sender, EventArgs e)
        {
            string text = string.Format("{0} resign! Winner is {1}",
                    GetPlayerName(engine.onMove),
                    GetPlayerName(engine.GetOpponent(engine.onMove)));
            new EndGame(text).ShowDialog();

            if (EndGame.Status < 0)
            {
                Close();
            }
            else if (EndGame.Status > 0)
            {
                engine.Initialize();
                RefreshGui();
            }
        }

        private void Gui_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
