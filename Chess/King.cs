using Chess.Game;

namespace Chess.Chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }


        public override string ToString()
        {
            return "K";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] arr = new bool[Board.Rows, Board.Cols];
            Position pos = new Position(0, 0);


            // Up
            pos.SetValues(Position!.Row - 1, Position.Col);
            if (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
            }

            // Up Left
            pos.SetValues(Position!.Row - 1, Position.Col - 1);
            if (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
            }

            // Up Right
            pos.SetValues(Position!.Row - 1, Position.Col + 1);
            if (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
            }

            // Left
            pos.SetValues(Position!.Row, Position.Col - 1);
            if (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
            }

            // Right
            pos.SetValues(Position!.Row, Position.Col + 1);
            if (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
            }

            // Down
            pos.SetValues(Position!.Row + 1, Position.Col);
            if (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
            }

            // Down Left
            pos.SetValues(Position!.Row + 1, Position.Col - 1);
            if (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
            }

            // Down Right
            pos.SetValues(Position!.Row + 1, Position.Col + 1);
            if (Board.ValidPosition(pos) && PossiblePlace(pos))
            {
                arr[pos.Row, pos.Col] = true;
            }

            return arr;
        }

    }
}
