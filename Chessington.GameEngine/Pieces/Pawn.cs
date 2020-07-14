﻿using System.Collections.Generic;
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

            availableMoves.Add(mySquare + new MoveOffset(moveDirection,0));
            availableMoves.AddRange(GetSquaresFirstMove(board, moveDirection));

            availableMoves = availableMoves.Where(BoardQuery.IsWithinBounds).Where(square => board.GetPiece(square) == null).ToList();

            availableMoves.AddRange(GetSquaresCanAttack(board, moveDirection));
            
            return availableMoves.Where(BoardQuery.IsWithinBounds);
        }

        private List<Square> GetSquaresCanAttack(Board board, int moveDirection)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            for (int colOffset =-1; colOffset < 2; colOffset+=2)
            {
                Square captureSquare = mySquare + new MoveOffset(moveDirection, colOffset);
                if (BoardQuery.IsWithinBounds(captureSquare) &&
                    BoardQuery.IsOppositeColourOnSquares(board, mySquare, captureSquare))
                {
                    availableMoves.Add(captureSquare);
                }
            }

            return availableMoves;
        }

        private List<Square> GetSquaresFirstMove(Board board, int moveDirection)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            if (!HasEverMoved)
            {
                if (BoardQuery.IsWithinBounds(mySquare + new MoveOffset(moveDirection, 0)) && board.GetPiece(mySquare + new MoveOffset(moveDirection, 0)) == null)
                {
                    availableMoves.Add(mySquare + new MoveOffset(moveDirection*2,0));
                }
            }

            return availableMoves;
        }
    }
}