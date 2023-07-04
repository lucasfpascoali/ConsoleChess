using Chess.Game;

namespace Chess.Chess
{
    internal class Match
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }

        public Match()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void ExecuteMove(Position origin, Position target)
        {
            Piece? p = Board.RemovePiece(origin);
            p.IncrementMoveCounter();
            Piece? capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);

        }

        private void PlacePieces()
        {
            // White Pieces
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('A', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('H', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('E', 1).ToPosition());

            // Black Pieces
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('A', 8).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('H', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('E', 8).ToPosition());
        }
    }
}
