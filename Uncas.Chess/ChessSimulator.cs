using ChessDotNet;
using Microsoft.Extensions.Logging;

namespace Uncas.Chess
{
    public class ChessSimulator
    {
        private readonly ILogger _logger;

        public ChessSimulator(ILogger<ChessSimulator> logger)
        {
            _logger = logger;
        }

        public GameResult SimulateGame(IChessEngine whiteEngine, IChessEngine blackEngine)
        {
            _logger.LogInformation("White: {WhiteEngine}", whiteEngine.GetType().Name);
            _logger.LogInformation("Black: {BlackEngine}", blackEngine.GetType().Name);
            var game = new ChessGame();
            while (!game.IsOver())
            {
                var engine = game.WhoseTurn == Player.White ? whiteEngine : blackEngine;
                var move = engine.SuggestMove(game);
                var piece = game.GetPieceAt(move.OriginalPosition);
                _logger.LogDebug("Move {@Piece}: {@Move}", piece, move);
                game.MakeMove(move, false);
            }

            _logger.LogInformation(game.GetPGN());
            if (game.IsWinner(Player.White))
            {
                return GameResult.WhiteWins;
            }

            if (game.IsWinner(Player.Black))
            {
                return GameResult.BlackWins;
            }

            return GameResult.Draw;
        }
    }
}