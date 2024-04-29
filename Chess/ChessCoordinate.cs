using Board;
using System;

namespace Chess
{
    class ChessCoordinate
    {
        public int Lines { get; set; }
        public char Columns { get; set; }

        public ChessCoordinate(char columns, int lines)
        {
            this.Lines = lines;
            this.Columns = columns;
        }
        public Position ChessToPosition()
        {
            return new Position((8 - Lines), (Columns - 'a'));
        }
        public override string ToString()
        {
            return $"{Columns}{Lines}";
        }
    }
}
