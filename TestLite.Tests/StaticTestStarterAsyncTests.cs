using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLite.Tests
{
    [TestClass]
    public class StaticTestStarterAsyncTests
    {
        [TestMethod]
        public void ArrangeAsyncWithFunc_ReturnsGenericArrangedClass()
        {
            var called = false;
            var result = Test.ArrangeAsync(async () =>
            {
                await DoSomethingAsync();
                called = true;
                return 1;
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Arranged<int>));
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ArrangeAsyncWithFunc_ReturnsGenericArrangedClassWithOneParameter()
        {
            var called = false;
            var result = Test.ArrangeAsync(async () =>
            {
                await DoSomethingAsync();
                called = true;
                return (1, true);
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Arranged<int, bool>));
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ArrangeAsyncWithFunc_ReturnsGenericArrangedClassWithTwoParameters()
        {
            var called = false;
            var result = Test.ArrangeAsync(async () =>
            {
                await DoSomethingAsync();
                called = true;
                return (1, true, 0.5);
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Arranged<int, bool, double>));
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ArrangeAsyncWithFunc_ReturnsGenericArrangedClassWithThreeParameters()
        {
            var called = false;
            var result = Test.ArrangeAsync(async () =>
            {
                await DoSomethingAsync();
                called = true;
                return (1, true, 0.5, 2m);
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Arranged<int, bool, double, decimal>));
            Assert.IsTrue(called);
        }


        private static Task DoSomethingAsync()
        {
            return Task.Delay(100);
        }
    }
}