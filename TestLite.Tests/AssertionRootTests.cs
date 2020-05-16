using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
            var underTest = new AssertionRoot<int>(result);
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
            var underTest = new AssertionRoot<int>(result);
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
            var underTest = new AssertionRoot<int>(result);
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
        public void OkResult_ThrewExceptionThrowsException()
        {
            var result = ActResult.Ok();
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AssertFailedException));
        }

        [TestMethod]
        public void GenericOkResult_ThrewExceptionThrowsException()
        {
            var result = ActResult.Ok(0);
            var underTest = new AssertionRoot<int>(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AssertFailedException));
        }

        [TestMethod]
        public void OkResult_ThrewExceptionThrowsExceptionWithMessage()
        {
            const string message = "Should not work";

            var result = ActResult.Ok();
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException(message);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message.Contains(message));
        }

        [TestMethod]
        public void GenericOkResult_ThrewExceptionThrowsExceptionWithMessage()
        {
            const string message = "Should not work";

            var result = ActResult.Ok(0);
            var underTest = new AssertionRoot<int>(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException(message);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message.Contains(message));
        }

        [TestMethod]
        public void ErrorResult_ThrewExceptionDoesNotThrowException()
        {
            var result = ActResult.ThrewException(new IOException());
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }

        [TestMethod]
        public void GenericErrorResult_ThrewExceptionDoesNotThrowException()
        {
            var result = ActResult.ThrewException<int>(new Exception());
            var underTest = new AssertionRoot<int>(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }

        [TestMethod]
        public void ErrorResultWithWrongExceptionType_ThrewExceptionThrowsException()
        {
            var result = ActResult.ThrewException(new IOException());
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException<InvalidOperationException>();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AssertFailedException));
        }

        [TestMethod]
        public void GenericErrorResultWithWrongExceptionType_ThrewExceptionThrowsException()
        {
            var result = ActResult.ThrewException<int>(new IOException());
            var underTest = new AssertionRoot<int>(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException<InvalidOperationException>();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AssertFailedException));
        }

        [TestMethod]
        public void ErrorResultWithWrongExceptionType_ThrewExceptionThrowsExceptionWithMessage()
        {
            const string message = "Should throw InvalidOperation";
            var result = ActResult.ThrewException(new IOException());
            var underTest = new AssertionRoot(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException<InvalidOperationException>(message);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AssertFailedException));
        }        

        [TestMethod]
        public void GenericErrorResultWithWrongExceptionType_ThrewExceptionThrowsExceptionWithMessage()
        {
            const string message = "Should throw InvalidOperation";
            var result = ActResult.ThrewException<int>(new IOException());
            var underTest = new AssertionRoot<int>(result);
            Exception exception = null;

            try
            {
                underTest.ThrewException<InvalidOperationException>(message);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AssertFailedException));
        }
    }
}