using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class MyQueue<T>
    {
        /// <summary>
        /// Лист, в котором будут храниться элементы.
        /// </summary> 
        List<QueueElement<T>> listQueue = new List<QueueElement<T>>();
        private Object lockOn = new Object();
        
        class QueueElement<T>
        {
            public T Value { get; set; }
            public int Priority { get; set; }
        }

        /// <summary>
        /// Метод, который добавляет эдемент в очередь.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="priority"></param>
        public void Enqueue(T value, int priority)
        {
            lock (listQueue)
            {
                QueueElement<T> newElement = new QueueElement<T>
                {
                    Value = value,
                    Priority = priority
                };
                
                if (IsEmpty())
                {
                    listQueue.Add(newElement);
                }
                
                else
                {
                    int index = listQueue.FindIndex(x => (x.Priority >= priority));
                    if (index == -1)
                    {
                        listQueue.Add(newElement);
                    }
                    else
                    {
                        listQueue.Insert(index, newElement);
                    }
                }
                if (listQueue.Count == 1)
                {
                    Monitor.PulseAll(listQueue);
                }
            }
        }

        /// <summary>
        /// Метод, который удаляет элемент с наибольшим приоритетом из очереди.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            lock (listQueue)
            {
                // если очередь пуста, ждем
                while (listQueue.Count() == 0)
                {
                    Monitor.Wait(listQueue);
                }
                T result = listQueue.ElementAt(listQueue.Count() - 1).Value;
                listQueue.RemoveAt(listQueue.Count() - 1);
                return result;
            }
        }

        int Size()
        {
            return listQueue.Count();
        }

        bool IsEmpty()
        {
            return listQueue.Count() == 0;
        }
    }
}