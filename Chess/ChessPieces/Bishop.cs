using Board;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, ChessBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "B";
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //cima direita
            position.SetPosition(Position.X - 1, Position.Y +1);
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
