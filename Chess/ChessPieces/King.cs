using Board;

namespace Chess
{
    class King : Piece
    {
        private ChessMatch chessMatch;
        public King(Color color, ChessBoard board, ChessMatch chessMatch) : base(color, board)
        {
            this.chessMatch = chessMatch;
        }
        public override string ToString()
        {
            return "K";
        }
        
        private bool testRookCastling(Position position)
        {
            Piece piece = Board.PiecePosition(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.AmountOfMovements == 0;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Board.Lines,Board.Columns];
            Position position = new Position(0, 0);

            //cima
            position.SetPosition(Position.X, Position.Y-1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            //cima direita
            position.SetPosition(Position.X+1, Position.Y-1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            //direita
            position.SetPosition(Position.X+1, Position.Y);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            //baixo direita
            position.SetPosition(Position.X+1, Position.Y+1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            //baixo
            position.SetPosition(Position.X, Position.Y+1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            //baixo esquerda
            position.SetPosition(Position.X-1, Position.Y+1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            //esquerda
            position.SetPosition(Position.X-1, Position.Y);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            //esquerda cima
            position.SetPosition(Position.X-1, Position.Y-1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            //especial move small castling
            if (AmountOfMovements == 0 && !chessMatch.Check)
            {
                Position rook = new(Position.X, Position.Y + 3);
                if (testRookCastling(rook))
                {
                    Position position1 = new(Position.X, Position.Y + 1);
                    Position position2 = new(Position.X, Position.Y + 2);
                    if (Board.PiecePosition(position1) == null && Board.PiecePosition(position2) == null)
                    {
                        possibleMovements[Position.X, Position.Y + 2] = true;
                    }
                }
            }

            //especial move big castling
            if (AmountOfMovements == 0 && !chessMatch.Check)
            {
                Position rook = new(Position.X, Position.Y - 4);
                if (testRookCastling(rook))
                {
                    Position position1 = new(Position.X, Position.Y - 1);
                    Position position2 = new(Position.X, Position.Y - 2);
                    Position position3 = new(Position.X, Position.Y - 3);
                    if (Board.PiecePosition(position1) == null && Board.PiecePosition(position2) == null && Board.PiecePosition(position3) == null)
                    {
                        possibleMovements[Position.X, Position.Y - 2] = true;
                    }
                }
            }

            return possibleMovements;
        }
    }
}
