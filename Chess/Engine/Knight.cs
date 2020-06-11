using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Knight : Figure
    {
        public Knight(int _x, int _y, PlayerType pt, FigureType ft, Engine e) : base(_x, _y, pt, ft, e)
        {
        }

        public override List<Tuple<int, int>> GetPossibleMoves(Figure[,] table)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            List<Tuple<int, int>> directions = new List<Tuple<int, int>> 
            {
                new Tuple<int, int>(-2, -1),
                new Tuple<int, int>(-2, 1),
                new Tuple<int, int>(-1, -2),
                new Tuple<int, int>(-1, 2),
                new Tuple<int, int>(2, -1),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, -2),
                new Tuple<int, int>(1, 2)
            };

            foreach (var dir in directions)
            {
                int xNew = x + dir.Item1;
                int yNew = y + dir.Item2;

                if (engine.CheckBoundaries(xNew, yNew) && (table[xNew, yNew] == null || table[xNew, yNew].player != player))
                    moves.Add(new Tuple<int, int>(xNew, yNew));
            }

            return moves;
        }
    }
}
