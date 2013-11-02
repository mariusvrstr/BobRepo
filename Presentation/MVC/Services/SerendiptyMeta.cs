using System.Net;
using System.IO;
using JBOB.Serendipty;


namespace JBOB.Services
{
    public class SerendiptyMeta : ISerendiptyMeta
    {
        public string RetrieveMetaData(string input)
        {
            string strURL = "http://5.9.58.73/Serendipity2013/resources/Process";
            HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(strURL);
            //Method type

            string newString =
                string.Format(
                    "systemId=aaa&password=aaaa&text={0}&confidence=0&support=0&contextualScore=0&count=50&sort=true&annotate=false&strict=true",
                    input);

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(newString);


            POSTRequest.Method = "POST";
            // Data type - message body coming in xml
            POSTRequest.MediaType = "application/x-www-form-urlencoded";
            POSTRequest.ContentType = "application/x-www-form-urlencoded";
            //Content length of message body 
            POSTRequest.ContentLength = bytes.Length;

            // Get the request stream
            Stream POSTstream = POSTRequest.GetRequestStream();
            // Write the data bytes in the request stream
            POSTstream.Write(bytes, 0, bytes.Length);

            //Get response from server
            var POSTrespsone = POSTRequest.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(POSTrespsone.GetResponseStream());
            return sr.ReadToEnd().Trim();

        }
    }
}


