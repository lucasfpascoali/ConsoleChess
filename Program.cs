using Chess.Chess;
using Chess.Game;
using Chess.Game.Exceptions;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new(8, 8);

            try
            {
                ChessPosition pos = new ChessPosition('A', 1);

                Console.WriteLine(pos.ToPosition());
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