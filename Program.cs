using System;
using Board;
using XadrezPieces;

namespace XadrezInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XadrezBoard board = new XadrezBoard(8, 8);

                board.SetPiece(new Horse(Color.Black, board), new Position(4, 2));
                board.SetPiece(new King(Color.Black, board), new Position(4, 3));
                board.SetPiece(new Queen(Color.Black, board), new Position(1, 7));
                board.SetPiece(new Rook(Color.Black, board), new Position(4, 1));

                Screen.BoardView(board);
            }
            catch (BoardException exception)
            {
                Console.WriteLine($"Error! {exception.Message}");
            }
        }
    }
}