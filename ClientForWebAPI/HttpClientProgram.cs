using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientForWebAPI
{
    class HttpClientProgram
    {
        static void Main(string[] args)
        {
            IWebApiHoster thought = new ThoughtWorks();
            var cl = thought.CallWebApi();
            thought.GetCallFromURI(cl);

            IWebApiHoster iisHosted = new IISHostedWebApi();
            var client = iisHosted.CallWebApi();
            iisHosted.GetCallFromURI(client);
            iisHosted.PostCall(client);

            IWebApiHoster selfHosted = new SelfHostedWebApi();
            var selfClient = selfHosted.CallWebApi();
            selfHosted.GetCallFromURI(selfClient);
        }
    }
}
