using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueWithPriority
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread myThread = new Thread(ThreadStart(PriorityQueue<T>));
            myThread.Start();
        }
    }
}
