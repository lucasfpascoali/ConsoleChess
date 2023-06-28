using Chess.Game;

namespace Chess.Chess
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color) { }


        public override string ToString()
        {
            return "R";
        }

    }
}
