using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

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
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _sut = serviceProvider.GetService<ChessSimulator>();
        }

        private ChessSimulator _sut;

        [Test]
        public void SimulateGame()
        {
            _sut.SimulateGame();
        }
    }
}