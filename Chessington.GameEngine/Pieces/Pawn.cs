using System;
using System.Collections.Generic;
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
            
            int moveDirection = Player == Player.White ? -1 : 1;

            availableMoves.Add(mySquare + new MoveOffset(moveDirection,0));
            availableMoves.AddRange(GetSquaresFirstMove(board, moveDirection));

            availableMoves = availableMoves.Where(BoardQuery.IsWithinBounds).Where(square => board.GetPiece(square) == null).ToList();

            availableMoves.AddRange(GetSquaresCanAttack(board, moveDirection));
            availableMoves.AddRange(GetSquaresEnPassant(board, moveDirection));
            
            return availableMoves.Where(BoardQuery.IsWithinBounds);
        }
        
        private List<Square> GetSquaresFirstMove(Board board, int moveDirection)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            if (!HasEverMoved && BoardQuery.IsWithinBounds(mySquare + new MoveOffset(moveDirection, 0)) 
                              && board.GetPiece(mySquare + new MoveOffset(moveDirection, 0)) == null)
            {
                availableMoves.Add(mySquare + new MoveOffset(moveDirection*2,0));
            }

            return availableMoves;
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
        private List<Square> GetSquaresEnPassant(Board board, int moveDirection)
        {
            Square mySquare = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();

            for (int colOffset =-1; colOffset < 2; colOffset+=2)
            {
                Square sidewaysSquare = mySquare + new MoveOffset(0, colOffset);
                if (BoardQuery.IsWithinBounds(sidewaysSquare) &&
                    BoardQuery.IsOppositeColourOnSquares(board, mySquare, sidewaysSquare))
                {
                    if (board.previousBoard.GetPiece(sidewaysSquare + new MoveOffset(moveDirection * 2, 0)) == board.GetPiece(sidewaysSquare))
                    {
                        availableMoves.Add(sidewaysSquare + new MoveOffset(moveDirection,0));
                    }
                    
                }
            }
            return availableMoves;
        }
    }
}