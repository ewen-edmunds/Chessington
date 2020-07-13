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

            availableMoves.Add(new Square(mySquare.Row+moveDirection, mySquare.Col));
            
            if (!HasEverMoved)
            {
                availableMoves.Add(new Square(mySquare.Row+(2*moveDirection), mySquare.Col));
            }
            
            return availableMoves.Where(IsWithinBounds);
        }
    }
}