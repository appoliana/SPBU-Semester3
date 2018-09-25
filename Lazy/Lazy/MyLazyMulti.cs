using System;

namespace Lazy
{
    public class MyLazyMulti<T> : ILazy<T>
    {
        private Func<T> func;
        private T result;
        private volatile bool hasValue;
        public MyLazyMulti(Func<T> func)
        {
            this.func = func;
            this.hasValue = false;
        }

        static object looker = new object();

        T ILazy<T>.Get()
        {
            if (!this.hasValue)
            {
                lock (looker)
                {
                    if (!this.hasValue)
                    {
                            this.result = this.func();
                            this.hasValue = true;
                    }
                } 
            }
            return this.result;
        }
    }
}
    