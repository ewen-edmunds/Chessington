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

            for (int i = -GameSettings.BoardSize; i < GameSettings.BoardSize; i++)
            {
                if (mySquare.Row + i >= 0 && mySquare.Row + i < GameSettings.BoardSize)
                {
                    availableMoves.Add(new Square(mySquare.Row+i, mySquare.Col));
                }
                if (mySquare.Col + i >= 0 && mySquare.Col + i < GameSettings.BoardSize)
                {
                    availableMoves.Add(new Square(mySquare.Row, mySquare.Col+i));
                }
            }

            return availableMoves;
        }
    }
}