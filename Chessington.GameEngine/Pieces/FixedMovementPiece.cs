using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class FixedMovementPiece : Piece
    {
        protected List<MoveOffset> MoveOffsets;
        public FixedMovementPiece(Player player) : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            foreach (MoveOffset moveOffset in MoveOffsets)
            {
                availableMoves.Add(mySquare+moveOffset);
            }
            
            return availableMoves.Where(board.IsWithinBounds).Where(square => !board.IsSameColourOnSquares(mySquare, square));
        }
    }
}