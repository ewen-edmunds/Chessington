using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : TravellingPiece
    {
        public Bishop(Player player)
            : base(player) {
            MoveOffsets = new List<MoveOffset>()
            {
                new MoveOffset(-1,-1), new MoveOffset(-1,1),
                new MoveOffset(1,-1), new MoveOffset(1,1)
            };
        }
    }
}