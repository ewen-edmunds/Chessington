using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    
    public class Rook : TravellingPiece
    {
        public Rook(Player player)
            : base(player) {
            MoveOffsets = new List<MoveOffset>()
            {
                new MoveOffset(-1,0), new MoveOffset(0,-1), 
                new MoveOffset(0,1), new MoveOffset(1,0)
            };
        }
    }
}