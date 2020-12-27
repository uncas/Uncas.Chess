# Uncas Chess

This project contains a chess simulator and engine(s).

The project uses the brilliant Chess.NET framework
for handling chess rules, board, pieces, and game logic:
[Chess.NET](https://github.com/thomas-daniels/Chess.NET/)

Engines:
- RandomChessEngine: Picks a random move
- RestrictNumberOfOpponentMovesEngine:
Picks the move that minimizes the number of possible opponent moves
(consistently beats RandomChessEngine by at least 70-30 in a 100-game match)
