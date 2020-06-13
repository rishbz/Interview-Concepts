using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientForWebAPI
{
    public class SelfHostedWebApi : IWebApiHoster
    {

        public HttpClient CallWebApi()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://localhost:8089");
            return client;
        }

        public void GetCallFromURI(HttpClient client)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("api/product/1").Result;
                var contentFromResponse = this.GetResponseContent(response);
            }
            catch (HttpRequestException ex)
            {

            }
            catch (Exception exc)
            {
                
            }

        }

        public void PostCall(HttpClient client)
        {

        }

        private string GetResponseContent(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var readData = response.Content.ReadAsStringAsync().Result;
                return readData;
            }

            return null;
        }
    }
}
