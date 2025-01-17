namespace MicroserviceTemplate.Managers.Shared
{
    public class Error : IEquatable<Error>
    {
        public static readonly Error None = new(string.Empty);

        public static Error Of(string message)
        {
            return new Error(message);
        }

        public string Message { get; }

        private Error(string message)
        {
            Message = message;
        }

        public bool Equals(Error? other)
        {
            return other != null && Message.Equals(other.Message);
        }
    }
}