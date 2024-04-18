using System;

namespace Board
{
    class BoardException : ApplicationException
    {
        public BoardException(string? message) : base(message)
        {
        }
    }

}
