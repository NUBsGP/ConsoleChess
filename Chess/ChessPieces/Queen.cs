using Board;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(Color color, ChessBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "Q";
        }
        public override bool[,] PossibleMovements()
        {
            throw new NotImplementedException();
        }
    }
}
