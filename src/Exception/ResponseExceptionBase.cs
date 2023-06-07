namespace Bubble.Library.Exception
{
    public abstract class ResponseExceptionBase : System.Exception
    {
        public int ErrorCode { get; protected set; }

        protected ResponseExceptionBase()
        {
        }

        protected ResponseExceptionBase(int errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
