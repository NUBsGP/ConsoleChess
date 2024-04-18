namespace Board
{
    class ChessBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces { get; set; }

        public ChessBoard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }

        public ChessBoard(Position position)
        {
            Lines = position.X;
            Columns = position.Y;
            Pieces = new Piece[Lines, Columns];
        }

        public Piece PiecePosition(int lines, int columns)
        {
            return Pieces[lines, columns];
        }
        public Piece PiecePosition(Position position)
        {
            return Pieces[position.X, position.Y];
        }

        public void SetPiece(Piece piece, Position position)
        {
            if (ExistingPiece(position)) throw new BoardException("There is already a piece in that position!");
            Pieces[position.X, position.Y] = piece;
            piece.Position = position;
        }
        public Piece RemovePiece(Position position)
        {
            if (PiecePosition(position) == null) return null;
            else
            {
                Piece piece = PiecePosition(position);
                Pieces[position.X, position.Y] = null;
                return piece;
            }
        }

        public bool ExistingPiece(Position position)
        {
            ValidatingPosition(position);
            return PiecePosition(position) != null;
        }

        public bool ValidPosition(Position position)
        {
            if (position.X >= Lines || position.Y >= Columns || position.X < 0 || position.Y < 0) return false;
            return true;
        }

        public void ValidatingPosition(Position position)
        {
            if (!ValidPosition(position)) throw new BoardException("Invalid Position!");
        }
    }
}
