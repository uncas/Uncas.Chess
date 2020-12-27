using System;
using System.Collections.Generic;
using System.Linq;
using ChessDotNet;
using Microsoft.Extensions.Logging;

namespace Uncas.Chess
{
    public class ChessSimulator
    {
        private readonly IList<IChessEngine> _engines;
        private readonly ILogger _logger;
        private readonly Random _random;

        public ChessSimulator(
            IEnumerable<IChessEngine> engines,
            ILogger<ChessSimulator> logger)
        {
            _engines = engines.ToList();
            _logger = logger;
            _random = new Random();
        }

        public void SimulateGame()
        {
            var whiteEngine = _engines[_random.Next(_engines.Count)];
            var blackEngine = _engines.Except(new[] {whiteEngine}).ElementAt(_random.Next(_engines.Count - 1));
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
        }
    }
}