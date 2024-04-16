namespace Board
{

    class XadrezBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces { get; set; }

        public XadrezBoard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }

        public Piece PiecePosition(int lines, int columns)
        {
            return Pieces[lines, columns];
        }

        public void SetPiece(Piece piece, Position position)
        {
            Pieces[position.X, position.Y] = piece;
            piece.Position = position;
        }
    }
}
