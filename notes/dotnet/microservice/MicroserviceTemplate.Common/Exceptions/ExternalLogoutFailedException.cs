using System.Runtime.Serialization;

namespace MicroserviceTemplate.Common.Exceptions
{
    public class ExternalLogoutFailedException : Exception
    {
        public ExternalLogoutFailedException()
        {
        }

        public ExternalLogoutFailedException(string message) : base(message)
        {
        }

        public ExternalLogoutFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExternalLogoutFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}