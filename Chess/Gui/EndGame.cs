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
    public partial class EndGame : Form
    {
        public static int Status { get; set; }

        public EndGame()
        {
            InitializeComponent();
        }

        public EndGame(string text) : this()
        {
            Status = 0;
            main_Label.Text = text;
        }

        private void newGame_Button_Click(object sender, EventArgs e)
        {
            Status = 1;
            Close();
        }

        private void exit_Button_Click(object sender, EventArgs e)
        {
            Status = -1;
            Close();
        }
    }
}
