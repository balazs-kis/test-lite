using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace TestLite.Tests
{
    [TestClass]
    public class ArrangedAsyncTests
    {
        [TestMethod]
        public void ActAsync_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged();

            var result = arranged.ActAsync(async () => { await DoSomethingAsync(); });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsync_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged();
            var called = false;

            arranged.ActAsync(async () =>
            {
                await DoSomethingAsync();
                return called = true;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsync_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged();

            var result = arranged.ActAsync(async () =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsync_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged();
            var called = false;

            arranged.ActAsync(async () =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged();

            var result = arranged.ActAsync(async () =>
            {
                await DoSomethingAsync();
                return 1;
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged();
            var called = false;

            arranged.ActAsync(async () =>
            {
                await DoSomethingAsync();
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged();

            var result = arranged.ActAsync<int>(async () =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged();
            var called = false;

            arranged.ActAsync<int>(async () =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithInput_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string>("input");

            var result = arranged.ActAsync(async input =>
            {
                await DoSomethingAsync();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsyncWithInput_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string>("input");
            var called = false;

            arranged.ActAsync(async input =>
            {
                await DoSomethingAsync();
                return called = true;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithInput_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string>("input");

            var result = arranged.ActAsync(async input =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsyncWithInput_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string>("input");
            var called = false;

            arranged.ActAsync(async input =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithInputAndReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string>("input");

            var result = arranged.ActAsync(async input =>
            {
                await DoSomethingAsync();
                return 1;
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithInputAndReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string>("input");
            var called = false;

            arranged.ActAsync(async input =>
            {
                await DoSomethingAsync();
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithInputAndReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string>("input");

            var result = arranged.ActAsync<int>(async input =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithInputAndReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string>("input");
            var called = false;

            arranged.ActAsync<int>(async input =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithTwoInputs_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int>("input", 1);

            var result = arranged.ActAsync(async (input, parameter) =>
            {
                await DoSomethingAsync();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsyncWithTwoInputs_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int>("input", 1);
            var called = false;

            arranged.ActAsync(async (input, parameter) =>
            {
                await DoSomethingAsync();
                called = true;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithTwoInputs_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int>("input", 1);

            var result = arranged.ActAsync(async (input, parameter) =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsyncWithTwoInputs_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int>("input", 1);
            var called = false;

            arranged.ActAsync(async (input, parameter) =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithTwoInputsAndReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int>("input", 1);

            var result = arranged.ActAsync(async (input, parameter) =>
            {
                await DoSomethingAsync();
                return 1;
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithTwoInputsAndReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int>("input", 1);
            var called = false;

            arranged.ActAsync(async (input, parameter) =>
            {
                await DoSomethingAsync();
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithTwoInputsAndReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int>("input", 1);

            var result = arranged.ActAsync<int>(async (input, parameter) =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithTwoInputsAndReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int>("input", 1);
            var called = false;

            arranged.ActAsync<int>(async (input, parameter) =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithThreeInputs_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);

            var result = arranged.ActAsync(async (input, param1, param2) =>
            {
                await DoSomethingAsync();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsyncWithThreeInputs_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);
            var called = false;

            arranged.ActAsync(async (input, param1, param2) =>
            {
                await DoSomethingAsync();
                return called = true;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithThreeInputs_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);

            var result = arranged.ActAsync(async (input, param1, param2) =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsyncWithThreeInputs_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);
            var called = false;

            arranged.ActAsync(async (input, param1, param2) =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithThreeInputsAndReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);

            var result = arranged.ActAsync(async (input, param1, param2) =>
            {
                await DoSomethingAsync();
                return 1;
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithThreeInputsAndReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);
            var called = false;

            arranged.ActAsync(async (input, param1, param2) =>
            {
                await DoSomethingAsync();
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithThreeInputsAndReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);

            var result = arranged.ActAsync<int>(async (input, param1, param2) =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithThreeInputsAndReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double>("input", 1, 2.0);
            var called = false;

            arranged.ActAsync<int>(async (input, param1, param2) =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithFourInputs_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);

            var result = arranged.ActAsync(async (input, param1, param2, param3) =>
            {
                await DoSomethingAsync();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsyncWithFourInputs_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);
            var called = false;

            arranged.ActAsync(async (input, param1, param2, param3) =>
            {
                await DoSomethingAsync();
                return called = true;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithFourInputs_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);

            var result = arranged.ActAsync(async (input, param1, param2, param3) =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted));
        }

        [TestMethod]
        public void ActAsyncWithFourInputs_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);
            var called = false;

            arranged.ActAsync(async (input, param1, param2, param3) =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithFourInputsAndReturnType_ActActionWithoutException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);

            var result = arranged.ActAsync(async (input, param1, param2, param3) =>
            {
                await DoSomethingAsync();
                return 1;
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithFourInputsAndReturnType_ActActionWithoutException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);
            var called = false;

            arranged.ActAsync(async (input, param1, param2, param3) =>
            {
                await DoSomethingAsync();
                called = true;
                return 1;
            });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ActAsyncWithFourInputsAndReturnType_ActActionWithException_ActedInstanceReturned()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);

            var result = arranged.ActAsync<int>(async (input, param1, param2, param3) =>
            {
                await DoSomethingAsync();
                throw new IOException();
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Acted<int>));
        }

        [TestMethod]
        public void ActAsyncWithFourInputsAndReturnType_ActActionWithException_ActActionIsCalled()
        {
            var arranged = new Arranged<string, int, double, decimal>("input", 1, 2.0, 3m);
            var called = false;

            arranged.ActAsync<int>(async (input, param1, param2, param3) =>
            {
                await DoSomethingAsync();
                called = true;
                throw new IOException();
            });

            Assert.IsTrue(called);
        }


        private static Task DoSomethingAsync()
        {
            return Task.Delay(100);
        }
    }
}