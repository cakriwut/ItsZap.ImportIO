using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsZap.ImportIO
{
    public class ImportIoConnector : ImportIoApi
    {
        const string Resource = "/store/connector/{connectorId}";
        const string ResourceSearch = "/store/connector/_search";
        const string ResourceCount = "/store/connector/_count";

        public ImportIoConnector(string userId,string appKey)
            : base(userId,appKey)
        {

        }

        public string ExecuteSearch(string query)
        {
            var request = new RestRequest(ResourceSearch);
            request.AddQueryParameter("q", query);

            return Execute(request);
        }
    }
}
