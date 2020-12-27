using System;
using ChessDotNet;

namespace Uncas.Chess
{
    /// <summary>
    ///     1st game by this engine against itself: https://lichess.org/MOn0XuZC : 280 moves before white checkmates black
    ///     2nd game: https://lichess.org/6WWK3DVn: 38-move checkmate
    /// </summary>
    public class RandomChessEngine : IChessEngine
    {
        public Move SuggestMove(ChessGame game)
        {
            var playerToMove = game.WhoseTurn;
            var moves = game.GetValidMoves(playerToMove);
            var moveIndex = new Random().Next(moves.Count);
            return moves[moveIndex];
        }
    }
}