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
        public bool Check { get; private set; } = false;
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public Match()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public void PlaySet(Position origin, Position target)
        {
            Piece? capturedPiece = ExecuteMove(origin, target);

            if (IsKingInCheck(CurrentPlayer))
            {
                UndoMove(origin, target, capturedPiece);
                throw new BoardException("You can't do this move because your king is or will be in check");
            }

            Check = false;
            if (IsKingInCheck(Oponnent(CurrentPlayer)))
            {
                Check = true;
            }

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

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }

            return aux;
        }

        public HashSet<Piece> PiecesInGameByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPieces);

            return aux;
        }

        private bool IsKingInCheck(Color color)
        {
            var king = King(color) ?? throw new BoardException($"There is no {color} King on the board");
            foreach (Piece piece in PiecesInGameByColor(Oponnent(color)))
            {
                return piece.PossibleMoves()[king.Position!.Row, king.Position!.Col];
            }

            return false;
        }

        private Color Oponnent(Color color)
        {
            if (color == Color.White)
                return Color.Black;

            return Color.White;
        }

        private Piece? King(Color color)
        {
            foreach (Piece piece in PiecesInGameByColor(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
        }

        private Piece? ExecuteMove(Position origin, Position target)
        {
            Piece? p = Board.RemovePiece(origin);
            p!.IncrementMoveCounter();
            Piece? capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        private void UndoMove(Position origin, Position target, Piece? capturedPiece)
        {
            Piece piece = Board.RemovePiece(target)!;
            piece.DecrementMoveCounter();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, target);
                CapturedPieces.Remove(capturedPiece);
            }
            Board.PlacePiece(piece, origin);
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

        private void PlaceNewPiece(char col, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(col, row).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces()
        {
            // White Pieces
            PlaceNewPiece('A', 1, new Rook(Board, Color.White));
            PlaceNewPiece('H', 1, new Rook(Board, Color.White));
            PlaceNewPiece('E', 1, new King(Board, Color.White));

            // Black Pieces
            PlaceNewPiece('A', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('H', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('E', 8, new King(Board, Color.Black));
        }
    }
}
