namespace MicroserviceTemplate.Managers.ApiManager
{
    public class ApiRequestSpec<TReturn> : ApiRequestSpec
    {
        private ApiRequestSpec(string? clientName, string? host, string? path, List<object>? pathVariables,
            Dictionary<string, string>? headers, Dictionary<string, string?>? queryParams, object? requestData)
            : base(clientName, host, path, pathVariables, headers, queryParams, requestData)
        {
        }

        public new class Builder : ApiRequestSpec.Builder
        {
            public new Builder ClientName(string? clientName)
            {
                base.ClientName(clientName);
                return this;
            }

            public new Builder Path(string? path)
            {
                base.Path(path);
                return this;
            }

            public new Builder Host(string? host)
            {
                base.Host(host);
                return this;
            }

            public new Builder PathVariables(List<object>? pathVariables)
            {
                base.PathVariables(pathVariables);
                return this;
            }

            public new Builder PathVariable(object variable)
            {
                base.PathVariable(variable);
                return this;
            }

            public new Builder Headers(Dictionary<string, string>? headers)
            {
                base.Headers(headers);
                return this;
            }

            public new Builder Header(string headerName, string headerValue)
            {
                base.Header(headerName, headerValue);
                return this;
            }

            public new Builder QueryParams(Dictionary<string, string?>? queryParams)
            {
                base.QueryParams(queryParams);
                return this;
            }

            public new Builder QueryParam(string paramName, string? paramValue)
            {
                base.QueryParam(paramName, paramValue);
                return this;
            }

            public new Builder RequestData(object? requestData)
            {
                base.RequestData(requestData);
                return this;
            }

            public new ApiRequestSpec<TReturn> Build()
            {
                return new ApiRequestSpec<TReturn>(
                    _clientName, _host, _path, _pathVariables, _headers, _queryParams, _requestData
                );
            }
        }
    }
}