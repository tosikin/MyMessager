// See https://aka.ms/new-console-template for more information
using MyMessager;
using Newtonsoft.Json;

int MessageId;
string UserName;
MessangerClientAPI API = new MessangerClientAPI();

 void GetNewMessages()
{
    Message msg = API.GetMessage(MessageId);
    while (msg != null)
    {
        Console.WriteLine(msg);
        MessageId++;
        msg = API.GetMessage(MessageId);
    }

}
MessageId = 1;
Console.WriteLine("Ener your Name.");
UserName = Console.ReadLine();
string msgText = "";
while (msgText != "exit")
{
    Thread thread = new Thread(new ThreadStart(GetNewMessages));
    thread.Start();
    msgText = Console.ReadLine();
    if( !string.IsNullOrEmpty(msgText))
    {
        Message message = new Message(UserName, msgText, DateTime.Now);
        API.SendMessage(message);
    }
}

//Message message = new Message("Anton", "Hello", DateTime.UtcNow);
//string output = JsonConvert.SerializeObject(message);
//Console.WriteLine(output);
//Message? deserilazedMes = JsonConvert.DeserializeObject<Message>(output);
//Console.WriteLine(deserilazedMes);
//Console.WriteLine(message.ToString());
