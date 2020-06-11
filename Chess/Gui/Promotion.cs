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
    public partial class Promotion : Form
    {
        public static FigureType promotedFigure;

        PlayerType player;
    
        public Promotion()
        {
            InitializeComponent();
        }

        public Promotion(PlayerType p) : this()
        {
            player = p;
        }

        private void Promotion_Load(object sender, EventArgs e)
        {
            queen_PictureBox.Image = Util.GetFigureImage(player, FigureType.QUEEN);
            rook_PictureBox.Image = Util.GetFigureImage(player, FigureType.ROOK);
            bishop_PictureBox.Image = Util.GetFigureImage(player, FigureType.BISHOP);
            knight_PictureBox.Image = Util.GetFigureImage(player, FigureType.KNIGHT);

            queen_PictureBox.Click += PictureBox_Click;
            rook_PictureBox.Click += PictureBox_Click;
            bishop_PictureBox.Click += PictureBox_Click;
            knight_PictureBox.Click += PictureBox_Click;
            
            Refresh();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                string type = pictureBox.Name.Split('_')[0].ToUpper();
                promotedFigure = (FigureType)Enum.Parse(typeof(FigureType), type);

                Close();
            }
        }
    }
}
