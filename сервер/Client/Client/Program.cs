using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            socket.Connect("127.0.0.1", 888);
            Console.WriteLine("Введите запрос, который вы хотите послать серверу: ");
            string request = Console.ReadLine();
            byte[] buffer = Encoding.ASCII.GetBytes(request);
            Console.ReadLine();
        }
    }
}
