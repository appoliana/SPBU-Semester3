using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lazy.Tests
{
    [TestClass]
    public class LazyFlowTests
    {
        [TestMethod]
        public void OneFlowTest()
        {
            MyLazyMulti<int> f = LazyFactory.CreateMultithreadedLazy(() => 42);
            
            Assert.AreEqual(42, f.Get());
        }

        [TestMethod]
        public void OneFlowTestEqualMeaning()
        {
            var counter = 1;
            Lazy<int> f = LazyFactory.CreateMultithreadedLazy(() => counter++);
            Assert.AreEqual(1, f.Get());
            Assert.AreEqual(1, f.Get());
        }

        [TestMethod]
        public void MultithreadedTest()
        {
            var counter = 1;
            Lazy<int> f = LazyFactory.CreateMultithreadedLazy(() => counter++);

            for (int i = 0; i < 1000; ++i)
            {
                new Thread(Assert.AreEqual(1, f.Get()).Start();
            }
            Thread.Sleep(100);
        }
    }
}
