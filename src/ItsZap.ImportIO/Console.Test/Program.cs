using ItsZap.ImportIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetUrl = "http://www.channelnewsasia.com/news/singapore/sg50-notes-set-packaging/2066232.html";

            var x = new ImportIoQuery(user, api, connector);
            var result = x.GetResult(String.Format("webpage/url:{0}",targetUrl));

            System.Console.WriteLine(result);
            System.Console.ReadLine();
          
        }
    }
}
