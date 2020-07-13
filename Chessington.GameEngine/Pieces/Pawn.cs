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
            List<Square> availableMoves = new List<Square>();
            
            int moveDirection = 1;
            if (Player == Player.White)
            {
                moveDirection = -1;
            }

            availableMoves.Add(mySquare + new MoveOffset(moveDirection,0));
            
            if (!HasEverMoved)
            {
                if (board.GetPiece(mySquare + new MoveOffset(moveDirection, 0)) == null)
                {
                    availableMoves.Add(mySquare + new MoveOffset(moveDirection*2,0));
                }
            }
            
            return availableMoves.Where(IsWithinBounds).Where(square => board.GetPiece(square) == null);
        }
    }
}