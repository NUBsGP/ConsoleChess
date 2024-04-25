using Board;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(Color color, ChessBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "Q";
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            //cima
            position.SetPosition(Position.X - 1, Position.Y);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }
                position.X = position.X - 1;
            }

            //cima direita
            position.SetPosition(Position.X - 1, Position.Y + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }
                position.X--;
                position.Y++;
            }

            //direita
            position.SetPosition(Position.X, Position.Y + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.Y++;
            }

            //baixo direita
            position.SetPosition(Position.X + 1, Position.Y + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.X++;
                position.Y++;
            }

            //baixo
            position.SetPosition(Position.X + 1, Position.Y);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.X++;
            }

            //baixo esquerda
            position.SetPosition(Position.X + 1, Position.Y - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.Y--;
                position.X++;
            }

            //esquerda
            position.SetPosition(Position.X, Position.Y - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.Y--;
            }

            //cima esquerda
            position.SetPosition(Position.X - 1, Position.Y - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.X--;
                position.Y--;
            }

            return possibleMovements;
        }
    }
}
