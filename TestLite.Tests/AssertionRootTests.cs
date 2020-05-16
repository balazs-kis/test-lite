using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestLite.Tests
{
    [TestClass]
    public class AssertionRootTests
    {
        [TestMethod]
        public void OkResult_IsSuccessDoesNotThrowException()
        {
            var result = ActResult.Ok();
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.IsSuccess();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }

        [TestMethod]
        public void GenericOkResult_IsSuccessDoesNotThrowException()
        {
            var result = ActResult.Ok(0);
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.IsSuccess();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }

        [TestMethod]
        public void ErrorResult_IsSuccessThrowsException()
        {
            var result = ActResult.ThrewException(new Exception());
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.IsSuccess();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AssertFailedException));
        }

        [TestMethod]
        public void ErrorResult_IsSuccessThrowsExceptionWithMessage()
        {
            const string message = "Should work";
            var result = ActResult.ThrewException(new Exception());
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.IsSuccess(message);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message.Contains(message));
        }

        [TestMethod]
        public void GenericErrorResult_IsSuccessThrowsException()
        {
            var result = ActResult.ThrewException<int>(new Exception());
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.IsSuccess();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AssertFailedException));
        }

        [TestMethod]
        public void GenericErrorResult_IsSuccessThrowsExceptionWithMessage()
        {
            const string message = "Should work";
            var result = ActResult.ThrewException<int>(new Exception());
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.IsSuccess(message);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message.Contains(message));
        }
    }
}