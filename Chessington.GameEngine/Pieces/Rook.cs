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
            
            foreach (MoveOffset moveOffset in MoveOffset.GetAllLateralOffsets())
            {
                availableMoves.Add(mySquare+moveOffset);
            }
            
            return availableMoves.Where(IsWithinBounds);
        }
    }
}