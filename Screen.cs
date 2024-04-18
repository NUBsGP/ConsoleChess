using Board;

namespace ChessInConsole
{
    class Screen
    {
        public static void BoardView(ChessBoard board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8-i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.PiecePosition(i, j) != null)
                    {
                        if (j != board.Columns - 1)
                        {
                            PiecePrint(board.PiecePosition(i, j)); 
                            Console.Write("  ");
                        }
                        else
                        {
                            PiecePrint(board.PiecePosition(i, j));
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        if (j != board.Columns - 1)
                        {
                            Console.Write("-  ");
                        }
                        else Console.WriteLine($"-");
                    }
                }
                
            }
            Console.Write("  ");
            for (int i = 0; i < board.Columns; i++)
            {
                if (i != board.Columns - 1) Console.Write($"{(char) ('a' + i)}  ");
                else Console.WriteLine($"{(char)('a' + i)}");
            }
            
        }

        public static void PiecePrint(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
            else
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
        }
    }
}
