using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            for (int distance = -GameSettings.BoardSize; distance < GameSettings.BoardSize; distance++)
            {
                availableMoves.Add(new Square(mySquare.Row+distance, mySquare.Col));
                
                availableMoves.Add(new Square(mySquare.Row, mySquare.Col+distance));
            }
            return availableMoves.Where(IsWithinBounds);
        }
    }
}