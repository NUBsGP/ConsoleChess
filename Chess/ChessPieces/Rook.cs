using Board;

namespace Chess {
    class Rook : Piece {

        public Rook(Color color, ChessBoard board) : base(color, board) {
        }

        public override string ToString(){
            return "R";
        }

        public override bool[,] PossibleMovements() {
            bool[,] possibleMovements = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //cima
            position.SetPosition(Position.X -1, Position.Y);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color){
                    break;
                }
                position.X = position.X - 1;
            }
            
            //direita
            position.SetPosition(Position.X, Position.Y+1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.Y++;
            }
            
            //baixo
            position.SetPosition(Position.X+1, Position.Y);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.X++;
            }
            
            //esquerda
            position.SetPosition(Position.X, Position.Y-1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMovements[position.X, position.Y] = true;
                if (Board.PiecePosition(position) != null && Board.PiecePosition(position).Color != Color)
                {
                    break;
                }

                position.Y--;
            }

            return possibleMovements;
        }
    }
}
