using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientForWebAPI
{
    public class IISHostedWebApi : IWebApiHoster
    {
        public HttpClient CallWebApi()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://localhost:1326/");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("rsharma:rocks1")));
            return client;
        }

        public void GetCallFromURI(HttpClient client) 
        {
            //HttpResponseMessage response = client.GetAsync("api/values/?CarAge=2&CarName=Mercidez").Result;
            HttpResponseMessage response = client.GetAsync("api/values/tes").Result;
            var contentFromResponse = this.GetResponseContent(response);
        }

        public void PostCall(HttpClient client)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new object { });
            var jsonContent = JsonConvert.SerializeObject(arrayList);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("api/values", content).Result;
            var contentFromResponse = this.GetResponseContent(response);
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
