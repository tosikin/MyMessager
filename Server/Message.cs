using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessager
{
    [Serializable]
    public class Message
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public DateTime TimeStmap { get; set; }

        public Message()
        {
            UserName = "System";
            MessageText = "Server is running...";
            TimeStmap = DateTime.Now;
        }

        public Message(string userName, string messageText, DateTime timeStmap)
        {
            UserName = userName;
            MessageText = messageText;
            TimeStmap = timeStmap;
        }

        public override string ToString()
        {
            return String.Format("{0} <{1}>: {2}", UserName, TimeStmap, MessageText);
        }
    }
}
