using Board;

namespace XadrezPieces
{
    class King : Piece
    {
        public King(Color color, XadrezBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "K";
        }
    }
}
