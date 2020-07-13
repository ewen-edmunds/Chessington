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
                if (BoardQuery.IsWithinBounds(mySquare + new MoveOffset(moveDirection, 0)) && board.GetPiece(mySquare + new MoveOffset(moveDirection, 0)) == null)
                {
                    availableMoves.Add(mySquare + new MoveOffset(moveDirection*2,0));
                }
            }

            availableMoves = availableMoves.Where(BoardQuery.IsWithinBounds).Where(square => board.GetPiece(square) == null).ToList();

            for (int colOffset =-1; colOffset < 2; colOffset+=2)
            {
                Square captureSquare = mySquare + new MoveOffset(moveDirection, colOffset);
                if (BoardQuery.IsWithinBounds(captureSquare) &&
                    BoardQuery.IsOppositeColourOnSquares(board, mySquare, captureSquare))
                {
                    availableMoves.Add(captureSquare);
                }
            }
            
            return availableMoves.Where(BoardQuery.IsWithinBounds);
        }
    }
}