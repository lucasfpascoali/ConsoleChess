﻿namespace Chess.Game
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovesCounter { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            MovesCounter = 0;
        }


    }
}
