using ChessDotNet;

namespace Uncas.Chess
{
    public static class ChessGameExtensions
    {
        public static bool IsOver(this ChessGame game, int maxMoves = 1000)
        {
            var playerToMove = game.WhoseTurn;
            return game.IsCheckmated(playerToMove) ||
                   game.IsDraw() ||
                   game.IsStalemated(playerToMove) ||
                   game.IsInsufficientMaterial() ||
                   game.FullMoveNumber > maxMoves;
        }
    }
}