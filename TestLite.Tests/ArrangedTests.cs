using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestLite.Tests
{
    [TestClass]
    public class ArrangedTests
    {
        [TestMethod]
        public void Act_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged();

            var result = arranged.Act(() => { });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void Act_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged();
            var called = false;

            arranged.Act(() => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void Act_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged();

            var result = arranged.Act(() => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void Act_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged();
            var called = false;

            arranged.Act(() =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged();

            var result = arranged.Act(() => 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged();
            var called = false;

            arranged.Act(() =>
            {
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged();

            var result = arranged.Act<int>(() => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged();
            var called = false;

            arranged.Act<int>(() =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithInput_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string>("input");

            var result = arranged.Act(input => { });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActWithInput_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string>("input");
            var called = false;

            arranged.Act(input => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithInput_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string>("input");

            var result = arranged.Act(input => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActWithInput_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string>("input");
            var called = false;

            arranged.Act(input =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithInputAndReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string>("input");

            var result = arranged.Act(input => 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithInputAndReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string>("input");
            var called = false;

            arranged.Act(input =>
            {
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithInputAndReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string>("input");

            var result = arranged.Act<int>(input => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithInputAndReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string>("input");
            var called = false;

            arranged.Act<int>(input =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }
    }
}