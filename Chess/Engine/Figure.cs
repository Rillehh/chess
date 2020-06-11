using System;
using System.Collections.Generic;

namespace Chess
{
    public enum PlayerType
    {
        WHITE,
        BLACK
    }

    public enum FigureType
    {
        PAWN,
        KNIGHT,
        BISHOP,
        ROOK,
        QUEEN,
        KING
    }

    public abstract class Figure
    {
        public readonly PlayerType player;
        public readonly FigureType type;
        public int x;
        public int y;

        protected Engine engine;

        public Figure(int _x, int _y, PlayerType pt, FigureType ft, Engine e)
        {
            x = _x;
            y = _y;
            player = pt;
            type = ft;

            engine = e;
        }

        public virtual void Move(int xNew, int yNew)
        {
            x = xNew;
            y = yNew;
        }

        public abstract List<Tuple<int, int>> GetPossibleMoves(Figure[, ] table);


    }
}