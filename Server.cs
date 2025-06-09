using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Server
{
   private TcpListener _listener;

   public void StartServer()
   {
      try
      {
         string[] config = File.ReadAllLines("config.txt");
         string serverIP = config[0].Split('=')[1];
         int port = int.Parse(config[1].Split('=')[1]);

         _listener = new TcpListener(IPAddress.Parse(serverIP), port);
         _listener.Start();
         Console.WriteLine($"Server started on {serverIP}:{port}...");

         while (true)
         {
            TcpClient client = _listener.AcceptTcpClient();
            Console.WriteLine("Client connected.");

            System.Threading.Thread thread = new System.Threading.Thread(() => HandleClient(client));
            thread.Start();
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine($"Error starting server: {ex.Message}");
      }
   }

   private void HandleClient(TcpClient client)
   {
      try
      {
         NetworkStream stream = client.GetStream();
         using (StreamReader reader = new StreamReader(stream))
         using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
         {
            string message = reader.ReadLine();
            Console.WriteLine($"Received: {message}");

            writer.WriteLine($"Server received: {message}");
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine($"Error handling client: {ex.Message}");
      }
   }

   public void StopServer()
   {
      _listener?.Stop();
      Console.WriteLine("Server stopped.");
   }
}