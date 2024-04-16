using Board;

namespace XadrezInConsole
{
    class Screen
    {
        public static void BoardView(XadrezBoard board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.PiecePosition(i, j) != null)
                    {
                        if (j != board.Columns - 1)
                        {
                            Console.Write($"{board.PiecePosition(i, j)}  ");
                        }
                        else Console.WriteLine($"{board.PiecePosition(i, j)}");
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
        }
    }
}
