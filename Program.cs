using Chess.Chess;
using Chess.Game;
using Chess.Game.Exceptions;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var match = new Match();

            while (!match.Finished)
            {
                try
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                    Console.WriteLine();
                    Console.WriteLine($"Turn: {match.Turn}");
                    Console.WriteLine($"Waiting {match.CurrentPlayer} to play...");

                    Console.Write("Type the origin position: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    match.ValidateOriginPosition(origin);

                    bool[,] possibleMoves = match.Board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possibleMoves);
                    Console.WriteLine();

                    Console.Write("Type the target position: ");
                    Position target = Screen.ReadChessPosition().ToPosition();

                    match.PlaySet(origin, target);
                    Screen.PrintBoard(match.Board);
                }
                catch (BoardException e)
                {
                    Console.WriteLine($"Game error: {e.Message}");
                    Console.WriteLine($"Press enter");
                    Console.ReadLine();
                }
            }
        }
    }
}