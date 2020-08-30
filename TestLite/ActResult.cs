using System;

namespace TestLite
{
    public class ActResult
    {
        /// <summary>
        /// True, if the execution ran without exception
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// True, if the execution threw an exception
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// The exception thrown during execution (null, if no exception was thrown)
        /// </summary>
        public Exception Exception { get; }

        protected ActResult(bool isSuccess, Exception exception = null)
        {
            IsSuccess = isSuccess;
            Exception = exception;
        }

        internal static ActResult Ok() =>
            new ActResult(true);

        internal static ActResult ThrewException(Exception ex) =>
            new ActResult(false, ex);

        internal static ActResult<T> Ok<T>(T result) =>
            new ActResult<T>(true, null, result);

        internal static ActResult<T> ThrewException<T>(Exception ex) =>
            new ActResult<T>(false, ex);
    }

    public sealed class ActResult<T> : ActResult
    {
        /// <summary>
        /// The result value
        /// </summary>
        public T Value { get; }

        internal ActResult(bool threwException, Exception exception = null, T value = default)
            : base(threwException, exception)
        {
            Value = value;
        }
    }
}