namespace MicroserviceTemplate.Managers.Shared
{
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        private Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public TValue? Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("The result was not successful");

        public static implicit operator Result<TValue>(TValue? value) => Create(value);

        private static Result<TValue> Create(TValue? value) => new(value, true, Error.None);

        public static Result<TValue> Success(TValue? value) => new(value, true, Error.None);

        public static Result<TValue> Failure(Error error) => new(default, false, error);
    }
}