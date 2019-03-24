using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        const int port = 1200;
        static void Main(string[] args)
        {
            // прослушивание порта
            // установить соединение
            // в цикле: 
            // получить запрос
            // обработать запрос
            // отправить ответ

            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("New connection...");
            while (client.Connected) // пока есть подключение
            {
                NetworkStream stream = client.GetStream();
                var reader = new StreamReader(stream);
                string response = reader.ReadLine(); // считали то что отправил клиент
                Console.WriteLine(response);
                var writer = new StreamWriter(stream);
                string request = ProsessingRequest(response);
                writer.WriteLine(request);
                writer.Flush();
            }
        }

        static string ProsessingRequest(string response) // метод для обработки запроса
        {
            return response;
        }
    }
}

