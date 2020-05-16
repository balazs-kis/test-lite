using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLite.Tests
{
    [TestClass]
    public class StaticTestStarterTests
    {
        [TestMethod]
        public void NoArrangement_ReturnsNewTypelessArrangedClass()
        {
            var result = Test.Arrange();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Arranged));
        }

        [TestMethod]
        public void ArrangeWithFunc_ReturnsGenericArrangedClass()
        {
            var called = false;
            var result = Test.Arrange(() =>
            {
                called = true;
                return 1;
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Arranged<int>));
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ArrangeWithFunc_ReturnsGenericArrangedClassWithOneParameter()
        {
            var called = false;
            var result = Test.Arrange(() =>
            {
                called = true;
                return (1, true);
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Arranged<int, bool>));
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ArrangeWithFunc_ReturnsGenericArrangedClassWithTwoParameters()
        {
            var called = false;
            var result = Test.Arrange(() =>
            {
                called = true;
                return (1, true, 0.5);
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Arranged<int, bool, double>));
            Assert.IsTrue(called);
        }
    }
}