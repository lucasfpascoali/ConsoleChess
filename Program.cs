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
                board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PutPiece(new King(board, Color.Black), new Position(0, 1));

                Screen.PrintBoard(board);
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