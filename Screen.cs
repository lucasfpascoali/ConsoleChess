using Chess.Game;

namespace Chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    if (board.Piece(row, col) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{board.Piece(row, col)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
