namespace Chess.Game
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Pieces = new Piece[Rows, Cols];
        }




    }
}
