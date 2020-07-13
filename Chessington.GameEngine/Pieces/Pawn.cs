using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square mySquare = board.FindPiece(this);
            int rowToMoveTo = mySquare.Row;
            
            if (Player == Player.White)
            {
                rowToMoveTo -= 1;
            }
            else
            {
                rowToMoveTo += 1;
            }

            if (rowToMoveTo < 0 || rowToMoveTo > GameSettings.BoardSize)
            {
                return Enumerable.Empty<Square>();
            }
            
            Square sq = new Square(rowToMoveTo, mySquare.Col);
            return new List<Square>{sq};
            
        }
    }
}