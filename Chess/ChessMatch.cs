using Board;
using ChessInConsole;
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
        public Piece VulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new(8, 8);
            Turn = 1;
            PlayerColor = Color.White;
            EndMatch = false;
            Check = false;
            VulnerableEnPassant = null;
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

            // special move small castling
            if (piece is King && destination.Y == origin.Y + 2)
            {
                Position originRook = new(origin.X, origin.Y + 3);
                Position destinationRook = new(origin.X, origin.Y + 1);
                Piece rook = Board.RemovePiece(originRook);
                rook.AddMovement();
                Board.SetPiece(rook, destinationRook);
            }

            // special move big castling
            if (piece is King && destination.Y == origin.Y - 2)
            {
                Position originRook = new(origin.X, origin.Y - 4);
                Position destinationRook = new(origin.X, origin.Y - 1);
                Piece rook = Board.RemovePiece(originRook);
                rook.AddMovement();
                Board.SetPiece(rook, destinationRook);
            }

            // special move en passant
            if (piece is Pawn && destination.Y != origin.Y && capturedPiece == null)
            {
                Position enemyPosition;
                if (piece.Color == Color.White)
                {
                    enemyPosition = new(destination.X + 1, destination.Y);
                }

                else
                {
                    enemyPosition = new(destination.X - 1, destination.Y);
                }

                capturedPiece = Board.RemovePiece(enemyPosition);
                CapturedPieces.Add(capturedPiece);
            }

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

            Piece piece = Board.PiecePosition(destination);

            //special move promotion
            if (piece is Pawn && ((piece.Color == Color.White && piece.Position.X == 0) || (piece.Color == Color.Black && piece.Position.X == 7)))
            {
                piece = Board.RemovePiece(destination);
                Pieces.Remove(piece);
                Piece chosenPiece = ChosenPiece(piece.Color);
                Board.SetPiece(chosenPiece, destination);
                Pieces.Add(chosenPiece);
            }

            //special move en passant
            if (piece is Pawn && (destination.X == origin.X - 2 || destination.X == origin.X + 2))
            {
                VulnerableEnPassant = piece;
            }
            else
            {
                //VulnerableEnPassant = null;
            }


        }

        public Piece ChosenPiece(Color color)
        {
            Console.Write("\nYour Pokemon(Pawn) is evolving :)\n\n" +
                            "Queen = Q\n" +
                            "Rook = R\n" +
                            "Bishop = B\n" +
                            "Horse = H\n\n" +
                            "Chose your evolution (Q/R/B/H): ");

            char Chosen = char.Parse(Console.ReadLine());

            if (Chosen == 'Q' || Chosen == 'q')
            {
                return new Queen(color, Board);
            }
            
            if (Chosen == 'R' || Chosen == 'r')
            {
                return new Rook(color, Board);
            }
            
            if (Chosen == 'B' || Chosen == 'b')
            {
                return new Bishop(color, Board);
            }
            
            if (Chosen == 'H' || Chosen == 'h')
            {
                return new Horse(color, Board);
            }

            return null;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece1 = Board.PiecePosition(destination);
            

            // special move small castling
            if (piece1 is King && destination.Y == origin.Y + 2)
            {
                Position originRook = new(origin.X, origin.Y + 3);
                Position destinationRook = new(origin.X, origin.Y + 1);
                Piece rook = Board.RemovePiece(destinationRook);
                rook.RemoveMovement();
                Board.SetPiece(rook, originRook);
            }

            // special move big castling
            else if (piece1 is King && destination.Y == origin.Y - 2)
            {
                Position originRook = new(origin.X, origin.Y - 4);
                Position destinationRook = new(origin.X, origin.Y - 1);
                Piece rook = Board.RemovePiece(destinationRook);
                rook.RemoveMovement();
                Board.SetPiece(rook, originRook);
            }

            // special move en passant
            else if (piece1 is Pawn && destination.X != origin.X && capturedPiece == VulnerableEnPassant)
            {
                Piece pawn = Board.RemovePiece(destination);
                pawn.RemoveMovement();
                Board.SetPiece(pawn, origin);

                Position enemyPosition;
                if (piece1.Color == Color.White)
                {
                    enemyPosition = new(destination.X + 1, destination.Y);
                }

                else
                {
                    enemyPosition = new(destination.X - 1, destination.Y);
                }

                Board.SetPiece(capturedPiece, enemyPosition);
            }

            else
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
            SetNewPiece('e', 1, new King(Color.White, Board, this));
            SetNewPiece('e', 8, new King(Color.Black, Board, this));
            SetNewPiece('a', 7, new Pawn(Color.White, Board, this));
            SetNewPiece('d', 7, new Pawn(Color.Black, Board, this));
        }
    }
}
