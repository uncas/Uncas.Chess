using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Uncas.Chess.Engines;

namespace Uncas.Chess.Tests
{
    [TestFixture]
    [Category("Unit")]
    public class ChessSimulatorTests
    {
        [SetUp]
        public void BeforeEach()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureChess();
            _serviceProvider = serviceCollection.BuildServiceProvider();
            _sut = _serviceProvider.GetService<ChessSimulator>();
        }

        private ChessSimulator _sut;
        private ServiceProvider _serviceProvider;

        [Test]
        public void SimulateGame_RandomEngines()
        {
            var random = new Random();
            var engines = _serviceProvider.GetServices<IChessEngine>().ToList();
            var whiteEngine = engines[random.Next(engines.Count)];
            var blackEngine = engines.Except(new[] {whiteEngine}).ElementAt(random.Next(engines.Count - 1));
            var result = _sut.SimulateGame(whiteEngine, blackEngine);
            Console.WriteLine(result);
        }

        [Test]
        public void Match()
        {
            IChessEngine engine1 = new RandomChessEngine();
            IChessEngine engine2 = new RestrictNumberOfOpponentMovesEngine();
            var (engine1Score, engine2Score) = (0.0, 0.0);
            var results = new List<(int, GameResult, IChessEngine)>();
            for (var round = 1; round <= 100; round++)
            {
                var whiteEngine = round % 2 == 1 ? engine1 : engine2;
                var blackEngine = whiteEngine == engine1 ? engine2 : engine1;
                var result = _sut.SimulateGame(whiteEngine, blackEngine);
                var winner = result == GameResult.WhiteWins
                    ? whiteEngine
                    : result == GameResult.BlackWins
                        ? blackEngine
                        : null;
                results.Add((round, result, winner));
                if (winner == engine1)
                {
                    engine1Score += 1;
                }

                if (winner == engine2)
                {
                    engine2Score += 1;
                }

                if (winner == null)
                {
                    engine1Score += 0.5;
                    engine2Score += 0.5;
                }
            }

            foreach (var result in results)
            {
                Console.WriteLine("Round {0}: {1} ({2})", result.Item1, result.Item2, result.Item3?.GetType().Name);
            }

            Console.WriteLine(
                "Result: {0} {1} - {2} {3}",
                engine1.GetType().Name,
                engine1Score,
                engine2Score,
                engine2.GetType().Name);
        }
    }
}