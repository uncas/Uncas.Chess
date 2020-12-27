using ChessDotNet;

namespace Uncas.Chess
{
    public interface IChessEngine
    {
        Move SuggestMove(ChessGame game);
    }
}