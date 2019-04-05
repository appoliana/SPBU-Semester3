using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void EnqueueThread(MyQueue<int> myq)
        {
            myq.Enqueue(1, 1);
            myq.Enqueue(4, 4);
            myq.Enqueue(3, 3);
            myq.Enqueue(5, 4);
            myq.Enqueue(2, 2);
        }

        public static void DequeueThread(MyQueue<int> myq)
        {
            Console.WriteLine(myq.Dequeue());
            Console.WriteLine(myq.Dequeue());
            Console.WriteLine(myq.Dequeue());
            Console.WriteLine(myq.Dequeue());
            Console.WriteLine(myq.Dequeue());
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            MyQueue<int> myq = new MyQueue<int>();

            Thread t1 = new Thread(delegate () { EnqueueThread(myq); });
            t1.Start();
            Thread t2 = new Thread(delegate () { DequeueThread(myq); });
            t2.Start();
        }
    }
}

