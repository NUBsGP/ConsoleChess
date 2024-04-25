using Board;

namespace Chess
{
    class Horse : Piece
    {
        public Horse(Color color, ChessBoard board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "H";
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            //cima2 direita1
            position.SetPosition(Position.X - 2, Position.Y + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }
            
            //cima1 direita2
            position.SetPosition(Position.X - 1, Position.Y + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }
            
            //baixo1 direita2
            position.SetPosition(Position.X + 1, Position.Y + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }
            
            //baixo2 direita1
            position.SetPosition(Position.X + 2, Position.Y + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }
            
            //baixo2 esquerda1
            position.SetPosition(Position.X + 2, Position.Y - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }
            
            //baixo1 esquerda2
            position.SetPosition(Position.X + 1, Position.Y - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }
            
            //cima1 esquerda2
            position.SetPosition(Position.X - 1, Position.Y - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }
            
            //cima2 esquerda1
            position.SetPosition(Position.X - 2, Position.Y - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
            }

            return possibleMovements;
        }
    }
}
