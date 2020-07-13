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
    }
}