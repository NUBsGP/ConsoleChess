using Board;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, ChessBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "B";
        }
        public override bool[,] PossibleMovements()
        {
            throw new NotImplementedException();
        }
    }
}
