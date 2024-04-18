using System;
using System.Threading.Channels;
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
                ChessMatch chessMatch = new ChessMatch();
                while (!chessMatch.EndMatch)
                {
                    Console.Clear();
                    Screen.BoardView(chessMatch.Board);
                    Console.Write("Enter origin coordinate of piece: ");
                    Position origin = Screen.ReadPosition().ChessToPosition();
                    Console.Write("Enter destination coordinate of piece: ");
                    Position destination = Screen.ReadPosition().ChessToPosition();
                    chessMatch.MovimentPiece(origin, destination);
                }
            }
            catch (BoardException exception)
            {
                Console.WriteLine($"Error! {exception.Message}");
            }
        }
    }
}