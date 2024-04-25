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
            }

            return possibleMovements;
        }
    }
}
