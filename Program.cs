using System;
using Board;
using Chess;

namespace ChessInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessBoard board = new ChessBoard(8, 8);

                board.SetPiece(new Horse(Color.Black, board), new ChessCoordinate('b', 1).ChessToPosition());

                Screen.BoardView(board);
            }
            catch (BoardException exception)
            {
                Console.WriteLine($"Error! {exception.Message}");
            }
        }
    }
}