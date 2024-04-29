using Board;

namespace Chess 
{ 
    class Pawn : Piece
    {
        private ChessMatch ChessMatch;
        public Pawn(Color color, ChessBoard board, ChessMatch chessMatch) : base(color, board)
        {
            ChessMatch = chessMatch;
        }
        public override string ToString()
        {
            return "P";
        }

        private bool ThereIsEnemy(Position position)
        {
            Piece piece = Board.PiecePosition(position);
            return piece != null && piece.Color != this.Color;
        }

        private bool FreePosition(Position position)
        {
            return Board.PiecePosition(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetPosition(Position.X-1, Position.Y);
                if (Board.ValidPosition(position) && FreePosition(position))
                {
                    possibleMovements[position.X, position.Y] = true;
                }
                
                position.SetPosition(Position.X-2, Position.Y);
                if (Board.ValidPosition(position) && FreePosition(position) && AmountOfMovements == 0)
                {
                    possibleMovements[position.X, position.Y] = true;
                }

                position.SetPosition(Position.X-1, Position.Y - 1);
                if (Board.ValidPosition(position) && ThereIsEnemy(position))
                {
                    possibleMovements[position.X, position.Y] = true;
                }
                
                position.SetPosition(Position.X - 1, Position.Y + 1);
                if (Board.ValidPosition(position) && ThereIsEnemy(position))
                {
                    possibleMovements[position.X, position.Y] = true;
                }

                //spacial move en passant
                if (Position.X == 3)
                {
                    Position left = new(Position.X, Position.Y - 1);
                    if (Board.ValidPosition(left) && ThereIsEnemy(left) && Board.PiecePosition(left) == ChessMatch.VulnerableEnPassant)
                    {
                        possibleMovements[left.X-1, left.Y] = true;
                    }
                    
                    Position right = new(Position.X, Position.Y + 1);
                    if (Board.ValidPosition(right) && ThereIsEnemy(right) && Board.PiecePosition(right) == ChessMatch.VulnerableEnPassant)
                    {
                        possibleMovements[right.X-1, right.Y] = true;
                    }
                }
            }
            
            else
            {
                position.SetPosition(Position.X+1, Position.Y);
                if (Board.ValidPosition(position) && FreePosition(position))
                {
                    possibleMovements[position.X, position.Y] = true;
                }
                
                position.SetPosition(Position.X+2, Position.Y);
                if (Board.ValidPosition(position) && FreePosition(position) && AmountOfMovements == 0)
                {
                    possibleMovements[position.X, position.Y] = true;
                }

                position.SetPosition(Position.X + 1, Position.Y + 1);
                if (Board.ValidPosition(position) && FreePosition(position) && ThereIsEnemy(position))
                {
                    possibleMovements[position.X, position.Y] = true;
                }
                
                position.SetPosition(Position.X + 1, Position.Y - 1);
                if (Board.ValidPosition(position) && FreePosition(position) && ThereIsEnemy(position))
                {
                    possibleMovements[position.X, position.Y] = true;
                }

                //spacial move en passant
                if (Position.X == 4)
                {
                    Position left = new(Position.X, Position.Y - 1);
                    if (Board.ValidPosition(left) && ThereIsEnemy(left) && Board.PiecePosition(left) == ChessMatch.VulnerableEnPassant)
                    {
                        possibleMovements[left.X+1, left.Y] = true;
                    }

                    Position right = new(Position.X, Position.Y + 1);
                    if (Board.ValidPosition(right) && ThereIsEnemy(right) && Board.PiecePosition(right) == ChessMatch.VulnerableEnPassant)
                    {
                        possibleMovements[right.X+1, right.Y] = true;
                    }
                }
            }

            return possibleMovements;
        }
    }
}
