using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King : Figure
    {
        public bool IsMoved { get; set; }

        public King(int _x, int _y, PlayerType pt, FigureType ft, Engine e, bool isMoved = false) : base(_x, _y, pt, ft, e)
        {
            IsMoved = isMoved;
        }

        public override List<Tuple<int, int>> GetPossibleMoves(Figure[, ] table)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            List<Tuple<int, int>> directions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(0, -1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, -1),
                new Tuple<int, int>(-1, 1),
                new Tuple<int, int>(-1, -1)
            };

            foreach (var dir in directions)
            {
                int xNew = x + dir.Item1;
                int yNew = y + dir.Item2;

                if (engine.CheckBoundaries(xNew, yNew) &&
                        (table[xNew, yNew] == null || table[xNew, yNew].player != player))
                    moves.Add(new Tuple<int, int>(xNew, yNew));
            }



            return moves;
        }

        public List<Tuple<int, int>> GetCastlingMoves()
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            // Mala i velika rokada
            if (!IsMoved)
            {
                // Mala rokada
                if (engine.CheckBoundaries(x, y + 1) && engine.figureTable[x, y + 1] == null &&
                        engine.CheckBoundaries(x, y + 2) && engine.figureTable[x, y + 2] == null &&
                        engine.CheckBoundaries(x, y + 3) && engine.figureTable[x, y + 3] is Rook && !((Rook)engine.figureTable[x, y + 3]).IsMoved &&
                        !engine.IsFieldUnderAttack(x, y, engine.GetOpponent(player), engine.figureTable) &&
                        !engine.IsFieldUnderAttack(x, y + 1, engine.GetOpponent(player), engine.figureTable) &&
                        !engine.IsFieldUnderAttack(x, y + 2, engine.GetOpponent(player), engine.figureTable) &&
                        !engine.IsFieldUnderAttack(x, y + 3, engine.GetOpponent(player), engine.figureTable))
                    moves.Add(new Tuple<int, int>(x, y + 2));

                //Velika rokada
                if (engine.CheckBoundaries(x, y - 1) && engine.figureTable[x, y - 1] == null &&
                        engine.CheckBoundaries(x, y - 2) && engine.figureTable[x, y - 2] == null &&
                        engine.CheckBoundaries(x, y - 3) && engine.figureTable[x, y - 3] == null &&
                        engine.CheckBoundaries(x, y - 4) && engine.figureTable[x, y - 4] is Rook && !((Rook)engine.figureTable[x, y - 4]).IsMoved &&
                        !engine.IsFieldUnderAttack(x, y, engine.GetOpponent(player), engine.figureTable) &&
                        !engine.IsFieldUnderAttack(x, y - 1, engine.GetOpponent(player), engine.figureTable) &&
                        !engine.IsFieldUnderAttack(x, y - 2, engine.GetOpponent(player), engine.figureTable) &&
                        !engine.IsFieldUnderAttack(x, y - 4, engine.GetOpponent(player), engine.figureTable))
                    moves.Add(new Tuple<int, int>(x, y - 2));
            }

            return moves;
        }

        public override void Move(int xNew, int yNew)
        {
            base.Move(xNew, yNew);
            IsMoved = true;
        }
    }
}
