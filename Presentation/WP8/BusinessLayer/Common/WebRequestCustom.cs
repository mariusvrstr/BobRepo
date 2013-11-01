using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP8.BusinessLayer.Contracts.Gateway;
using JBOB.Cards;
using System.Net;
using WP8.BusinessLayer.Common;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.IO;

namespace WP8.BusinessLayer.Common
{
    public class CustomWebRequest
    {
        public static T WebRequestGet<T>(string methodName)
        {
            T result = default(T);

            try
            {
                if (!Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    throw new Exception("The network is not available");
                }

                ManualResetEvent wait = new ManualResetEvent(false);
                Exception error = null;

                HttpWebRequest request = WebRequest.CreateHttp(Constants.SERVICES_URI + methodName);
                request.AllowAutoRedirect = true;
                request.Method = "GET";
                request.Accept = "application/json";

                request.BeginGetResponse(ar =>
                {
                    HttpWebRequest arrequest = ar.AsyncState as HttpWebRequest;
                    if (arrequest != null)
                    {
                        //TODO: properly check for error responses 40x or 50x status codes, etc.
                        WebResponse response = null;
                        try
                        {
                            response = arrequest.EndGetResponse(ar);

                            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                            result = (T)ser.ReadObject(response.GetResponseStream());
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
                            wait.Set();
                        }
                    }
                }, request);

                wait.WaitOne();

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
        }

        public static T WebRequestPost<T>(string methodName, string body)
        {
            T result = default(T);

            try
            {
                if (!Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    throw new Exception("The network is not available");
                }

                ManualResetEvent wait = new ManualResetEvent(false);

                bool responseReceivedStarted = false;
                Exception error = null;

                HttpWebRequest request = HttpWebRequest.CreateHttp(Constants.SERVICES_URI + methodName);
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "text/json";

                request.BeginGetRequestStream(callback =>
                {

                    HttpWebRequest webRequest = (HttpWebRequest)callback.AsyncState;
                    using (Stream stream = webRequest.EndGetRequestStream(callback))
                    {
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(body);

                        stream.Write(bytes, 0, bytes.Length);
                        stream.Flush();
                        stream.Close();
                    }

                    webRequest.BeginGetResponse(ar =>
                    {
                        responseReceivedStarted = true;
                        HttpWebRequest arrequest = ar.AsyncState as HttpWebRequest;
                        if (arrequest != null)
                        {
                            //TODO: properly check for error responses 40x or 50x status codes, etc.
                            WebResponse response = null;
                            try
                            {
                                response = arrequest.EndGetResponse(ar);

                                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                                result = (T)ser.ReadObject(response.GetResponseStream());
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
                                wait.Set();
                            }
                        }
                    }, request);

                }, request);

                bool timedOut = !wait.WaitOne(Constants.SERVICES_TIMEOUT);

                if (timedOut && !responseReceivedStarted)
                {
                    request.Abort();

                    //request timed out, lets wait right here for timeout exception from handler
                    wait.Reset();
                    //check to see if error has been set already, because the wait.Set could have been fired already
                    //so we don't want to wait.WaitOne if wait.Set was already fired.
                    if (error != null || wait.WaitOne())
                    {
                        throw error;
                    }
                }

                wait.WaitOne();

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
        }
    }
}
