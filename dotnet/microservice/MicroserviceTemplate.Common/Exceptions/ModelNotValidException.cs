namespace MicroserviceTemplate.Common.Exceptions
{
    /// <summary>
    /// Entity was not valid. ExceptionMiddleware will change this to 400
    /// </summary>
    public class ModelNotValidException : Exception
    {
        public ModelNotValidException()
        {
        }

        public ModelNotValidException(string message)
        : base(message)
        {
        }

        public ModelNotValidException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}