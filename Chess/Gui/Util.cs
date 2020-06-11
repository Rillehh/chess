using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    static class Util
    {
        public static Color GetBaseBackColor(int x, int y)
        {
            if ((x + y) % 2 == 0)
                return Color.FromArgb(238, 238, 210);
            else
                return Color.FromArgb(118, 150, 86);
        }

        public static Color GetPossibleMovesFieldColor(int x, int y)
        {
            if ((x + y) % 2 == 0)
                return Color.FromArgb(246, 246, 130);
            else
                return Color.FromArgb(186, 202, 68);
        }

        public static Color GetSelectedFieldColor(int x, int y)
        {
            if ((x + y) % 2 == 0)
                return Color.FromArgb(255, 228, 112);
            else
                return Color.FromArgb(195, 184, 50);
        }

        public static Image GetFigureImage(Figure figure)
        {
            if (figure == null)
                return null;

            return GetFigureImage(figure.player, figure.type);
        }

        public static Image GetFigureImage(PlayerType player, FigureType figure)
        {
            switch (player)
            {
                case PlayerType.WHITE:
                    switch (figure)
                    {
                        case FigureType.PAWN:
                            return Properties.Resources.wp;
                        case FigureType.KNIGHT:
                            return Properties.Resources.wn;
                        case FigureType.BISHOP:
                            return Properties.Resources.wb;
                        case FigureType.ROOK:
                            return Properties.Resources.wr;
                        case FigureType.QUEEN:
                            return Properties.Resources.wq;
                        case FigureType.KING:
                            return Properties.Resources.wk;
                        default:
                            return null;
                    };
                case PlayerType.BLACK:
                    switch (figure)
                    {
                        case FigureType.PAWN:
                            return Properties.Resources.bp;
                        case FigureType.KNIGHT:
                            return Properties.Resources.bn;
                        case FigureType.BISHOP:
                            return Properties.Resources.bb;
                        case FigureType.ROOK:
                            return Properties.Resources.br;
                        case FigureType.QUEEN:
                            return Properties.Resources.bq;
                        case FigureType.KING:
                            return Properties.Resources.bk;
                        default:
                            return null;
                    };
                default:
                    return null;
            }
        }
    }
}
