using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsZap.ImportIO
{
    public class ImportIoApi
    {
        const string BaseUrl = "https://api.import.io";
        const string AuthResource = "_user={userId}&_apikey={appKey}";

        readonly string _userId;
        readonly string _appKey;

        public ImportIoApi(string userId, string appKey)
        {
            _userId = userId;
            _appKey = appKey;
        }

        private RestClient CreateClient(RestRequest request)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);

            request.AddQueryParameter("_user", _userId);
            request.AddQueryParameter("_apikey", _appKey);

            return client;
        }
        protected string Execute(RestRequest request) 
        {
            var client = CreateClient(request);

            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw new ApplicationException(
                    "Error in request", response.ErrorException);
            }
            return response.Content;
        }

        protected Task<string> ExecuteAsync(RestRequest request) 
        {
            var tcs = new TaskCompletionSource<string>();

            var client = CreateClient(request);

            client.ExecuteAsync(request, response => {
                if(response.ErrorException != null)
                {
                    tcs.SetException(new ApplicationException(
                        "Error in request", response.ErrorException));
                } else
                {
                    tcs.SetResult(response.Content);
                }
            });

            return tcs.Task;
        }

        protected T Execute<T>(RestRequest request) where T :new()
        {
            var client = CreateClient(request);

            var response = client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                throw new ApplicationException(
                    "Error in request", response.ErrorException);
            }
            return response.Data;
        }

        protected Task<T> ExecuteAsync<T>(RestRequest request)  where T :new()
        {
            var tcs = new TaskCompletionSource<T>();

            var client = CreateClient(request);

            client.ExecuteAsync<T>(request, response => {
                if (response.ErrorException != null)
                {
                    tcs.SetException(new ApplicationException(
                        "Error in request", response.ErrorException));
                }
                else
                {
                    tcs.SetResult(response.Data);
                }
            });

            return tcs.Task;
        }
    }
}
