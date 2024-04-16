using System;
using Board;

namespace XadrezInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            XadrezBoard board = new XadrezBoard(8, 8);
            Screen.screen(board);
        }
    }
}