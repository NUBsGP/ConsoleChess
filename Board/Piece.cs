using Board;

namespace Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public XadrezBoard Board { get; set; }
        public int AmountOfMovements {get; set;}

        public Piece(Position position, Color color, XadrezBoard board)
        {
            this.Position = position;
            this.Color = color;
            this.Board = board;
            this.AmountOfMovements = 0;
        }
    }
}
