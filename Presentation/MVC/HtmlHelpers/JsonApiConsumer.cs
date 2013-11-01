using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace JBOB.Web.HtmlHelpers
{
    public class JsonApiConsumer
    {

        private const string ServerAddress = "http://localhost:1079";
        public const string UserGetAll = ServerAddress + "/api/user";


        public static T GetItem<T>(T item, string url)
        {
           // var request = WebRequest.Create(url);
           // var ws = request.GetResponse();
            
            var client = new WebClient();
            // client.Headers.Add("User-Agent", "Nobody"); //my endpoint needs this...
            var response = client.DownloadString(new Uri(url));
 
            var converted = JsonConvert.DeserializeObject<T>(response);

            return converted;
        }

        public static IEnumerable<T> GetItems<T>(T type, string url)
        {
            // var request = WebRequest.Create(url);
            // var ws = request.GetResponse();

            var client = new WebClient();
            // client.Headers.Add("User-Agent", "Nobody"); //my endpoint needs this...
            var response = client.DownloadString(new Uri(url));

            var converted = JsonConvert.DeserializeObject<List<T>>(response);

            return converted;
        }
    }
}