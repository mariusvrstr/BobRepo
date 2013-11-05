using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace JBOB.Web.HtmlHelpers
{
    public class JsonApiConsumer
    {

        public const string BaseUrl = "http://localhost:1079";

        public const string UserGetFull = BaseUrl + "/api/user";
        public const string UserAddPath = "/api/user/Add";
        
        public const string CardGetFull = BaseUrl + "/api/card";
        public const string CardAddPath = "/api/card/Add";
        

        public static T GetItem<T>(string url)
        {
            var client = new WebClient();
            var response = client.DownloadString(new Uri(url));

            var converted = JsonConvert.DeserializeObject<T>(response);

            return converted;
        }

        public static IEnumerable<T> GetItems<T>(string url)
        {
            // var request = WebRequest.Create(url);
            // var ws = request.GetResponse();

            var client = new WebClient();
            // client.Headers.Add("User-Agent", "Nobody"); //my endpoint needs this...
            var response = client.DownloadString(new Uri(url));

            var converted = JsonConvert.DeserializeObject<List<T>>(response);

            return converted;
        }

        public static T PostJsonToApi<T>(T body, string baseUrl, string path)
        {
            var result = default(T);
   
            //handler.Credentials = new NetworkCredential(username, api_key);
            //handler.UseDefaultCredentials = true;
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
    
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
           var response = client.PostAsJsonAsync<T>(path, body).Result;
           var responseContent= response.Content.ReadAsStringAsync().Result;

            //var response = client.PutAsJsonAsync(path, jsnoPost);
            
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<T>(responseContent);
            }
            
            // Need to throw a API failureexception to global ASAX
          
            return result;
        }
    }
}
