using Chess.Chess;
using Chess.Game;

namespace Chess
{
    internal class Screen
    {
        public static void PrintMatch(Match match)
        {
            Screen.PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"Turn: {match.Turn}");
            Console.WriteLine($"Waiting {match.CurrentPlayer} to play...");
            if (match.Check)
            {
                Console.WriteLine("You are in CHECK!");
            }
        }

        public static void PrintCapturedPieces(Match match)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            PrintCollection(match.CapturedPiecesByColor(Color.White));
            Console.Write("Black: ");
            PrintCollection(match.CapturedPiecesByColor(Color.Black));
        }

        public static void PrintCollection(HashSet<Piece> pieces)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.Write("[ ");
            foreach (Piece piece in pieces)
            {
                if (piece.Color == Color.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write($"{piece} ");
            }
            Console.ForegroundColor = aux;
            Console.WriteLine("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for (int col = 0; col < board.Cols; col++)
                {
                    PrintPiece(board.Piece(row, col));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor defaultBackground = Console.BackgroundColor;
            ConsoleColor modifiedBackground = ConsoleColor.DarkGray;

            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for (int col = 0; col < board.Cols; col++)
                {
                    if (possibleMoves[row, col])
                        Console.BackgroundColor = modifiedBackground;

                    PrintPiece(board.Piece(row, col));
                    Console.BackgroundColor = defaultBackground;
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
            if (piece == null)
            {
                Console.Write("- ");
                return;
            }

            if (piece.Color == Color.Black)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{piece} ");
                Console.ForegroundColor = aux;
                return;
            }

            Console.Write($"{piece} ");
        }
    }
}
