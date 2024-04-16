using Board;

namespace XadrezPieces
{
    class Queen : Piece
    {
        public Queen(Color color, XadrezBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "Q";
        }
    }
}
