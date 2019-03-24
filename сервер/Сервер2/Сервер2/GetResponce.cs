using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Server
{
    public class GetResponce
    {
        public static int Get(string path, TcpClient client)
        {

            //var localStream = System.IO.File.Create(path);
            //localStream.Read(....) // это можно сделать проще, наверное
            //writer.WriteLine(localStream);
            //FileStream.OpenWrite
            //using FileStream {
            //  File.OpenWrite  }

            var stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            DirectoryInfo dir = new DirectoryInfo(path);
            WebClient wc = new WebClient();
            string responseForClient = "2";

            foreach (var item in dir.GetFiles())
            {
                try
                {
                    responseForClient = wc.DownloadString(path + item.Name);
                    writer.WriteLine(responseForClient);
                    writer.Flush();
                }
                catch (Exception)
                {

                }
            }
            return 0;
        }
    }
}

