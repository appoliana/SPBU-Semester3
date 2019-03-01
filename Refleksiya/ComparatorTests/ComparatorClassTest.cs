using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace compclass
{
    [TestClass]
    public class ComparatorClassTest
    {
        class A
        {
            private int one;
            public void Foo()
            {

            }
        }

        class C
        {
            public void Foo()
            {

            }
        }

        class B
        {
            public int one;
            public void Foo()
            {

            }

            public void Boo()
            {

            }
        }

        [TestMethod]
        public void ComparatorDifferentClass()
        {
            var listFilds = new List<string>();
            var listMethods = new List<string>();
            listFilds.Add("one");
            listMethods.Add("Boo");
            var test = new ClassComparator();
            var a = typeof(A);
            var b = typeof(B);

            test.GetClasses(a, b);
            test.PrintDiffMethodsAndFields();
            Console.ReadLine();
            
        }

        [TestMethod]
        public void ComparatorEqualClass()
        {
        }
    }
}
