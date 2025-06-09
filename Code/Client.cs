using System;
using System.IO;
using System.Net.Sockets;

public class Client
{
   private  TcpClient _client;

   public void ConnectToServer()
   {
      try
      {
         string[] config = File.ReadAllLines("config.txt");
         string serverIP = config[0].Split('=')[1];
         int port = int.Parse(config[1].Split('=')[1]);

         _client = new TcpClient();
         _client.Connect(serverIP, port);
         Console.WriteLine($"Connected to server at {serverIP}:{port}");
      }
      catch (Exception ex)
      {
         Console.WriteLine($"Error connecting to server: {ex.Message}");
      }
   }

   public string SendMessage(string message)
   {
      try
      {
         NetworkStream stream = _client.GetStream();
         using (StreamReader reader = new StreamReader(stream))
         using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
         {
            writer.WriteLine(message); 
            return reader.ReadLine();  
         }
      }
      catch (Exception ex)
      {
         return $"Error: {ex.Message}";
      }
   }

   public void Disconnect()
   {
      _client?.Close();
      Console.WriteLine("Disconnected from server.");
   }
}
