using System;
using System.Collections.Generic;
using System.Reflection;

namespace compclass
{
    class A
    {
        public int one;
        public int two;
        public void Foo()
        {

        }
    }

    class B
    {
        public string one;
        private int two;

        public void Foo()
        {

        }

        public void Boo()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new ClassComparator();
            var a = typeof(A);
            var b = typeof(B);

            test.GetClasses(a, b);
            test.PrintDiffMethodsAndFields();
            Console.ReadLine();
        }
    }
}