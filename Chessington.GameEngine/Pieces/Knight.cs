using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        protected static List<MoveOffset> MoveOffsets = new List<MoveOffset>()
        {
            new MoveOffset(-1,-2), new MoveOffset(-1,2),
            new MoveOffset(1,-2), new MoveOffset(1,2),
            new MoveOffset(-2,-1), new MoveOffset(-2,1),
            new MoveOffset(2,-1), new MoveOffset(2,1)
        };
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            foreach (MoveOffset moveOffset in MoveOffsets)
            {
                availableMoves.Add(mySquare+moveOffset);
            }
            
            return availableMoves.Where(board.IsWithinBounds).Where(square => !board.IsSameOnSquares(mySquare, square));
        }
    }
}