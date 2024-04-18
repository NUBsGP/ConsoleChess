namespace Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public ChessBoard Board { get; set; }
        public int AmountOfMovements { get; set; }

        public Piece(Color color, ChessBoard board)
        {
            this.Position = null;
            this.Color = color;
            this.Board = board;
            this.AmountOfMovements = 0;
        }
    }
}
