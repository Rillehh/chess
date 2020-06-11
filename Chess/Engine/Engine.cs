using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Engine
    {
        public Figure[,] figureTable, tempTable;
        public PlayerType onMove;
        public Tuple<PlayerType, FigureType, int, int, int, int> previousMove;

        public Engine()
        {
            figureTable = new Figure[8, 8]; //tabla koju vidimo 
            tempTable = new Figure[8, 8]; //tabla koja sluzi za prveravanje validnosti poteza
            Initialize();
        }

        public void Initialize()
        {
            onMove = PlayerType.WHITE;
            previousMove = null;

            EmptyTable();
            SetInitPositions();

        }

        private void EmptyTable()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    figureTable[i, j] = null;
        }

        private void SetInitPositions()
        {
            // pijun
            for (int j = 0; j < 8; j++)
            {
                figureTable[1, j] = new Pawn(1, j, PlayerType.BLACK, FigureType.PAWN, this);
                figureTable[6, j] = new Pawn(6, j, PlayerType.WHITE, FigureType.PAWN, this);
            }

            // Add Rooks
            figureTable[0, 0] = new Rook(0, 0, PlayerType.BLACK, FigureType.ROOK, this);
            figureTable[0, 7] = new Rook(0, 7, PlayerType.BLACK, FigureType.ROOK, this);
            figureTable[7, 0] = new Rook(7, 0, PlayerType.WHITE, FigureType.ROOK, this);
            figureTable[7, 7] = new Rook(7, 7, PlayerType.WHITE, FigureType.ROOK, this);

            // Add Knights
            figureTable[0, 1] = new Knight(0, 1, PlayerType.BLACK, FigureType.KNIGHT, this);
            figureTable[0, 6] = new Knight(0, 6, PlayerType.BLACK, FigureType.KNIGHT, this);
            figureTable[7, 1] = new Knight(7, 1, PlayerType.WHITE, FigureType.KNIGHT, this);
            figureTable[7, 6] = new Knight(7, 6, PlayerType.WHITE, FigureType.KNIGHT, this);

            // Add Bishops
            figureTable[0, 2] = new Bishop(0, 2, PlayerType.BLACK, FigureType.BISHOP, this);
            figureTable[0, 5] = new Bishop(0, 5, PlayerType.BLACK, FigureType.BISHOP, this);
            figureTable[7, 2] = new Bishop(7, 2, PlayerType.WHITE, FigureType.BISHOP, this);
            figureTable[7, 5] = new Bishop(7, 5, PlayerType.WHITE, FigureType.BISHOP, this);

            // Add Kings and Queens
            figureTable[0, 3] = new Queen(0, 3, PlayerType.BLACK, FigureType.QUEEN, this);
            figureTable[7, 3] = new Queen(7, 3, PlayerType.WHITE, FigureType.QUEEN, this);
            figureTable[0, 4] = new King(0, 4, PlayerType.BLACK, FigureType.KING, this);
            figureTable[7, 4] = new King(7, 4, PlayerType.WHITE, FigureType.KING, this);
        }

        private void CopyTable() //kopiranje glavne table u privremenu 
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (figureTable[i, j] == null)
                        tempTable[i, j] = null;
                    else
                    {
                        if (figureTable[i, j] is King)
                            tempTable[i, j] = new King(i, j, figureTable[i, j].player, figureTable[i, j].type, this,
                                    ((King)figureTable[i, j]).IsMoved);
                        else if (figureTable[i, j] is Rook)
                            tempTable[i, j] = new Rook(i, j, figureTable[i, j].player, figureTable[i, j].type, this,
                                    ((Rook)figureTable[i, j]).IsMoved);
                        else if (figureTable[i, j] is Queen)
                            tempTable[i, j] = new Queen(i, j, figureTable[i, j].player, figureTable[i, j].type, this);
                        else if (figureTable[i, j] is Knight)
                            tempTable[i, j] = new Knight(i, j, figureTable[i, j].player, figureTable[i, j].type, this);
                        else if (figureTable[i, j] is Bishop)
                            tempTable[i, j] = new Bishop(i, j, figureTable[i, j].player, figureTable[i, j].type, this);
                        else if (figureTable[i, j] is Pawn)
                            tempTable[i, j] = new Pawn(i, j, figureTable[i, j].player, figureTable[i, j].type, this);
                    }
                }
        }

        public bool CheckBoundaries(int x, int y)
        {
            if (0 <= x && x < 8 && 0 <= y && y < 8)
                return true;
            return false;
        }
        
        public bool IsSelectedFieldValid(int x, int y, out string message)
        {
            if (!CheckBoundaries(x, y))
            {
                message = "Index out of matrix range!";
                return false;
            }

            if (figureTable[x, y] == null)
            {
                message = "{0}, you must click on figure!";
                return false;
            }

            if (figureTable[x, y].player != onMove)
            {
                message = "{0}'s on the move!";
                return false;
            }

            message = null;
            return true;
        }

        public PlayerType GetOpponent(PlayerType player)
        {
            if (player == PlayerType.WHITE)
                return PlayerType.BLACK;
            return PlayerType.WHITE;
        }

        public List<Tuple<int, int>> GetPossibleMoves(int x, int y)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            if (IsSelectedFieldValid(x, y, out string message))
            {
                List<Tuple<int, int>> possibleMoves = figureTable[x, y].GetPossibleMoves(figureTable);
                
                foreach (Tuple<int, int> move in possibleMoves)
                {
                    int xNew = move.Item1;
                    int yNew = move.Item2;

                    CopyTable();
                    MoveFigure(x, y, xNew, yNew, tempTable);

                    if (!IsCheck(tempTable))
                        moves.Add(move);
                }

                if (figureTable[x, y] is King)
                    moves.AddRange(((King)figureTable[x, y]).GetCastlingMoves());
            }

            return moves;
        }

        private King FindKing(PlayerType player, Figure[, ] table)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (table[i, j] != null && table[i, j] is King && table[i, j].player == player)
                        return table[i, j] as King;

            return null;
        }

        private List<Figure> FindPlayers(PlayerType player, Figure[, ] table)
        {
            List<Figure> figures = new List<Figure>();

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (table[i, j] != null && table[i, j].player == player)
                        figures.Add(table[i, j]);

            return figures;
        }

        private void MoveFigure(int x, int y, int xNew, int yNew, Figure[,] table = null)
        {
            if (table == null)
                table = figureTable;
            else
                table = tempTable;

            Figure oldFigure = table[x, y];
            oldFigure.Move(xNew, yNew);

            if (table == figureTable)
                previousMove = new Tuple<PlayerType, FigureType, int, int, int, int>(onMove, oldFigure.type, x, y, xNew, yNew);

            if (table[x, y] != null && table[x, y] is Pawn)
            {
                Pawn pawn = table[x, y] as Pawn;

                // Check if en passant
                if (xNew == x + pawn.Direction && (yNew == y - 1 || yNew == y + 1) && table[xNew, yNew] == null)
                    table[x, yNew] = null;

                table[xNew, yNew] = oldFigure;
                table[x, y] = null;

                // Check for promotion (Upgrade this code!!!) - only in real move mode
                if (table == figureTable && (xNew == 0 || xNew == 7))
                {
                    new Promotion(onMove).ShowDialog();
                    FigureType promotionFigure = Promotion.promotedFigure;

                    switch (promotionFigure)
                    {
                        case FigureType.KNIGHT:
                            table[xNew, yNew] = new Knight(xNew, yNew, onMove, promotionFigure, this);
                            break;
                        case FigureType.BISHOP:
                            table[xNew, yNew] = new Bishop(xNew, yNew, onMove, promotionFigure, this);
                            break;
                        case FigureType.ROOK:
                            table[xNew, yNew] = new Rook(xNew, yNew, onMove, promotionFigure, this);
                            break;
                        case FigureType.QUEEN:
                            table[xNew, yNew] = new Queen(xNew, yNew, onMove, promotionFigure, this);
                            break;
                        default:
                            break;
                    }
                }
            }
            // Rokada (Castling)
            else if (table == figureTable && table[x, y] != null && table[x, y] is King && Math.Abs(yNew - y) == 2)
            {
                // Move king
                table[xNew, yNew] = oldFigure;
                table[x, y] = null;

                // Small - move rook
                if (yNew > y)
                {
                    table[x, yNew + 1].Move(x, yNew - 1);

                    table[x, yNew - 1] = table[x, yNew + 1];
                    table[x, yNew + 1] = null;
                }
                // Big - move rook
                else
                {
                    table[x, yNew - 2].Move(x, yNew + 1);

                    table[x, yNew + 1] = table[x, yNew - 2];
                    table[x, yNew - 2] = null;
                }               
            }
            else
            {
                table[xNew, yNew] = oldFigure;
                table[x, y] = null;
            }
        }

        public bool Move(int x, int y, int xNew, int yNew)
        {
            if (IsSelectedFieldValid(x, y, out string message))
            {
                List<Tuple<int, int>> possibleMoves = GetPossibleMoves(x, y);
                foreach (var move in possibleMoves)
                {
                    if (move.Item1 == xNew && move.Item2 == yNew)
                    {
                        MoveFigure(x, y, xNew, yNew);                        
                        onMove = GetOpponent(onMove);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsFieldUnderAttack(int x, int y, PlayerType attacker, Figure[, ] table)
        {
            List<Figure> opponentFigures = FindPlayers(attacker, table);

            foreach (Figure oppFig in opponentFigures)
            {
                var possibleMoves = oppFig.GetPossibleMoves(table);
                foreach (var move in possibleMoves)
                    if (move.Item1 == x && move.Item2 == y)
                        return true;
            }

            return false;
        }

        public bool IsCheck(Figure[, ] table = null)
        {
            if (table == null)
                table = figureTable;
            else
                table = tempTable;

            King king = FindKing(onMove, table);
            return IsFieldUnderAttack(king.x, king.y, GetOpponent(onMove), table);
        }

        public bool IsCheckMate(out PlayerType? winner)
        {
            winner = null;

            if (IsCheck())
            {
                List<Figure> players = FindPlayers(onMove, figureTable);

                foreach (var player in players)
                {
                    List<Tuple<int, int>> possibleMoves = GetPossibleMoves(player.x, player.y);
                    if (possibleMoves.Count > 0)
                        return false;
                }

                winner = GetOpponent(onMove);
                return true;
            }
            
            return false;
        }

        public bool IsStaleMate() //nereseno (pat)
        {
            if (!IsCheck())
            {
                int totalMoves = 0;
                List<Figure> players = FindPlayers(onMove, figureTable);

                foreach (var player in players)
                    totalMoves += GetPossibleMoves(player.x, player.y).Count;

                if (totalMoves == 0)
                    return true;
            }

            return false;
        }
    }
}
