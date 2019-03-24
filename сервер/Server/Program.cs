using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    class Program
    {
        //static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            /*socket.Bind(new IPEndPoint(IPAddress.Any, 1200));
            socket.Listen(5);
            Socket client = socket.Accept();
            Console.WriteLine("Новое подключение...");
            byte[] buffer = new byte[1024];
            client.Receive(buffer);*/

            TcpListener listener = new TcpListener(IPAddress.Any, 1200);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Новое подключение...");

            var stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            string msg = reader.ReadLine();


            Console.WriteLine(msg);//Encoding.ASCII.GetString(buffer));
            Console.WriteLine();

            if (string.IsNullOrEmpty(msg))//Encoding.ASCII.GetString(buffer)))
            {
                Console.WriteLine("Строка пустая.");
            }
            string[] msg1 = msg.Split(' ');//Encoding.ASCII.GetString(buffer).Split(' ');

            if (msg1[0] == "1")
            {
                string responce = msg.Remove(0, 2);
                Console.WriteLine(responce);
                ListResponce.List(responce, client);
            }
            if (msg1[0] == "2")
            {
                string responce = msg1.ToString().Remove(0, 2);
                GetResponce.Get(responce, client);
            }
            else
            {
                Console.WriteLine("Строка передана в неправильном формате.");
            }
            client.Close();
        }
    }
}
