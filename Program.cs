using Chess.Chess;
using Chess.Game;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new(8, 8);
            board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
            board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
            board.PutPiece(new King(board, Color.Black), new Position(2, 4));




            Screen.PrintBoard(board);
        }
    }
}