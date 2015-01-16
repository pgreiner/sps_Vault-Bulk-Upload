using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BulkAsync
{
    class Program
    {
        #region Request
        private const string _bulkRequest = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <INSERT_BULK_DATA xmlns=""https://www.sagepayments.net/web_services/wsVault/wsVault"">
      <M_ID>299659842982</M_ID>
      <M_KEY>N3H5G9X7Q3Q5</M_KEY>
      <DATA>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
        <string>4111111111111111|1215</string>
        <string>5454545454545454|0817</string>
      </DATA>
    </INSERT_BULK_DATA>
  </soap:Body>
</soap:Envelope>";
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("This program makes ten asynchronous calls of 100.");
            Console.Write("Press a key to begin.");
            Console.ReadLine();
            
            DoBulkRequest();
            
            Console.ReadLine();
            
        }

        static async Task DoBulkRequest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var resp1 = await DoRequest();
            var resp2 = await DoRequest();
            var resp3 = await DoRequest();
            var resp4 = await DoRequest();
            var resp5 = await DoRequest();
            var resp6 = await DoRequest();
            var resp7 = await DoRequest();
            var resp8 = await DoRequest();
            var resp9 = await DoRequest();
            var resp0 = await DoRequest();

            sw.Stop();
            Console.WriteLine("Time elapsed: " + sw.Elapsed.ToString());
        }

        static HttpWebRequest CreateRequest()
        {
            // Create request + headers.
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.sagepayments.net/web_services/wsVault/wsVault.asmx");
            req.ContentType = "text/xml; charset=utf-8";
            req.Headers.Add("SOAPAction", "https://www.sagepayments.net/web_services/wsVault/wsVault/INSERT_BULK_DATA");
            req.Method = "POST";
            // Populate content.
            byte[] reqData = Encoding.UTF8.GetBytes(_bulkRequest);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(reqData, 0, reqData.Length);
            reqStream.Close();

            return req;
        }

        static async Task<WebResponse> GetResponse(HttpWebRequest Request)
        {
            Console.WriteLine("Processing.");
            WebResponse Response = await Request.GetResponseAsync();
            Console.WriteLine("Complete.");
            return Response;
        }

        static async Task<string> DoRequest()
        {
            WebResponse resp = await GetResponse(CreateRequest());
            Stream respStream = resp.GetResponseStream();
            StreamReader respReader = new StreamReader(respStream);

            string response = respReader.ReadToEnd();

            resp.Close();
            respStream.Close();
            respReader.Close();

            return response;
        }
    }
}
