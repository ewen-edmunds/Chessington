using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            foreach (MoveOffset moveOffset in GetAllDiagonalOffsets())
            {
                availableMoves.Add(mySquare+moveOffset);
            }
            foreach (MoveOffset moveOffset in GetAllLateralOffsets())
            {
                availableMoves.Add(mySquare+moveOffset);
            }
            
            return availableMoves.Where(IsWithinBounds);
        }
    }
}