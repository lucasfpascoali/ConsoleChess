using Chess.Game;
using Chess.Game.Exceptions;

namespace Chess.Chess
{
    internal class Match
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public Match()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void PlaySet(Position origin, Position target)
        {
            ExecuteMove(origin, target);
            Turn++;
            ChangeCurrentPlayer();
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in this position");
            }

            if (Board.Piece(position).Color != CurrentPlayer)
            {
                throw new BoardException("This piece is not yours");
            }

            if (!Board.Piece(position).HavePossibleMoves())
            {
                throw new BoardException("This piece doesn't have any valid move");
            }
        }

        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.Piece(origin).CanMoveTo(target))
            {
                throw new BoardException("This move isn't possible");
            }
        }

        private void ExecuteMove(Position origin, Position target)
        {
            Piece? p = Board.RemovePiece(origin);
            p!.IncrementMoveCounter();
            Piece? capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
        }

        private void ChangeCurrentPlayer()
        {
            if (CurrentPlayer == Color.Black)
            {
                CurrentPlayer = Color.White;
                return;
            }

            CurrentPlayer = Color.Black;
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
