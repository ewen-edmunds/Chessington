using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : FixedMovementPiece
    {
        public Knight(Player player)
            : base(player)
        {
            MoveOffsets = new List<MoveOffset>()
            {
                new MoveOffset(-1,-2), new MoveOffset(-1,2),
                new MoveOffset(1,-2), new MoveOffset(1,2),
                new MoveOffset(-2,-1), new MoveOffset(-2,1),
                new MoveOffset(2,-1), new MoveOffset(2,1)
            };
        }
    }
}