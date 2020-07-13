using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            for (int rowOffset = -1; rowOffset < 2; rowOffset+=2)
            {
                for (int colOffset = -1; colOffset < 2; colOffset+=2)
                {
                    for (int distance = 1; distance < GameSettings.BoardSize; distance++)
                    {
                        int newRow = mySquare.Row + (rowOffset * distance);
                        int newCol = mySquare.Col + (colOffset * distance);
                        
                        if (newRow >= 0 && newRow < GameSettings.BoardSize && newCol >= 0 && newCol < GameSettings.BoardSize)
                        {
                            availableMoves.Add(new Square(newRow, newCol));
                        }
                    }
                    
                }
            }

            Console.WriteLine($"Available moves: {availableMoves.Count}");
            
            return availableMoves;
        }
    }
}