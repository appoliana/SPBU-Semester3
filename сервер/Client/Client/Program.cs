using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        const int port = 1200;
        static void Main(string[] args)
        {
            //создать подключение
            //    в цикле
            //    (отправляю запрос
            //    получаю ответ)
            //    выход 
            
            using (var client = new TcpClient("localhost", port))
            {
                Console.WriteLine("Hellow! If you want to see files send 1 and then parth, if you wand to download files right 2 and then parth, for exit right Exit.");
                NetworkStream stream = client.GetStream();
                var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                var writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
                var message = Console.ReadLine();
                while (message != "Exit")
                {
                    //byte[] messageArray = Encoding.Default.GetBytes(message);
                    writer.WriteLine(message);
                    writer.Flush();
                    string data = reader.ReadLine();
                    Console.WriteLine(data);
                    message = Console.ReadLine();
                }
            }
        }
    }
}
