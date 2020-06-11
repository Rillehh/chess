using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pawn : Figure
    {
        public int Direction { get; }

        public Pawn(int _x, int _y, PlayerType pt, FigureType ft, Engine e) : base(_x, _y, pt, ft, e)
        {
            Direction = (pt == PlayerType.WHITE ? -1 : 1); // pravac u kome se pijun krecu u zavisnosti od boje
        }

        public override List<Tuple<int, int>> GetPossibleMoves(Figure[,] table)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            // Check one or two up
            if (engine.CheckBoundaries(x + Direction, y) && table[x + Direction, y] == null)
            {
                moves.Add(new Tuple<int, int>(x + Direction, y));
                if (IsFirstMove() && engine.CheckBoundaries(x + Direction * 2, y) && table[x + Direction * 2, y] == null)
                    moves.Add(new Tuple<int, int>(x + Direction * 2, y));
            }

            // Check for eating enemies cross
            if (engine.CheckBoundaries(x + Direction, y - 1) && table[x + Direction, y - 1] != null &&
                    table[x + Direction, y - 1].player != player)
                moves.Add(new Tuple<int, int>(x + Direction, y - 1));

            if (engine.CheckBoundaries(x + Direction, y + 1) && table[x + Direction, y + 1] != null &&
                    table[x + Direction, y + 1].player != player)
                moves.Add(new Tuple<int, int>(x + Direction, y + 1));

            // Check for enpassant
            if (engine.CheckBoundaries(x, y - 1) && table[x, y - 1] != null && engine.previousMove != null &&
                    engine.previousMove.Item1 != player && engine.previousMove.Item2 == FigureType.PAWN &&
                    engine.previousMove.Item3 == x + Direction * 2 && engine.previousMove.Item4 == y - 1 &&
                    engine.previousMove.Item5 == x && engine.previousMove.Item6 == y - 1)
                moves.Add(new Tuple<int, int>(x + Direction, y - 1));

            if (engine.CheckBoundaries(x, y + 1) && table[x, y + 1] != null && engine.previousMove != null &&
                    engine.previousMove.Item1 != player && engine.previousMove.Item2 == FigureType.PAWN &&
                    engine.previousMove.Item3 == x + Direction * 2 && engine.previousMove.Item4 == y + 1 &&
                    engine.previousMove.Item5 == x && engine.previousMove.Item6 == y + 1)
                moves.Add(new Tuple<int, int>(x + Direction, y + 1));

            return moves;
        }

        private bool IsFirstMove()
        {
            if (player == PlayerType.WHITE)
                return x == 6;
            else
                return x == 1;
        }
    }
}
