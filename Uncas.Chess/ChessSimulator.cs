using ChessDotNet;
using Microsoft.Extensions.Logging;

namespace Uncas.Chess
{
    public class ChessSimulator
    {
        private readonly IChessEngine _engine;
        private readonly ILogger _logger;

        public ChessSimulator(
            IChessEngine engine,
            ILogger<ChessSimulator> logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public void SimulateGame()
        {
            var game = new ChessGame();
            while (!game.IsOver())
            {
                var move = _engine.SuggestMove(game);
                var piece = game.GetPieceAt(move.OriginalPosition);
                _logger.LogDebug("Move {@Piece}: {@Move}", piece, move);
                game.MakeMove(move, false);
            }

            _logger.LogInformation(game.GetPGN());
        }
    }
}