namespace Chess.Game
{
    internal abstract class Piece
    {
        public Position? Position { get; set; }
        public Color Color { get; protected set; }
        public int MovesCounter { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MovesCounter = 0;
        }

        public abstract bool[,] PossibleMoves();

        public void IncrementMoveCounter()
        {
            MovesCounter++;
        }

        public bool HavePossibleMoves()
        {
            bool[,] arr = PossibleMoves();
            for (int row = 0; row < Board.Rows; row++)
            {
                for (int col = 0; col < Board.Cols; col++)
                {
                    if (arr[row, col])
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Row, position.Col];
        }

        protected bool PossiblePlace(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }
    }
}
