using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Request
    {

    }
}

/*private TcpListener listener;

bool running = false;

public HTTPServer(int port)
{
    listener = new TcpListener(IPAddress.Any, port);
}

public void Start()
{
    Thread thread = new Thread(new ThreadStart(Run));
    thread.Start();
}

private void Run()
{
    listener.Start();
    running = true;

    Console.WriteLine("Server is working...");

    while (true)
    {
        Console.WriteLine("Waiting client...");

        TcpClient client = listener.AcceptTcpClient();

        Console.WriteLine("Client was connected.");

        HandleClient(client);
        client.Close();
    }
}

private void HandleClient(TcpClient client)
{
    StreamReader reader = new StreamReader(client.GetStream());
    string msg = " ";
    string humanRequest = "1 C:/ ";

    while (reader.Peek() != -1)
    {
        msg += reader.ReadLine() + "\n";
    }

    Console.WriteLine("Request: \r\n {0}", msg);

    Request request = Request.GetRequest(msg, humanRequest);
}
        
    }
    */