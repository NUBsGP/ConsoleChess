using Board;

namespace XadrezPieces
{
    class Horse : Piece
    {
        public Horse(Color color, XadrezBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "H";
        }
    }
}
