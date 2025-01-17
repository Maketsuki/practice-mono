namespace MicroserviceTemplate.Common.Exceptions
{
    /// <summary>
    /// Entity was not valid. ExceptionMiddleware will change this to 400
    /// </summary>
    public class EntityNotValidException : Exception
    {
        public EntityNotValidException()
        {
        }

        public EntityNotValidException(string message)
        : base(message)
        {
        }

        public EntityNotValidException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}