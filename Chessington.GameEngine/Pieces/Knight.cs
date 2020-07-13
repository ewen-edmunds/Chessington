using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        protected List<Tuple<int,int>> MoveOffsets = new List<Tuple<int,int>>()
        {
            new Tuple<int, int>(-1,-2), new Tuple<int, int>(-1,2),
            new Tuple<int, int>(1,-2), new Tuple<int, int>(1,2),
            new Tuple<int, int>(-2,-1), new Tuple<int, int>(-2,1),
            new Tuple<int, int>(2,-1), new Tuple<int, int>(2,1)
        };
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            foreach (Tuple<int,int> moveOffset in MoveOffsets)
            {
                availableMoves.Add(new Square(mySquare.Row+moveOffset.Item1, mySquare.Col+moveOffset.Item2));
            }
            
            return availableMoves.Where(IsWithinBounds);
        }
    }
}