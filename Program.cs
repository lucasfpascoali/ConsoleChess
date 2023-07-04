using Chess.Chess;
using Chess.Game;
using Chess.Game.Exceptions;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var match = new Match();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                    Console.WriteLine();

                    Console.Write("Type the origin position: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Type the target position: ");
                    Position target = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMove(origin, target);
                    Screen.PrintBoard(match.Board);
                }


            }
            catch (BoardException e)
            {
                Console.WriteLine($"Oops... {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected Error: {e.Message}");
            }



        }
    }
}