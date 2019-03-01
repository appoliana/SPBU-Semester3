using System;

namespace Lazy
{
    public class MyLazyMulti<T> : ILazy<T>
    {
        private volatile bool calledBefore;
        private T result;
        private Func<T> supplier;
        private Object lockObject = new Object();
        
        public MultiThreadLazy(Func<T> supplier)
        {
            this.supplier = supplier;
        }

        public T Get()
        {
            if (!calledBefore)
            {
                lock (lockObject)
                {
                    if (!calledBefore)
                    {
                        result = supplier();
                        calledBefore = true;
                        supplier = null;
                    }
                }
            }

            return result;
        }
    }
}
    
