using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected bool HasEverMoved = false;
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            HasEverMoved = true;
        }

        public bool IsWithinBounds(Square square)
        {
            return square.Row >= 0 && square.Row < GameSettings.BoardSize &&
                   square.Col >= 0 && square.Col < GameSettings.BoardSize;
        }

        public IEnumerable<Square> GetAllDiagonalsInBounds(Square square)
        {
            HashSet<Square> diagonalSquares = new HashSet<Square>();

            for (int rowOffset = -1; rowOffset < 2; rowOffset+=2)
            {
                for (int colOffset = -1; colOffset < 2; colOffset+=2)
                {
                    for (int distance = 1; distance < GameSettings.BoardSize; distance++)
                    {
                        int newRow = square.Row + (rowOffset * distance);
                        int newCol = square.Col + (colOffset * distance);
                        
                        diagonalSquares.Add(new Square(newRow, newCol));
                    }
                }
            }

            return diagonalSquares.Where(IsWithinBounds).Where(diagSquare => diagSquare!=square);
        }

        public IEnumerable<Square> GetAllLateralsInBounds(Square square)
        {
            HashSet<Square> allLaterals = new HashSet<Square>();

            for (int distance = -GameSettings.BoardSize; distance < GameSettings.BoardSize; distance++)
            {
                allLaterals.Add(new Square(square.Row+distance, square.Col));
                
                allLaterals.Add(new Square(square.Row, square.Col+distance));
            }

            return allLaterals.Where(IsWithinBounds).Where(latSquare => latSquare!=square);
        }
    }
}