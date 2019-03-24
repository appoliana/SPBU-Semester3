using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    /// <summary>
    /// Класс, который отвечает за сервер.
    /// </summary>
    class Program
    {
        const int port = 1200;
        /// <summary>
        /// Метод, который прослушивает подключения и принимает их.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("New connection...");
            while (client.Connected) 
            {
                NetworkStream stream = client.GetStream();
                var reader = new StreamReader(stream, System.Text.Encoding.Unicode);
                string response = reader.ReadLine(); 
                Console.WriteLine(response);
                var writer = new StreamWriter(stream, System.Text.Encoding.Unicode);
                string request = ProsessingRequest(response);
                writer.WriteLine(request);
                writer.Flush();
            }
        }

        /// <summary>
        /// Метод, который обрабатывает запрос.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        static string ProsessingRequest(string response)
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

        /// <summary>
        /// Метод, который возвращает список файлов и папок по указанному пути.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        static string ListResponce(string response)
        {
            Console.WriteLine(response);
            var dir = new DirectoryInfo(response.Remove(0, 2));
            string request = "============List of files and folders============= ";
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

        /// <summary>
        /// Метод, который возвращает содержимое файла по указанному пути.
        /// </summary>
        /// <param name="responce"></param>
        /// <returns></returns>
        static string GetResponce(string responce)
        {
            using (StreamReader str = new StreamReader(responce.Remove(0, 2)))
            {
                string request = "The contaning of our file: " + str.ReadToEnd() ;
                return request;
            }
        }
    }
}
