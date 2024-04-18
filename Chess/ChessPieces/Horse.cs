using Board;

namespace Chess
{
    class Horse : Piece
    {
        public Horse(Color color, ChessBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "H";
        }
        public override bool[,] PossibleMovements()
        {
            throw new NotImplementedException();
        }
    }
}
