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
                var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                string response = reader.ReadLine(); // считали то что отправил клиент
                Console.WriteLine(response);
                var writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
                string request = ProsessingRequest(response);
                writer.WriteLine(request);
                writer.Flush();
            }
        }

        //если строка пустая
        //переписать строку как массив
        //посмотреть на первый символ
        // в зависимости 1 или 2 вызвать разные методы
        static string ProsessingRequest(string response) // метод для обработки запроса
        {
            if (response.Length == 0)
            {
                return "Request is empty";
            }

            string[] requestArray = response.Split();

            if (requestArray[0] == "1")
            {
                return ListResponce(response);
            }
            if (requestArray[0] == "2")
            {
                return GetResponce(response);
            }
            else
            {
                return "String is not in a right format.";
            }
        }

        static string ListResponce(string response)
        {
            Console.WriteLine(response);
            var dir = new DirectoryInfo(response);
            string request = "============Список папок и файлов============= ";
            foreach (var item in dir.GetDirectories())
            {
                try
                {
                    request += item.Name + " ";
                }
                catch (Exception)
                {

                }
            }
            foreach (var item in dir.GetFiles())
            {
                try
                {
                    request += item.Name + " ";
                }
                catch (Exception)
                {

                }
            }
            return request;
        }

        static string GetResponce(string responce)
        {
            return responce;
        }
    }
}

