using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Field : PictureBox
    {
        public int PosX { get; }
        public int PosY { get; }
        public Color BaseBackColor { get; }

        public Field(int posX, int posY, Color bc, Image img)
        {
            PosX = posX;
            PosY = posY;
            BaseBackColor = bc;

            BackColor = bc;
            Image = img;

            Size = new Size(80, 80);
            Margin = new Padding(0);
        }
    }
}
