using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        protected static List<MoveOffset> MoveOffsets = new List<MoveOffset>()
        {
            new MoveOffset(-1,-1), new MoveOffset(-1,1),
            new MoveOffset(1,-1), new MoveOffset(1,1)
        };
        public Bishop(Player player)
            : base(player) { }

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