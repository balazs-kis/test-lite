using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestLite.Tests
{
    [TestClass]
    public class ActedTests
    {
        [TestMethod]
        public void OkResult_EmptyAssertReturnsAssertionRoot()
        {
            var input = ActResult.Ok();
            var underTest = new Acted(input);

            var result = underTest.Assert();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AssertionRoot));
        }

        [TestMethod]
        public void GenericOkResult_EmptyAssertReturnsAssertionRoot()
        {
            var input = ActResult.Ok(1);
            var underTest = new Acted<int>(input);

            var result = underTest.Assert();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AssertionRoot));
        }

        [TestMethod]
        public void ErrorResult_EmptyAssertReturnsAssertionRoot()
        {
            var input = ActResult.ThrewException(new Exception());
            var underTest = new Acted(input);

            var result = underTest.Assert();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AssertionRoot));
        }

        [TestMethod]
        public void GenericErrorResult_EmptyAssertReturnsAssertionRoot()
        {
            var input = ActResult.ThrewException<int>(new Exception());
            var underTest = new Acted<int>(input);

            var result = underTest.Assert();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AssertionRoot));
        }

        [TestMethod]
        public void OkResult_AssertionCallbackIsCalled()
        {
            var input = ActResult.Ok();
            var underTest = new Acted(input);
            bool called = false;

            underTest.Assert(r => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void GenericOkResult_AssertionCallbackIsCalled()
        {
            var input = ActResult.Ok(1);
            var underTest = new Acted<int>(input);
            bool called = false;

            underTest.Assert(r => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void ErrorResult_AssertionCallbackIsCalled()
        {
            var input = ActResult.ThrewException(new Exception());
            var underTest = new Acted(input);
            bool called = false;

            underTest.Assert(r => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void GenericErrorResult_AssertionCallbackIsCalled()
        {
            var input = ActResult.ThrewException<int>(new Exception());
            var underTest = new Acted<int>(input);
            bool called = false;

            underTest.Assert(r => called = true);

            Assert.IsTrue(called);
        }
    }
}