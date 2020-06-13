using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientForWebAPI
{
    interface IWebApiHoster
    {
        HttpClient CallWebApi();

        void GetCallFromURI(HttpClient client);

        void PostCall(HttpClient client);
    }
}
