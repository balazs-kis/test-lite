using System;

namespace TestLite
{
    public interface IAssertionRoot
    {
        /// <summary>
        /// Validates that the <b>act</b> section ran without exception
        /// </summary>
        /// <param name="reason">Validation message</param>
        void IsSuccess(string reason = null);

        /// <summary>
        /// Validates that the <b>act</b> section threw an exception
        /// </summary>
        /// <param name="reason">Validation message</param>
        void ThrewException(string reason = null);

        /// <summary>
        /// Validates that the <b>act</b> section threw an exception of the specified type
        /// </summary>
        /// <typeparam name="TException">The expected exception type</typeparam>
        /// <param name="reason">Validation message</param>
        void ThrewException<TException>(string reason = null) where TException : Exception;
    }

    public interface IAssertionRoot<out TResult> : IAssertionRoot
    {
        /// <summary>
        /// Runs the given validation action
        /// </summary>
        /// <param name="validationAction">The validation action to execute</param>
        /// <returns>The assertion root is returned so validations can be chained</returns>
        IAssertionRoot<TResult> Validate(Action<TResult> validationAction);
    }
}