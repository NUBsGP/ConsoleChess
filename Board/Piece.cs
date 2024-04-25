namespace Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public ChessBoard Board { get; set; }
        public int AmountOfMovements { get; set; }

        public Piece(Color color, ChessBoard board)
        {
            this.Position = null;
            this.Color = color;
            this.Board = board;
            this.AmountOfMovements = 0;
        }
        

        public void AddMovement()
        {
            AmountOfMovements++;
        }

        public void RemoveMovement()
        {
            AmountOfMovements--;
        }

        public bool ExistPossibleMovement()
        {
            bool[,] existPossibleMovement = PossibleMovements();
            for (int i = 0; i < existPossibleMovement.GetLength(0); i++)
            {
                for (int j = 0; j < existPossibleMovement.GetLength(1); j++)
                {
                    if (existPossibleMovement[i, j]) return true;
                }
            }
            return false;
        }
        public bool CanMove(Position position)
        {
            Piece piece = Board.PiecePosition(position);
            return piece == null || piece.Color != Color;
        }

        public bool CanMoveFromPosition(Position position)
        {
            return PossibleMovements()[position.X, position.Y];
        }

        public abstract bool[,] PossibleMovements();
    }
}
