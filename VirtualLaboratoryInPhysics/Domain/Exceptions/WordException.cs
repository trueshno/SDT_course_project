using System;

namespace Domain.Exceptions
{
    public class WordException : Exception
    {
        public WordException(string messege) : base(messege) { }
    }
}
