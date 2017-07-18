using System;
using System.Runtime.Serialization;

namespace TicTacToe
{
    [Serializable]
    internal class SomethingIsSeriouslyWrongException : Exception
    {
        public SomethingIsSeriouslyWrongException()
        {
        }

        public SomethingIsSeriouslyWrongException(string message) : base(message)
        {
        }

        public SomethingIsSeriouslyWrongException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SomethingIsSeriouslyWrongException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}