using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : FixedMovementPiece
    {
        public King(Player player)
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