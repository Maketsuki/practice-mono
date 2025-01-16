using MicroserviceTemplate.Managers.Shared;

namespace MicroserviceTemplate.Managers.ApiManager
{
    public interface IApiManager
    {
        Task<Result> Post(ApiRequestSpec requestSpec);

        Task<Result<T>> Post<T>(ApiRequestSpec<T> requestSpec);

        Task<Result> Put(ApiRequestSpec requestSpec);

        Task<Result<T>> Put<T>(ApiRequestSpec<T> requestSpec);

        Task<Result<T>> Get<T>(ApiRequestSpec<T> requestSpec);

        Task<Result<Stream>> Get(ApiRequestSpec<Stream> requestSpec);

        Task<Result> Delete(ApiRequestSpec requestSpec);

        Task<Result<T>> Delete<T>(ApiRequestSpec<T> requestSpec);
    }
}