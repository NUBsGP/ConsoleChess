namespace Board
{
    
    class XadrezBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Piece { get; set; }

        public XadrezBoard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Piece = new Piece[Lines, Columns];
        }

        public Piece PiecePosition(int lines, int columns)
        {
            return Piece[lines, columns];
        }
    }
}
