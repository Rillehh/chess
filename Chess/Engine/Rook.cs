using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Rook : Figure
    {
        public bool IsMoved { get; set; }

        public Rook(int _x, int _y, PlayerType pt, FigureType ft, Engine e, bool isMoved = false) : base(_x, _y, pt, ft, e)
        {
            IsMoved = isMoved;
        }

        public override List<Tuple<int, int>> GetPossibleMoves(Figure[,] table)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            List<Tuple<int, int>> directions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 0), //vektor (pomeranje za 1 na dole)
                new Tuple<int, int>(0, 1), // desno
                new Tuple<int, int>(-1, 0),//gore
                new Tuple<int, int>(0, -1)//levo
            };

            foreach (var dir in directions) //menja koordinate na tabli
            {
                int xNew = x + dir.Item1;
                int yNew = y + dir.Item2;

                while (engine.CheckBoundaries(xNew, yNew) && table[xNew, yNew] == null) //proverava granice i da li je slobodno polje
                {
                   moves.Add(new Tuple<int, int>(xNew, yNew)); //ako jeste dodaje trenutnu poziciju u listu mogucih poteza
                    xNew += dir.Item1;
                    yNew += dir.Item2;
                }

                if (engine.CheckBoundaries(xNew, yNew) && table[xNew, yNew].player != player) //ako nije slobodno proverava da li je protivnicka figura
                    moves.Add(new Tuple<int, int>(xNew, yNew)); //dodaje u trenutnu poziciji u listu mogucih poteza
            }

            return moves;
        }

        public override void Move(int xNew, int yNew) //ovveride move iz klase figura zato sto smo dodali property koji pamti da li smo se pomerili ili ne (zbog rokade)
        {
            base.Move(xNew, yNew);
            IsMoved = true;
        }
    }
}
