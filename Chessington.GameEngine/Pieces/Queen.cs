using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : TravellingPiece
    {
        public Queen(Player player)
            : base(player)
        {
            MoveOffsets = new List<MoveOffset>()
            {
                new MoveOffset(-1,-1), new MoveOffset(-1,0), new MoveOffset(-1,1), 
                new MoveOffset(0,-1), new MoveOffset(0,1),
                new MoveOffset(1,-1), new MoveOffset(1,0), new MoveOffset(1,1)
            };
        }
        
    }
}