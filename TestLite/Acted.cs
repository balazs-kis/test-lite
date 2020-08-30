using System;

namespace TestLite
{
    public sealed class Acted
    {
        private readonly ActResult _result;

        public Acted(ActResult result)
        {
            _result = result;
        }

        /// <summary>
        /// Use this method for fluent validations
        /// </summary>
        /// <returns>An <see cref="IAssertionRoot"/>, on which various validation methods can be called</returns>
        public IAssertionRoot Assert() =>
            new AssertionRoot(_result);

        /// <summary>
        /// Use this method to define a single validation action
        /// </summary>
        /// <param name="validations">The action to validate the result</param>
        public void Assert(Action<ActResult> validations) =>
            validations.Invoke(_result);
    }

    public sealed class Acted<T>
    {
        private readonly ActResult<T> _result;

        public Acted(ActResult<T> result)
        {
            _result = result;
        }

        /// <summary>
        /// Use this method for fluent validations
        /// </summary>
        /// <returns>An <see cref="IAssertionRoot"/>, on which various validation methods can be called</returns>
        public IAssertionRoot<T> Assert() =>
            new AssertionRoot<T>(_result);

        /// <summary>
        /// Use this method to define a single validation action
        /// </summary>
        /// <param name="validations">The action to validate the result</param>
        public void Assert(Action<ActResult<T>> validations) =>
            validations.Invoke(_result);
    }
}