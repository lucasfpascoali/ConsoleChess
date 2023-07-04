using Chess.Game.Exceptions;

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

        public Piece Piece(Position position)
        {
            return Pieces[position.Row, position.Col];
        }

        public bool PositionUnavailable(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (PositionUnavailable(position))
            {
                throw new BoardException("This position already has a piece");
            }

            Pieces[position.Row, position.Col] = piece;
            piece.Position = position;
        }

        public Piece? RemovePiece(Position position)
        {
            if (!PositionUnavailable(position))
                return null;

            Piece aux = Piece(position);
            aux.Position = null;
            Pieces[position.Row, position.Col] = null;
            return aux;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Col < 0 || position.Col >= Cols)
                return false;

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
                throw new BoardException("Invalid Position");
        }
    }
}
