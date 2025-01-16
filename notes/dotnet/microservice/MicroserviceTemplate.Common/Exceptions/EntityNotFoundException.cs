namespace MicroserviceTemplate.Common.Exceptions
{
    /// <summary>
    /// Entity was not found. ExceptionMiddleware will change the code to 404
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message)
        : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}