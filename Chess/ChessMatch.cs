using Board;
using System.Net.NetworkInformation;

namespace Chess
{
    class ChessMatch
    {
        public ChessBoard Board { get; private set; }
        public int Turn { get; private set; }
        public Color PlayerColor { get; private set; }
        public bool EndMatch { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessMatch()
        {
            Board = new(8, 8);
            Turn = 1;
            PlayerColor = Color.White;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            EndMatch = false;
            SetPieces();
        }

        public void MovimentPiece(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.SetPiece(piece, destination);
            if (capturedPiece != null) CapturedPieces.Add(capturedPiece);
        }

        public void MakeMove(Position origin, Position destination)
        {
            MovimentPiece(origin, destination);
            Turn++;
            SwitchPlayer();
        }

        public void ValidatinOriginPosition(Position origin)
        {
            if (Board.PiecePosition(origin) == null) throw new BoardException("There is no piece in the chosen origin position!");
            if (PlayerColor != Board.PiecePosition(origin).Color) throw new BoardException("The origin piece chosen is not yours!");
            if (!Board.PiecePosition(origin).ExistPossibleMovement()) throw new BoardException("There are no possible moves for the chosen origin piece!");
        }

        public void ValidatinDestinationPosition(Position origin, Position destination)
        {
            if (!Board.PiecePosition(origin).CanMoveFromPosition(destination)) throw new BoardException("Invalid destination position!");
        }

        public void SwitchPlayer() 
        {
            if (PlayerColor == Color.White) PlayerColor = Color.Black;
            else PlayerColor = Color.White;
        }

        public HashSet<Piece> ColorCapturedPieces(Color color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces) if (piece.Color == color) pieces.Add(piece);
            return pieces;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();
            foreach (Piece piece in Pieces) if (piece.Color == color) pieces.Add(piece);
            pieces.ExceptWith(ColorCapturedPieces(color));
            return pieces;
        }

        public void SetNewPiece(char column, int line, Piece piece)
        {
            Board.SetPiece(piece, new ChessCoordinate(column, line).ChessToPosition());
            Pieces.Add(piece);
        }
        private void SetPieces() 
        {
            SetNewPiece('a', 1, new Rook(Color.Black, Board));
            SetNewPiece('d', 1, new King(Color.Black, Board));
            SetNewPiece('h', 1, new Rook(Color.Black, Board));
            
            SetNewPiece('a', 8, new Rook(Color.White, Board));
            SetNewPiece('d', 8, new King(Color.White, Board));
            SetNewPiece('h', 8, new Rook(Color.White, Board));
        }
    }
}
