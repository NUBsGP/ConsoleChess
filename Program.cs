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

                board.SetPiece(new Rook(Color.White, board), new ChessCoordinate('a', 8).ChessToPosition());
                board.SetPiece(new Horse(Color.White, board), new ChessCoordinate('b', 8).ChessToPosition());
                board.SetPiece(new Bishop(Color.White, board), new ChessCoordinate('c', 8).ChessToPosition());
                board.SetPiece(new King(Color.White, board), new ChessCoordinate('d', 8).ChessToPosition());
                board.SetPiece(new Queen(Color.White, board), new ChessCoordinate('e', 8).ChessToPosition());
                board.SetPiece(new Bishop(Color.White, board), new ChessCoordinate('f', 8).ChessToPosition());
                board.SetPiece(new Horse(Color.White, board), new ChessCoordinate('g', 8).ChessToPosition());
                board.SetPiece(new Rook(Color.White, board), new ChessCoordinate('h', 8).ChessToPosition());
                
                board.SetPiece(new Pawn(Color.White, board), new ChessCoordinate('a', 7).ChessToPosition());
                board.SetPiece(new Pawn(Color.White, board), new ChessCoordinate('b', 7).ChessToPosition());
                board.SetPiece(new Pawn(Color.White, board), new ChessCoordinate('c', 7).ChessToPosition());
                board.SetPiece(new Pawn(Color.White, board), new ChessCoordinate('d', 7).ChessToPosition());
                board.SetPiece(new Pawn(Color.White, board), new ChessCoordinate('e', 7).ChessToPosition());
                board.SetPiece(new Pawn(Color.White, board), new ChessCoordinate('f', 7).ChessToPosition());
                board.SetPiece(new Pawn(Color.White, board), new ChessCoordinate('g', 7).ChessToPosition());
                board.SetPiece(new Pawn(Color.White, board), new ChessCoordinate('h', 7).ChessToPosition());
                
                
                
                board.SetPiece(new Rook(Color.Black, board), new ChessCoordinate('a', 1).ChessToPosition());
                board.SetPiece(new Horse(Color.Black, board), new ChessCoordinate('b', 1).ChessToPosition());
                board.SetPiece(new Bishop(Color.Black, board), new ChessCoordinate('c', 1).ChessToPosition());
                board.SetPiece(new King(Color.Black, board), new ChessCoordinate('d', 1).ChessToPosition());
                board.SetPiece(new Queen(Color.Black, board), new ChessCoordinate('e', 1).ChessToPosition());
                board.SetPiece(new Bishop(Color.Black, board), new ChessCoordinate('f', 1).ChessToPosition());
                board.SetPiece(new Horse(Color.Black, board), new ChessCoordinate('g', 1).ChessToPosition());
                board.SetPiece(new Rook(Color.Black, board), new ChessCoordinate('h', 1).ChessToPosition());
                
                board.SetPiece(new Pawn(Color.Black, board), new ChessCoordinate('a', 2).ChessToPosition());
                board.SetPiece(new Pawn(Color.Black, board), new ChessCoordinate('b', 2).ChessToPosition());
                board.SetPiece(new Pawn(Color.Black, board), new ChessCoordinate('c', 2).ChessToPosition());
                board.SetPiece(new Pawn(Color.Black, board), new ChessCoordinate('d', 2).ChessToPosition());
                board.SetPiece(new Pawn(Color.Black, board), new ChessCoordinate('e', 2).ChessToPosition());
                board.SetPiece(new Pawn(Color.Black, board), new ChessCoordinate('f', 2).ChessToPosition());
                board.SetPiece(new Pawn(Color.Black, board), new ChessCoordinate('g', 2).ChessToPosition());
                board.SetPiece(new Pawn(Color.Black, board), new ChessCoordinate('h', 2).ChessToPosition());

                Screen.BoardView(board);
            }
            catch (BoardException exception)
            {
                Console.WriteLine($"Error! {exception.Message}");
            }
        }
    }
}