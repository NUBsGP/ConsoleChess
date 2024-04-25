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
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new(8, 8);
            Turn = 1;
            PlayerColor = Color.White;
            EndMatch = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            SetPieces();
        }

        private Color Adversary(Color color)
        {
            if (color == Color.White) return Color.Black;
            else return Color.White;
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in PiecesInGame(color)) if (piece is King) return piece;
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = King(color);
            if (king == null) throw new BoardException($"There is no {color} king on the board");
            foreach (Piece piece in PiecesInGame(Adversary(color)))
            {
                bool[,] checkVerification = piece.PossibleMovements();
                if (checkVerification[king.Position.X, king.Position.Y]) return true;
            }
            return false;
        }

        public bool CheckmateTest(Color color)
        {
            if (!IsInCheck(color)) return false;
            foreach (Piece piece in PiecesInGame(color))
            {
                bool[,] possiblesMovements = piece.PossibleMovements();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (possiblesMovements[i, j])
                        {
                            Position origin = piece.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = MovimentPiece(origin, destination);
                            bool checkTest = IsInCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if (!checkTest) return false;
                        }
                    }
                }
            }
            return true;
        }

        public Piece MovimentPiece(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.SetPiece(piece, destination);
            if (capturedPiece != null) CapturedPieces.Add(capturedPiece);
            return capturedPiece;
        }

        public void MakeMove(Position origin, Position destination)
        {
            Piece capturedPiece = MovimentPiece(origin, destination);
            if (IsInCheck(PlayerColor))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check");
            }

            if (IsInCheck(Adversary(PlayerColor))) Check = true;
            else Check = false;

            if (CheckmateTest(Adversary(PlayerColor))) EndMatch = true;
            else
            {
                Turn++;
                SwitchPlayer();
            }

        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destination);
            piece.RemoveMovement();
            if (capturedPiece != null)
            {
                Board.SetPiece(capturedPiece, destination);
                CapturedPieces.Remove(capturedPiece);
            }
            Board.SetPiece(piece, origin);
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
            SetNewPiece('a', 8, new Rook(Color.Black, Board));
            SetNewPiece('b', 8, new Horse(Color.Black, Board));
            SetNewPiece('c', 8, new Bishop(Color.Black, Board));
            SetNewPiece('d', 8, new King(Color.Black, Board));
            SetNewPiece('e', 8, new Queen(Color.Black, Board));
            SetNewPiece('f', 8, new Bishop(Color.Black, Board));
            SetNewPiece('g', 8, new Horse(Color.Black, Board));
            SetNewPiece('h', 8, new Rook(Color.Black, Board));

            SetNewPiece('a', 7, new Pawn(Color.Black, Board));
            SetNewPiece('b', 7, new Pawn(Color.Black, Board));
            SetNewPiece('c', 7, new Pawn(Color.Black, Board));
            SetNewPiece('d', 7, new Pawn(Color.Black, Board));
            SetNewPiece('e', 7, new Pawn(Color.Black, Board));
            SetNewPiece('f', 7, new Pawn(Color.Black, Board));
            SetNewPiece('g', 7, new Pawn(Color.Black, Board));
            SetNewPiece('h', 7, new Pawn(Color.Black, Board));
            
            
            SetNewPiece('a', 2, new Pawn(Color.White, Board));
            SetNewPiece('b', 2, new Pawn(Color.White, Board));
            SetNewPiece('c', 2, new Pawn(Color.White, Board));
            SetNewPiece('d', 2, new Pawn(Color.White, Board));
            SetNewPiece('e', 2, new Pawn(Color.White, Board));
            SetNewPiece('f', 2, new Pawn(Color.White, Board));
            SetNewPiece('g', 2, new Pawn(Color.White, Board));
            SetNewPiece('h', 2, new Pawn(Color.White, Board));
            
            SetNewPiece('a', 1, new Rook(Color.White, Board));
            SetNewPiece('b', 1, new Horse(Color.White, Board));
            SetNewPiece('c', 1, new Bishop(Color.White, Board));
            SetNewPiece('d', 1, new King(Color.White, Board));
            SetNewPiece('e', 1, new Queen(Color.White, Board));
            SetNewPiece('f', 1, new Bishop(Color.White, Board));
            SetNewPiece('g', 1, new Horse(Color.White, Board));
            SetNewPiece('h', 1, new Rook(Color.White, Board));
            
        }
    }
}
