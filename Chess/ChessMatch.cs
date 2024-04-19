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

        public ChessMatch()
        {
            Board = new(8, 8);
            Turn = 1;
            PlayerColor = Color.White;
            SetPieces();
            EndMatch = false;
        }

        public void MovimentPiece(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.SetPiece(piece, destination);
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

        /*private void SetPieces()
        {
            Board.SetPiece(new Rook(Color.White, Board), new ChessCoordinate('a', 8).ChessToPosition());
            Board.SetPiece(new Horse(Color.White, Board), new ChessCoordinate('b', 8).ChessToPosition());
            Board.SetPiece(new Bishop(Color.White, Board), new ChessCoordinate('c', 8).ChessToPosition());
            Board.SetPiece(new King(Color.White, Board), new ChessCoordinate('d', 8).ChessToPosition());
            Board.SetPiece(new Queen(Color.White, Board), new ChessCoordinate('e', 8).ChessToPosition());
            Board.SetPiece(new Bishop(Color.White, Board), new ChessCoordinate('f', 8).ChessToPosition());
            Board.SetPiece(new Horse(Color.White, Board), new ChessCoordinate('g', 8).ChessToPosition());
            Board.SetPiece(new Rook(Color.White, Board), new ChessCoordinate('h', 8).ChessToPosition());

            Board.SetPiece(new Pawn(Color.White, Board), new ChessCoordinate('a', 7).ChessToPosition());
            Board.SetPiece(new Pawn(Color.White, Board), new ChessCoordinate('b', 7).ChessToPosition());
            Board.SetPiece(new Pawn(Color.White, Board), new ChessCoordinate('c', 7).ChessToPosition());
            Board.SetPiece(new Pawn(Color.White, Board), new ChessCoordinate('d', 7).ChessToPosition());
            Board.SetPiece(new Pawn(Color.White, Board), new ChessCoordinate('e', 7).ChessToPosition());
            Board.SetPiece(new Pawn(Color.White, Board), new ChessCoordinate('f', 7).ChessToPosition());
            Board.SetPiece(new Pawn(Color.White, Board), new ChessCoordinate('g', 7).ChessToPosition());
            Board.SetPiece(new Pawn(Color.White, Board), new ChessCoordinate('h', 7).ChessToPosition());



            Board.SetPiece(new Rook(Color.Black, Board), new ChessCoordinate('a', 1).ChessToPosition());
            Board.SetPiece(new Horse(Color.Black, Board), new ChessCoordinate('b', 1).ChessToPosition());
            Board.SetPiece(new Bishop(Color.Black, Board), new ChessCoordinate('c', 1).ChessToPosition());
            Board.SetPiece(new King(Color.Black, Board), new ChessCoordinate('d', 1).ChessToPosition());
            Board.SetPiece(new Queen(Color.Black, Board), new ChessCoordinate('e', 1).ChessToPosition());
            Board.SetPiece(new Bishop(Color.Black, Board), new ChessCoordinate('f', 1).ChessToPosition());
            Board.SetPiece(new Horse(Color.Black, Board), new ChessCoordinate('g', 1).ChessToPosition());
            Board.SetPiece(new Rook(Color.Black, Board), new ChessCoordinate('h', 1).ChessToPosition());

            Board.SetPiece(new Pawn(Color.Black, Board), new ChessCoordinate('a', 2).ChessToPosition());
            Board.SetPiece(new Pawn(Color.Black, Board), new ChessCoordinate('b', 2).ChessToPosition());
            Board.SetPiece(new Pawn(Color.Black, Board), new ChessCoordinate('c', 2).ChessToPosition());
            Board.SetPiece(new Pawn(Color.Black, Board), new ChessCoordinate('d', 2).ChessToPosition());
            Board.SetPiece(new Pawn(Color.Black, Board), new ChessCoordinate('e', 2).ChessToPosition());
            Board.SetPiece(new Pawn(Color.Black, Board), new ChessCoordinate('f', 2).ChessToPosition());
            Board.SetPiece(new Pawn(Color.Black, Board), new ChessCoordinate('g', 2).ChessToPosition());
            Board.SetPiece(new Pawn(Color.Black, Board), new ChessCoordinate('h', 2).ChessToPosition());
        }*/
        private void SetPieces() 
        { 
            Board.SetPiece(new Rook(Color.White, Board), new ChessCoordinate('e', 4).ChessToPosition());
            Board.SetPiece(new King(Color.White, Board), new ChessCoordinate('e', 5).ChessToPosition());
        }
    }
}
