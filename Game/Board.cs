namespace Chess.Game
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        private readonly Piece[,] Pieces;

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Pieces = new Piece[Rows, Cols];
        }

        public Piece Piece(int row, int col)
        {
            return Pieces[row, col];
        }

        public void PutPiece(Piece piece, Position position)
        {
            Pieces[position.Row, position.Col] = piece;
            piece.Position = position;
        }
    }
}
