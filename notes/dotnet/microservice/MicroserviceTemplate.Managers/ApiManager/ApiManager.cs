using MicroserviceTemplate.Managers.Shared;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace MicroserviceTemplate.Managers.ApiManager
{
    public class ApiManager : IApiManager
    {
        private readonly ILogger<ApiManager> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiManager(ILogger<ApiManager> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Result> Post(ApiRequestSpec requestSpec)
        {
            HttpResponseMessage responseMessage = await SendRequest(requestSpec, HttpMethod.Post);
            return await ParseResponse(responseMessage.RequestMessage?.RequestUri, responseMessage);
        }

        public async Task<Result<T>> Post<T>(ApiRequestSpec<T> requestSpec)
        {
            HttpResponseMessage responseMessage = await SendRequest(requestSpec, HttpMethod.Post);
            return await ParseResponse<T>(responseMessage.RequestMessage?.RequestUri, responseMessage);
        }

        public async Task<Result> Put(ApiRequestSpec requestSpec)
        {
            HttpResponseMessage responseMessage = await SendRequest(requestSpec, HttpMethod.Put);
            return await ParseResponse(responseMessage.RequestMessage?.RequestUri, responseMessage);
        }

        public async Task<Result<T>> Put<T>(ApiRequestSpec<T> requestSpec)
        {
            HttpResponseMessage responseMessage = await SendRequest(requestSpec, HttpMethod.Put);
            return await ParseResponse<T>(responseMessage.RequestMessage?.RequestUri, responseMessage);
        }

        public async Task<Result<T>> Get<T>(ApiRequestSpec<T> requestSpec)
        {
            HttpResponseMessage responseMessage = await SendRequest(requestSpec, HttpMethod.Get);
            return await ParseResponse<T>(responseMessage.RequestMessage?.RequestUri, responseMessage);
        }

        public async Task<Result<Stream>> Get(ApiRequestSpec<Stream> requestSpec)
        {
            HttpResponseMessage responseMessage = await SendRequest(requestSpec, HttpMethod.Get);
            return await ParseResponseAsStream(responseMessage.RequestMessage?.RequestUri, responseMessage);
        }

        public async Task<Result> Delete(ApiRequestSpec requestSpec)
        {
            HttpResponseMessage responseMessage = await SendRequest(requestSpec, HttpMethod.Delete);
            return await ParseResponse(responseMessage.RequestMessage?.RequestUri, responseMessage);
        }

        public async Task<Result<T>> Delete<T>(ApiRequestSpec<T> requestSpec)
        {
            HttpResponseMessage responseMessage = await SendRequest(requestSpec, HttpMethod.Delete);
            return await ParseResponse<T>(responseMessage.RequestMessage?.RequestUri, responseMessage);
        }

        private async Task<HttpResponseMessage> SendRequest(ApiRequestSpec requestSpec, HttpMethod httpMethod)
        {
            HttpClient httpClient = ConfigureClient(requestSpec);
            Uri uri = BuildRequestUri(requestSpec);

            // add request headers
            var request = new HttpRequestMessage(httpMethod, uri);
            foreach (var (key, value) in requestSpec.Headers)
            {
                request.Headers.Add(key, value);
            }

            // add request content if any
            if (requestSpec.HasRequestData())
            {
                JsonContent content = JsonContent.Create(requestSpec.RequestData);
                request.Content = content;
            }

            return await httpClient.SendAsync(request);
        }

        private HttpClient ConfigureClient(ApiRequestSpec requestSpec)
        {
            var client = _httpClientFactory.CreateClient(requestSpec.ClientName);

            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private Uri BuildRequestUri(ApiRequestSpec requestSpec)
        {
            var uriBuilder = new UriBuilder(requestSpec.Host);
            uriBuilder.Path = requestSpec.Path;

            // add path variables if any
            foreach (var value in requestSpec.PathVariables)
            {
                uriBuilder.Path += "/" + value;
            }

            // add query parameters if any
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            Dictionary<string, string?> requestParams = requestSpec.QueryParams;
            foreach (var (key, value) in requestParams)
            {
                query.Add(key, value);
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        private Task<Result> ParseResponse(Uri? uri, HttpResponseMessage responseMessage)
        {
            try
            {
                responseMessage.EnsureSuccessStatusCode();
                return Task.FromResult(Result.Success());
            }
            catch (Exception exception)
            {
                _logger.LogError("Request to '{0}' failed with message: '{1}'", uri, exception.Message);
                return Task.FromResult(Result.Failure(Error.Of(exception.Message)));
            }
        }

        private async Task<Result<T>> ParseResponse<T>(Uri? uri, HttpResponseMessage responseMessage)
        {
            try
            {
                responseMessage.EnsureSuccessStatusCode();
                T? response = await responseMessage.Content.ReadFromJsonAsync<T>();
                if (response is null)
                {
                    throw new Exception("Response is null");
                }
                return Result<T>.Success(response);
            }
            catch (Exception exception)
            {
                _logger.LogError("Request to '{0}' failed with message: '{1}'", uri, exception.Message);
                return Result<T>.Failure(Error.Of(exception.Message));
            }
        }

        private async Task<Result<Stream>> ParseResponseAsStream(Uri? uri, HttpResponseMessage responseMessage)
        {
            try
            {
                responseMessage.EnsureSuccessStatusCode();
                Stream response = await responseMessage.Content.ReadAsStreamAsync();
                return Result<Stream>.Success(response);
            }
            catch (Exception exception)
            {
                _logger.LogError("Request to '{0}' failed with message: '{1}'", uri, exception.Message);
                return Result<Stream>.Failure(Error.Of(exception.Message));
            }
        }
    }
}