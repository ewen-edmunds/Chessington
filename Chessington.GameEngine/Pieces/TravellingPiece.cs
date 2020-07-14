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
                availableMoves.AddRange(GetValidMovesInDirection(board, mySquare, moveOffset));
            }

            return availableMoves.Where(BoardQuery.IsWithinBounds);
        }
        
        public static IEnumerable<Square> GetValidMovesInDirection(Board board, Square startingSquare, MoveOffset direction)
        {
            List<Square> validMoves = new List<Square>();
            int distance = 1;

            while (BoardQuery.IsWithinBounds(startingSquare + (direction * distance)) && board.GetPiece(startingSquare + (direction * distance)) == null)
            {
                validMoves.Add(startingSquare + (direction * distance));
                distance += 1;
            }

            if (BoardQuery.IsWithinBounds(startingSquare + (direction * distance)) &&
                !BoardQuery.IsSameColourOnSquares(board, startingSquare + (direction * distance), startingSquare))
            {
                validMoves.Add(startingSquare + (direction * distance));
            }

            return validMoves;
        }
    }
}