using System;
using System.Linq;
using System.Threading;

namespace Lazy
{
    public class LazyFactory
    {
        public static MyLazyMulti<T> CreateMultithreadedLazy<T>(Func<T> supplier)  //многопоточный Lazy
        {
            // MyLazyMulti<T> newObject = new MyLazyMulti<T>(supplier);
            return new MyLazyMulti<T>(supplier);
        }

        public static MyLazyOneThread<T> CreateSingleFlowLazy<T>(Func<T> supplier) //однопоточный Lazy
        {
            return new MyLazyOneThread<T>(supplier);
        }
    }
}
    

