using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsZap.ImportIO
{
    public class ImportIoQuery : ImportIoApi
    {
        const string Resource = "/store/connector/{connectorId}/_query";

        public string ConnectorID { get; set; }
        public string Format { get; set; }
        public string Page { get; set; }
        public string Version { get; set; }
        public string Input { get; set; }

        public ImportIoQuery(string userId,string appKey,string connectorId)
            :base(userId,appKey)
        {
            ConnectorID = connectorId;
        }

        public string GetResult(string input)  
        {
            return GetResult(input, null);
        }

        public string GetResult(string input,string page)  
        {
            var request = new RestRequest(Resource);
            request.AddParameter("connectorId", ConnectorID, ParameterType.UrlSegment);

            if (!String.IsNullOrEmpty(input))
                request.AddQueryParameter("input", input);

            if (!String.IsNullOrEmpty(page))
                request.AddQueryParameter("page", page);

            return Execute(request);
        }

    }
}
