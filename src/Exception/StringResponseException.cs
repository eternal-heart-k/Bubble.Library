namespace Bubble.Library.Exception
{
    public class StringResponseException : ResponseExceptionBase
    {
        public override string Message { get; }

        public StringResponseException(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            Message = errorMessage;
        }

        public StringResponseException(string errorMessage) : this(0, errorMessage)
        {
        }
    }
}
