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
    }
}