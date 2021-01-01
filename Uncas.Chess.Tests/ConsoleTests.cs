using System;
using ChessDotNet;
using NUnit.Framework;
using Uncas.Chess.ConsoleApp;

namespace Uncas.Chess.Tests
{
    [TestFixture]
    public class ChessConsoleTests
    {
        [Test]
        public void WriteGame_Start_Ok()
        {
            var game = new ChessGame();
            var sut = new ChessConsole(game);

            var board = sut.WriteBoard();

            Console.WriteLine(board);
            StringAssert.StartsWith(
                @"+---+---+---+---+---+---+---+---+
| r | n | b | q | k | b | n | r |",
                board);
        }

        [Test]
        public void WriteGame_D4Nf6_Ok()
        {
            var game = new ChessGame();
            var sut = new ChessConsole(game);
            game.MakeMove(new Move("d2", "d4", Player.White), false);
            game.MakeMove(new Move("g8", "f6", Player.Black), false);

            var board = sut.WriteBoard();

            Console.WriteLine(board);
            StringAssert.StartsWith(
                @"+---+---+---+---+---+---+---+---+
| r | n | b | q | k | b |   | r |",
                board);
        }
    }
}