using Chess.Game;

namespace Chess.Chess
{
    internal class ChessPosition
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Position ToPosition()
        {
            return new Position(8 - Row, Char.ToLower(Column) - 'a');
        }

        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}
