using ItsZap.ImportIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connector = "8d282584-173e-4ee9-af60-0b27bb62b666";

            var user = "be5cf0f9-b3dc-4727-a601-d605b6edfe38";
            var api = "be5cf0f9b3dc4727a601d605b6edfe382d2907dc992c71b992f828f0598291439363a03855e9f1ca521b49193ad8c241e148a96672572d95d7b87f08d07944849c84f665cacb5a91805bfe6cb626cac0";

            var targetUrl = "http://www.channelnewsasia.com/news/singapore/sg50-notes-set-packaging/2066232.html";
            targetUrl = "http://www.channelnewsasia.com/news/singapore/ng-chee-meng-sun-xueling/2067294.html";

            //var x = new ImportIoQuery(user, api, connector);
            //var result = x.ExecuteQueryAsync(String.Format("webpage/url:{0}",targetUrl));

            var x = new ImportIoConnector(user, api);
            var result = x.ExecuteSearchAsync("name:channelnewsasia.com").ContinueWith(retVal =>
            {
                dynamic returnValue = Newtonsoft.Json.Linq.JObject.Parse(retVal.Result);
                if(returnValue.hits.total >= 1)
                {
                    string conID = returnValue.hits.hits[0]._id;
                    var p = new ImportIoQuery(user, api, conID);
                    p.ExecuteQueryAsync(String.Format("webpage/url:{0}", targetUrl)).ContinueWith(show =>
                    {
                        Console.WriteLine(show.Result);
                    });
                } 

            });

            Console.WriteLine("Waiting for query");
            Console.ReadLine();
          
        }
    }
}
