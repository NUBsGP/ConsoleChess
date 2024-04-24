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
                    try
                    {
                        Console.Clear();
                        Screen.PrintChessMatch(chessMatch);

                        Console.Write("\nEnter origin coordinate of piece: ");
                        Position origin = Screen.ReadPosition().ChessToPosition();
                        chessMatch.ValidatinOriginPosition(origin);

                        bool[,] possiblePositions = chessMatch.Board.PiecePosition(origin).PossibleMovements();

                        Console.Clear();
                        Screen.BoardView(chessMatch.Board, possiblePositions);

                        Console.WriteLine($"\nTurno: {chessMatch.Turn}\n" +
                                          $"Waiting move from: {chessMatch.PlayerColor}");

                        Console.Write("\nEnter destination coordinate of piece: ");
                        Position destination = Screen.ReadPosition().ChessToPosition();

                        chessMatch.ValidatinDestinationPosition(origin, destination);

                        chessMatch.MakeMove(origin, destination);
                    }
                    catch (BoardException exception)
                    {
                        Console.WriteLine($"\nError! {exception.Message}\nPress enter to continue!");
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException exception)
            {
                Console.WriteLine($"\nError! {exception.Message}");
            }
        }
    }
}