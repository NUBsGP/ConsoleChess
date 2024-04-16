
namespace XadrezInConsole.Board
{
    
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Piece { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Piece = new Piece[Lines, Columns];
        }
    }
}
