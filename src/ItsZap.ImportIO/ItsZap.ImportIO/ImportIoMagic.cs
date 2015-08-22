using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsZap.ImportIO
{
    public class ImportIoMagic : ImportIoApi
    {
        const string Resource = "/store/connector/_magic";
        const string ResourceVersion = "/store/connector/_magic/{versionGuid}";

        public ImportIoMagic(string userId,string appKey)
            :base(userId,appKey)
        {

        }

        public string ExecuteQuery(string url, bool js,int infiniteScrollPages,string regionText)
        {
            return default(string);
        }
    }
}
