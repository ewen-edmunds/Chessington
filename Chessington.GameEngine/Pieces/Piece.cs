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

        public static IEnumerable<MoveOffset> GetAllDiagonalOffsets()
        {
            HashSet<MoveOffset> diagonalOffsets = new HashSet<MoveOffset>();

            for (int rowOffset = -1; rowOffset < 2; rowOffset+=2)
            {
                for (int colOffset = -1; colOffset < 2; colOffset+=2)
                {
                    for (int distance = 1; distance < GameSettings.BoardSize; distance++)
                    {
                        diagonalOffsets.Add(new MoveOffset(rowOffset * distance, colOffset * distance));
                    }
                }
            }
            
            return diagonalOffsets;
        }

        public static IEnumerable<MoveOffset> GetAllLateralOffsets()
        {
            HashSet<MoveOffset> lateralOffsets = new HashSet<MoveOffset>();

            for (int distance = 1; distance < GameSettings.BoardSize; distance++)
            {
                for (int rowDirection = -1; rowDirection < 2; rowDirection += 2)
                {
                    lateralOffsets.Add(new MoveOffset(rowDirection * distance, 0));
                }
                for (int colDirection = -1; colDirection < 2; colDirection += 2)
                {
                    lateralOffsets.Add(new MoveOffset(0, colDirection * distance));
                }
            }

            return lateralOffsets;
        }
    }
}