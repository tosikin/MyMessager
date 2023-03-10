using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMessager
{
    public class MessangerClientAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Message> GetMessageHTTPAsync(int messageID)
        {
            var responseString = await client.GetStringAsync($"http://localhost:5000/api/Messanger/{messageID}");
            if (responseString != null)
            {
                Message deserilaizedMessage = JsonConvert.DeserializeObject<Message>(responseString);
                return deserilaizedMessage;
            }
            return null;
        }
        public Message GetMessage(int MessageId)
        {
            WebRequest request = WebRequest.Create($"http://localhost:5000/api/Messanger/{MessageId}");
            request.Method = "Get";
            WebResponse response= request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string responseFromServer = streamReader.ReadToEnd();
            streamReader.Close();
            stream.Close();
            response.Close();
            if ((status.ToLower() == "ok") && (responseFromServer != "Not found"))
            {
                Message deserializedMsg = JsonConvert.DeserializeObject<Message>(responseFromServer);
                return deserializedMsg;
            }
            return null;
        }

        public bool SendMessage(Message msg)
        {
            WebRequest request = WebRequest.Create($"http://localhost:5000/api/Messanger/");
            request.Method= "POST";
            string postData = JsonConvert.SerializeObject(msg);
            byte[] array = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = array.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(array, 0, array.Length);
            stream.Close();
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string responseFromServer = streamReader.ReadToEnd();
            streamReader.Close();
            stream.Close();
            response.Close();
            return true;
        }
    }
}
