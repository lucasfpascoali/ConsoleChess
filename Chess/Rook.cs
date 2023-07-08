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

        public override bool[,] PossibleMoves()
        {
            bool[,] arr = new bool[Board.Rows, Board.Cols];
            Position pos = new Position(0, 0);


            // Up
            pos.SetValues(Position!.Row - 1, Position.Col);
            while (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;

                pos.Row--;
            }

            // Down
            pos.SetValues(Position!.Row + 1, Position.Col);
            while (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;

                pos.Row++;
            }

            // Left
            pos.SetValues(Position!.Row, Position.Col - 1);
            while (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;

                pos.Col--;
            }

            // Right
            pos.SetValues(Position!.Row, Position.Col + 1);
            while (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;

                pos.Col++;
            }

            return arr;
        }

    }
}
