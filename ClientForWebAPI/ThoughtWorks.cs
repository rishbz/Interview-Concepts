using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientForWebAPI
{
    public class ThoughtWorks : IWebApiHoster
    {
        public HttpClient CallWebApi()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://http-hunt.thoughtworks-labs.net");
            client.DefaultRequestHeaders.Add("userId", "6ZL0BUpig");
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("rsharma:rocks")));
            return client;
        }

        private int GetStage2Count(string content)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var con = content.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var conLen = con.Length;
            return conLen;
        }

        private void PostForStage2(HttpClient client, int count)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://http-hunt.thoughtworks-labs.net/challenge/output");
            dynamic jsonObject = new JObject();
            jsonObject.wordCount = count;
            var js = jsonObject.ToString();
            request.Content = new StringContent(js,
                                                Encoding.UTF8,
                                                "application/json");//CONTENT-TYPE header

            var res1 = client.SendAsync(request).Result;
        }

        private int GetStage3Count(string content)
        {
            char[] delimiters = new char[] { '.','?' };
            var con = content.Split(delimiters);
            var conLen = con.Length-1;
            return conLen;
        }

        private void PostForStage3(HttpClient client, int count)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://http-hunt.thoughtworks-labs.net/challenge/output");
            dynamic jsonObject = new JObject();
            jsonObject.sentenceCount = count;
            var js = jsonObject.ToString();
            request.Content = new StringContent(js,
                                                Encoding.UTF8,
                                                "application/json");//CONTENT-TYPE header

            var res1 = client.SendAsync(request).Result;
        }

        private dynamic GetStage4Count(string content)
        {
            int[] arr = new int[5]{0,-1,0,0,0};
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == 'a' || content[i] == 'A')
                {
                    arr[0] = arr[0]+1;
                }
                else if (content[i] == 'e' || content[i] == 'E')
                {
                    arr[1] = arr[1]+1;
                }
                else if (content[i] == 'i' || content[i] == 'I')
                {
                    arr[2] = arr[2]+1;
                }
                else if (content[i] == 'O' || content[i] == 'o')
                {
                    arr[3] = arr[3]+1;
                }
                else if (content[i] == 'u' || content[i] == 'U')
                {
                    arr[4] = arr[4]+1;
                }
            }

            dynamic ds = new JObject();
            ds.a = arr[0];
            ds.e = arr[1];
            ds.i = arr[2];
            ds.o = arr[3];
            ds.u = arr[4];

            return ds;
        }

        private void PostForStage4(HttpClient client, dynamic jsonObject)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://http-hunt.thoughtworks-labs.net/challenge/output");
            //dynamic jsonObject = new JObject();
            //jsonObject.sentenceCount = count;
            var js = jsonObject.ToString();
            request.Content = new StringContent(js,
                                                Encoding.UTF8,
                                                "application/json");//CONTENT-TYPE header

            var res1 = client.SendAsync(request).Result;
        }


        private void GetChallenge(HttpClient client)
        {
            var res = client.GetAsync("https://http-hunt.thoughtworks-labs.net/challenge/").Result;
            var contentFromResponse = this.GetResponseContent(res);
        }

        public void GetCallFromURI(System.Net.Http.HttpClient client)
        {
            this.GetChallenge(client);
            var res = client.GetAsync("https://http-hunt.thoughtworks-labs.net/challenge/input").Result;
            var contentFromResponse = this.GetResponseContent(res);
            //var count = contentFromResponse.Count()-11;
            var count = GetStage4Count(contentFromResponse);
            //dynamic jsonObject = new JObject();
            //jsonObject.count = count;
            //var js = jsonObject.ToString();
            PostForStage4(client, count);
#region web
            //HttpWebRequest httpweb = (HttpWebRequest)WebRequest.Create("https://http-hunt.thoughtworks-labs.net/challenge/output");
            //httpweb.Headers.Add("userId", "6ZL0BUpig");
            //httpweb.ContentType = "application/json";
            //httpweb.Method = "POST";
            //using (var stream = new StreamWriter(httpweb.GetRequestStream()))
            //{
            //    var jsn = "[{\"count\":\"" + count + "\"}]";
            //    Debug.Write(jsn);
            //    stream.Write(jsn);
            //    stream.Close();
            //}

            //using (var res13 = httpweb.GetResponse() as HttpWebResponse)
            //{
            //    using (var reader = new StreamReader(res13.GetResponseStream()))
            //    {
            //        var resls = reader.ReadToEnd();
            //    }
            //}

#endregion

            //var jsn = "[{\"count\":\"" + count + "\"}]";


            //var jsin = new object(count,"+count+");

            #region legacy
            //var jsonContent = JsonConvert.SerializeObject(js);
            //StringContent content = new StringContent(js, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = client.PostAsync("/challenge/output", content).Result;
            #endregion

            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
            //request.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
            //                                    Encoding.UTF8,
            //                                    "application/json");//CONTENT-TYPE header

            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://http-hunt.thoughtworks-labs.net/challenge/output");
            //request.Content = new StringContent(js,
            //                                    Encoding.UTF8,
            //                                    "application/json");//CONTENT-TYPE header

            //var res1 = client.SendAsync(request).Result;

            //var res1 = client.SendAsync(request).ContinueWith(responseTask =>
            //{
            //    Console.WriteLine("Response: {0}", responseTask.Result);
            //});

            //Response response = target.request(MediaType.APPLICATION_JSON).header
            //    ("userId", Constants.userID).accept(MediaType.APPLICATION_JSON).post
            //    (Entity.entity(outputObject.toString(), MediaType.APPLICATION_JSON));



             
              
              //      HttpResponseMessage responsecult = client.PostAsync("/challenge/output", request.Content).Result;
             //       var contentFromResp = this.GetResponseContent(res1);
        }

        public void PostCall(System.Net.Http.HttpClient client)
        {
            throw new NotImplementedException();
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
