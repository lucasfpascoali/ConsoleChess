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

        protected bool CanGoTo(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }
    }
}
