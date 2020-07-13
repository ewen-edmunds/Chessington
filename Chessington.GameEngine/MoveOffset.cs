using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class MoveOffset
    {
        public int RowOffset;
        public int ColOffset;

        public MoveOffset(int rowOffset, int colOffset)
        {
            RowOffset = rowOffset;
            ColOffset = colOffset;
        }

        public static Square operator +(Square square, MoveOffset offset)
        {
            return new Square(square.Row+offset.RowOffset, square.Col+offset.ColOffset);
        }
        
        public static IEnumerable<MoveOffset> GetAllDiagonalOffsets()
        {
            HashSet<MoveOffset> diagonalOffsets = new HashSet<MoveOffset>();

            for (int rowOffset = -1; rowOffset < 2; rowOffset+=2)
            {
                for (int colOffset = -1; colOffset < 2; colOffset+=2)
                {
                    for (int distance = 1; distance < GameSettings.BoardSize; distance++)
                    {
                        diagonalOffsets.Add(new MoveOffset(rowOffset * distance, colOffset * distance));
                    }
                }
            }
            
            return diagonalOffsets;
        }

        public static IEnumerable<MoveOffset> GetAllLateralOffsets()
        {
            HashSet<MoveOffset> lateralOffsets = new HashSet<MoveOffset>();

            for (int distance = 1; distance < GameSettings.BoardSize; distance++)
            {
                for (int rowDirection = -1; rowDirection < 2; rowDirection += 2)
                {
                    lateralOffsets.Add(new MoveOffset(rowDirection * distance, 0));
                }
                for (int colDirection = -1; colDirection < 2; colDirection += 2)
                {
                    lateralOffsets.Add(new MoveOffset(0, colDirection * distance));
                }
            }

            return lateralOffsets;
        }
    }
}