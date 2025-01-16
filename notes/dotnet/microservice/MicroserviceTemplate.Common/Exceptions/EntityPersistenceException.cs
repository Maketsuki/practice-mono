namespace MicroserviceTemplate.Common.Exceptions
{
    public class EntityPersistenceException : Exception
    {
        public EntityPersistenceException()
        {
        }

        public EntityPersistenceException(string message)
        : base(message)
        {
        }

        public EntityPersistenceException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}