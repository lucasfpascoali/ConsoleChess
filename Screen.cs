using Chess.Chess;
using Chess.Game;

namespace Chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for (int col = 0; col < board.Cols; col++)
                {
                    if (board.Piece(row, col) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(row, col));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static ChessPosition ReadChessPosition()
        {
            string input = Console.ReadLine()!;
            char col = input[0];
            int row = int.Parse(input[1] + "");

            return new ChessPosition(col, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write($"{piece} ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{piece} ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
