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
            
            int attemptedRowToMoveTo = mySquare.Row+moveDirection;
            
            if (attemptedRowToMoveTo >= 0 && attemptedRowToMoveTo < GameSettings.BoardSize)
            {
                availableMoves.Add(new Square(attemptedRowToMoveTo, mySquare.Col));
            }

            if (!HasEverMoved)
            {
                attemptedRowToMoveTo = mySquare.Row+(2*moveDirection);
            
                if (attemptedRowToMoveTo >= 0 && attemptedRowToMoveTo < GameSettings.BoardSize)
                {
                    availableMoves.Add(new Square(attemptedRowToMoveTo, mySquare.Col));
                }
            }
            
            return availableMoves;
        }
    }
}