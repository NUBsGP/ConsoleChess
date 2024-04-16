using Board;

namespace XadrezPieces
{
    class Rook : Piece
    {
        public Rook(Color color, XadrezBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
