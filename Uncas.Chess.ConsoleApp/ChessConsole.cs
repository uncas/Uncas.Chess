using System.Text;
using ChessDotNet;

namespace Uncas.Chess.ConsoleApp
{
    public class ChessConsole
    {
        private readonly ChessGame _game;

        public ChessConsole(ChessGame game)
        {
            _game = game;
        }

        public string WriteBoard()
        {
            var builder = new StringBuilder();
            const string line = "+---+---+---+---+---+---+---+---+";
            builder.AppendLine(line);
            foreach (var row in _game.GetBoard())
            {
                builder.Append("|");
                foreach (var column in row)
                {
                    builder.Append(" ");
                    if (column == null)
                    {
                        builder.Append(" ");
                    }
                    else
                    {
                        builder.Append(column.GetFenCharacter());
                    }

                    builder.Append(" |");
                }

                builder.AppendLine();
                builder.AppendLine(line);
            }

            return builder.ToString();
        }
    }
}