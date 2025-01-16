namespace MicroserviceTemplate.Managers.ApiManager
{
    public class ApiRequestSpec
    {
        /// <summary>
        /// Optional. Name of the HttpClient that will be created
        /// ex. "GitHub". Default: ""
        /// </summary>
        public string ClientName { get; }

        /// <summary>
        /// Required. Host of the URL
        /// ex. "http://localhost"
        /// </summary>
        public string Host { get; }

        /// <summary>
        /// Required. Path of the URL
        /// ex. "api/users"
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Optional. Path of the URL
        /// ex. to create URL "api/users?123": path = "api/users", pathVariable = 123
        /// </summary>
        public List<object> PathVariables { get; }

        /// <summary>
        /// Optional. Headers to be added to the request
        /// Format: {header_name, header_value}
        /// ex. {"Authentication", "Bearer Asdasd123="}
        /// </summary>
        public Dictionary<string, string> Headers { get; }

        /// <summary>
        /// Optional. Path of the URL
        /// ex. to create URL "api/users?userId=123": path = "api/users", queryParams = {"userId", 123}
        /// </summary>
        public Dictionary<string, string?> QueryParams { get; }

        /// <summary>
        /// Optional. Request data for 'post' and 'put' requests. Will be converted to JSON
        /// </summary>
        public object? RequestData { get; }

        internal ApiRequestSpec(
            string? clientName,
            string? host,
            string? path,
            List<object>? pathVariables,
            Dictionary<string, string>? headers,
            Dictionary<string, string?>? queryParams,
            object? requestData
        )
        {
            ClientName = clientName ?? "";
            Host = host ?? throw new ArgumentException("Host is undefined");
            Path = path ?? throw new ArgumentException("Path is undefined");
            Headers = headers ?? new Dictionary<string, string>();
            PathVariables = pathVariables ?? new List<object>();
            QueryParams = queryParams ?? new Dictionary<string, string?>();
            RequestData = requestData;
        }

        public bool HasRequestData()
        {
            return RequestData != null;
        }

        public class Builder
        {
            internal string? _clientName;
            internal string? _host;
            internal string? _path;
            internal readonly List<object> _pathVariables = new();
            internal readonly Dictionary<string, string> _headers = new();
            internal readonly Dictionary<string, string?> _queryParams = new();
            internal object? _requestData;

            public Builder ClientName(string? clientName)
            {
                _clientName = clientName;
                return this;
            }

            public Builder Path(string? path)
            {
                _path = path;
                return this;
            }

            public Builder Host(string? host)
            {
                _host = host;
                return this;
            }

            public Builder PathVariables(List<object>? pathVariables)
            {
                if (pathVariables is not null)
                {
                    foreach (var value in pathVariables)
                    {
                        PathVariable(value);
                    }
                }

                return this;
            }

            public Builder PathVariable(object variable)
            {
                _pathVariables.Add(variable);
                return this;
            }

            public Builder Headers(Dictionary<string, string>? headers)
            {
                if (headers is not null)
                {
                    foreach (var (key, value) in headers)
                    {
                        Header(key, value);
                    }
                }

                return this;
            }

            public Builder Header(string headerName, string headerValue)
            {
                _headers.Add(headerName, headerValue);
                return this;
            }

            public Builder QueryParams(Dictionary<string, string?>? queryParams)
            {
                if (queryParams is not null)
                {
                    foreach (var (key, value) in queryParams)
                    {
                        QueryParam(key, value);
                    }
                }

                return this;
            }

            public Builder QueryParam(string paramName, string? paramValue)
            {
                _queryParams.Add(paramName, paramValue);
                return this;
            }

            public Builder RequestData(object? requestData)
            {
                _requestData = requestData;
                return this;
            }

            public ApiRequestSpec Build()
            {
                return new ApiRequestSpec(
                    _clientName, _host, _path, _pathVariables, _headers, _queryParams, _requestData
                );
            }
        }
    }
}