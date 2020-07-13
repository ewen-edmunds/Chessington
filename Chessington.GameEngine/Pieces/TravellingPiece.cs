using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class TravellingPiece : Piece
    {
        protected List<MoveOffset> MoveOffsets;
        public TravellingPiece(Player player) : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            foreach (MoveOffset moveOffset in MoveOffsets)
            {
                availableMoves.AddRange(board.GetValidMovesInDirection(mySquare, moveOffset));
            }

            return availableMoves.Where(board.IsWithinBounds);
        }
    }
}