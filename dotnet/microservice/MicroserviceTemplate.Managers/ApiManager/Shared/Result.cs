namespace MicroserviceTemplate.Managers.Shared
{
    public class Result
    {
        public bool IsSuccess { get; }
        public Error Error { get; }

        public bool IsFailure => !IsSuccess;
        public string ErrorMessage => Error.Message;

        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            {
                throw new InvalidOperationException("Can't have both success and errror result");
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);
    }
}