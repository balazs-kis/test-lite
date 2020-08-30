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

        [TestMethod]
        public void ActWithTwoInputs_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int>("input", 1);

            var result = arranged.Act((input, parameter) => { });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActWithTwoInputs_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int>("input", 1);
            var called = false;

            arranged.Act((input, parameter) => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithTwoInputs_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int>("input", 1);

            var result = arranged.Act((input, parameter) => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActWithTwoInputs_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int>("input", 1);
            var called = false;

            arranged.Act((input, parameter) =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithTwoInputsAndReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int>("input", 1);

            var result = arranged.Act((input, parameter) => 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithTwoInputsAndReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int>("input", 1);
            var called = false;

            arranged.Act((input, parameter) =>
            {
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithTwoInputsAndReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int>("input", 1);

            var result = arranged.Act<int>((input, parameter) => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithTwoInputsAndReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int>("input", 1);
            var called = false;

            arranged.Act<int>((input, parameter) =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithThreeInputs_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);

            var result = arranged.Act((input, param1, param2) => { });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActWithThreeInputs_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);
            var called = false;

            arranged.Act((input, param1, param2) => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithThreeInputs_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);

            var result = arranged.Act((input, param1, param2) => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActWithThreeInputs_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);
            var called = false;

            arranged.Act((input, param1, param2) =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithThreeInputsAndReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);

            var result = arranged.Act((input, param1, param2) => 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithThreeInputsAndReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);
            var called = false;

            arranged.Act((input, param1, param2) =>
            {
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithThreeInputsAndReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);

            var result = arranged.Act<int>((input, param1, param2) => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithThreeInputsAndReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);
            var called = false;

            arranged.Act<int>((input, param1, param2) =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithFourInputs_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);

            var result = arranged.Act((input, param1, param2, param3) => { });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActWithFourInputs_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);
            var called = false;

            arranged.Act((input, param1, param2, param3) => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithFourInputs_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);

            var result = arranged.Act((input, param1, param2, param3) => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActWithFourInputs_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);
            var called = false;

            arranged.Act((input, param1, param2, param3) =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithFourInputsAndReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);

            var result = arranged.Act((input, param1, param2, param3) => 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithFourInputsAndReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);
            var called = false;

            arranged.Act((input, param1, param2, param3) =>
            {
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActWithFourInputsAndReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);

            var result = arranged.Act<int>((input, param1, param2, param3) => throw new IOException());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActWithFourInputsAndReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);
            var called = false;

            arranged.Act<int>((input, param1, param2, param3) =>
            {
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }
    }
}