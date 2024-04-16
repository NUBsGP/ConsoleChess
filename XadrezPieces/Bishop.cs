using Board;

namespace XadrezPieces
{
    class Bishop : Piece
    {
        public Bishop(Color color, XadrezBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "B";
        }
    }
}
