// See https://aka.ms/new-console-template for more information
using MyMessager;
using Newtonsoft.Json;

Message message = new Message("Anton", "Hello", DateTime.UtcNow);
string output = JsonConvert.SerializeObject(message);
Console.WriteLine(output);
Message? deserilazedMes = JsonConvert.DeserializeObject<Message>(output);
Console.WriteLine(deserilazedMes);
//Console.WriteLine(message.ToString());
