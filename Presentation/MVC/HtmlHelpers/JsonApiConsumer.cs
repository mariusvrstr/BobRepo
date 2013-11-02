using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace JBOB.Web.HtmlHelpers
{
    public class JsonApiConsumer
    {

        private const string ServerAddress = "http://localhost:1079";
        public const string UserGetAll = ServerAddress + "/api/user";
        public const string UserAdd = ServerAddress + "/api/user/Add";


       /*  public static T GetItemWithPost<T>(T item, string url, NameValueCollection @params)
        {
            var client = new WebClient();

            byte[] result = client.UploadValues(url, @params);

            var json = Encoding.ASCII.GetString(result);

            var converted = JsonConvert.DeserializeObject<T>(json);

            return converted;
        } */


        public static T GetItem<T>(string url)
        {
            // var request = WebRequest.Create(url);
            // var ws = request.GetResponse();

            var client = new WebClient();
            // client.Headers.Add("User-Agent", "Nobody"); //my endpoint needs this...

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

        public static T GetItemWithPost<T>(T body, string url)
        {
            var result = default(T);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(body);
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                var objText = streamReader.ReadToEnd();
                result = JsonConvert.DeserializeObject<T>(objText);
            }
          
            return result;
        }





        /*
        public static T GetItemWithPost<T>(string body, string url)
        {
            T result = default(T);

            try
            {
                Exception error = null;

                var request = HttpWebRequest.CreateHttp(url);
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "text/json";

                request.BeginGetRequestStream(callback =>
                {

                    var webRequest = new HttpWebRequest();
                    using (var stream = webRequest.EndGetRequestStream(callback))
                    {
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(body);

                        stream.Write(bytes, 0, bytes.Length);
                        stream.Flush();
                        stream.Close();
                    }










                    webRequest.BeginGetResponse(ar =>
                    {
                        var arrequest = ar.AsyncState as HttpWebRequest;
                        if (arrequest != null)
                        {
                            WebResponse response = null;
                            try
                            {
                                response = arrequest.EndGetResponse(ar);
   
                                // Read the response into a Stream object.
                                var responseStream = response.GetResponseStream();

                                if (responseStream != null)
                                {
                                    using (var reader = new StreamReader(responseStream)) {
                                        var objText = reader.ReadToEnd();
                                        result = JsonConvert.DeserializeObject<T>(objText);
                                    }
                                }
                                
                            }
                            catch (WebException ex)
                            {
                                if (ex.Status == WebExceptionStatus.RequestCanceled)
                                {
                                    error = new WebException("HttpWebRequest timed out", ex);
                                }
                                else
                                {
                                    error = ex;
                                }
                            }
                            catch (Exception ex)
                            {
                                error = ex;
                            }
                            finally
                            {
                                if (response != null)
                                {
                                    response.Close();
                                }
                            }
                        }
                    }, request);

                }, request);


                if (error != null)
                {
                    throw error;
                }

                if (result == null)
                {
                    throw new WebException("Web request did not return any response");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error during WebRequest", ex);
            }
        } */
    }
}
