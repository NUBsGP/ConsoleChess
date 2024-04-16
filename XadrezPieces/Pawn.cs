using Board;

namespace XadrezPieces
{
    class Pawn : Piece
    {
        public Pawn(Color color, XadrezBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
