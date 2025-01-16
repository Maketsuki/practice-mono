namespace MicroserviceTemplate.Common.Exceptions
{
    /// <summary>
    /// Entity was found when should have not. Will return status code 422 from ExceptionMiddleware.
    /// </summary>
    public class EntityIdentityOverlapException : Exception
    {
        public EntityIdentityOverlapException()
        {
        }

        public EntityIdentityOverlapException(string message)
        : base(message)
        {
        }

        public EntityIdentityOverlapException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}