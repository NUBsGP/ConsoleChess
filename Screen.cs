using Board;
using Chess;

namespace ChessInConsole
{
    class Screen
    {
        public static void PrintChessMatch(ChessMatch chessMatch)
        {
            BoardView(chessMatch.Board);
            Console.WriteLine();
            PrintCapturedPieces(chessMatch);

            Console.WriteLine($"\nTurno: {chessMatch.Turn}\n" +
                              $"Waiting move from: {chessMatch.PlayerColor}");
        }

        private static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine($"Captured Pieces:");
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"White: [");
            List<Piece> pieces = chessMatch.ColorCapturedPieces(Color.White).ToList();
            for (int i = 0; i < pieces.Count; i++)
            {
                if (i != pieces.Count - 1) Console.Write($"{pieces[i]} ");
                else Console.Write(pieces[i]);
            }
            Console.WriteLine("]");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Black: [");
            pieces = chessMatch.ColorCapturedPieces(Color.Black).ToList();
            for (int i = 0; i < pieces.Count; i++)
            {
                if (i != pieces.Count - 1) Console.Write($"{pieces[i]} ");
                else Console.Write(pieces[i]);
            }
            Console.WriteLine("]");
            Console.ForegroundColor = consoleColor;
        }
        public static void BoardView(ChessBoard board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Columns; j++)
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

            }
            Console.Write("  ");
            for (int i = 0; i < board.Columns; i++)
            {
                if (i != board.Columns - 1) Console.Write($"{(char)('a' + i)}  ");
                else Console.WriteLine($"{(char)('a' + i)}");
            }

        }
        public static void BoardView(ChessBoard board, bool[,] possibleMovements)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMovements[i, j]) Console.BackgroundColor = ConsoleColor.DarkGray;
                    if (j != board.Columns - 1)
                    {
                        PiecePrint(board.PiecePosition(i, j));
                        Console.BackgroundColor = originalBackground;
                        Console.Write("  ");
                    }
                    else
                    {
                        PiecePrint(board.PiecePosition(i, j));
                        Console.BackgroundColor = originalBackground;
                        Console.WriteLine();
                    }

                }

            }
            Console.Write("  ");
            for (int i = 0; i < board.Columns; i++)
            {
                if (i != board.Columns - 1) Console.Write($"{(char)('a' + i)}  ");
                else Console.WriteLine($"{(char)('a' + i)}");
            }

        }

        public static ChessCoordinate ReadPosition()
        {
            string imput = Console.ReadLine();
            char line = imput[0];
            int column = int.Parse(imput[1] + "");
            return new ChessCoordinate(line, column);
        }

        public static void PiecePrint(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("-");
            }
            else if (piece.Color == Color.White)
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
