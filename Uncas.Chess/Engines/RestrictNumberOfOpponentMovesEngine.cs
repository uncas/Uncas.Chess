using System.Collections.Generic;
using System.Linq;
using ChessDotNet;

namespace Uncas.Chess.Engines
{
    public class RestrictNumberOfOpponentMovesEngine : IChessEngine
    {
        public Move SuggestMove(ChessGame game)
        {
            var playerToMove = game.WhoseTurn;
            var otherPlayer = playerToMove == Player.White ? Player.Black : Player.White;
            var moves = game.GetValidMoves(playerToMove);
            var result = new List<(Move, int)>();
            foreach (var move in moves)
            {
                var clone = new ChessGame(game.Moves, true);
                clone.MakeMove(move, true);
                var numberOfValidMoves = clone.GetValidMoves(otherPlayer).Count;
                result.Add((move, numberOfValidMoves));
            }

            return result.OrderBy(x => x.Item2).First().Item1;
        }
    }
}