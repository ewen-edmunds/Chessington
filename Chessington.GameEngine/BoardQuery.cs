﻿using System.Collections.Generic;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class BoardQuery
    {
        public static bool IsWithinBounds(Square square)
        {
            return square.Row >= 0 && square.Row < GameSettings.BoardSize &&
                   square.Col >= 0 && square.Col < GameSettings.BoardSize;
        }
        
        public static bool IsSameColourOnSquares(Board board, Square square1, Square square2)
        {
            if (board.GetPiece(square1) == null || board.GetPiece(square2) == null)
            {
                return false;
            }
            return board.GetPiece(square1).Player == board.GetPiece(square2).Player;
        }
        
        public static bool IsOppositeColourOnSquares(Board board, Square square1, Square square2)
        {
            if (board.GetPiece(square1) == null || board.GetPiece(square2) == null)
            {
                return false;
            }
            return board.GetPiece(square1).Player != board.GetPiece(square2).Player;
        }
        
        public static IEnumerable<Square> GetValidMovesInDirection(Board board, Square startingSquare, MoveOffset direction)
        {
            List<Square> validMoves = new List<Square>();
            int distance = 1;

            while (BoardQuery.IsWithinBounds(startingSquare + (direction * distance)) && board.GetPiece(startingSquare + (direction * distance)) == null)
            {
                validMoves.Add(startingSquare + (direction * distance));
                distance += 1;
            }

            if (BoardQuery.IsWithinBounds(startingSquare + (direction * distance)) &&
                !IsSameColourOnSquares(board, startingSquare + (direction * distance), startingSquare))
            {
                validMoves.Add(startingSquare + (direction * distance));
            }

            return validMoves;
        }
    }
}