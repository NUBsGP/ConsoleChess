using Board;

namespace Chess
{
    class King : Piece
    {
        public King(Color color, ChessBoard board) : base(color, board)
        {
            
        }
        public override string ToString()
        {
            return "K";
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
            return possibleMovements;
        }
    }
}
