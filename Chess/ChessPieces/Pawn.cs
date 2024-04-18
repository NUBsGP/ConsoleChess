using Board;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, ChessBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
