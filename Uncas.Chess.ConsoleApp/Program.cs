using System;
using ChessDotNet;

namespace Uncas.Chess.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new ChessGame();
            var console = new ChessConsole(game);
            Console.Clear();
            while (!game.IsOver())
            {
                Console.WriteLine(console.WriteBoard());
                Console.WriteLine("Enter move from for {0}", game.WhoseTurn);
                var moveFrom = Console.ReadLine();
                Console.WriteLine("Enter move to for {0}", game.WhoseTurn);
                var moveTo = Console.ReadLine();
                var move = new Move(moveFrom, moveTo, game.WhoseTurn);
                var isValidMove = game.IsValidMove(move);
                Console.Clear();
                if (isValidMove)
                {
                    game.MakeMove(move, true);
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            }
        }
    }
}