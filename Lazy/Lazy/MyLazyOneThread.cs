using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy
{
    public class MyLazyOneThread<T> : ILazy<T>
    {
        private Func<T> func;
        private T result;
        private bool hasValue;
        public MyLazyOneThread(Func<T> func)
        {
            this.func = func;
            this.hasValue = false;
        }

        T ILazy<T>.Get()
        {
            if (!this.hasValue)
            {
                    if (!this.hasValue)
                    {
                        this.result = this.func();
                        this.hasValue = true;
                    }
            }
            return this.result;
        }
    }
}
