using System;
using System.Threading.Tasks;

namespace TestLite
{
    public sealed class Arranged
    {
        /// <summary>
        /// Define the <b>act</b>section of the test as an action
        /// </summary>
        public Acted Act(Action actAction) =>
            new Acted(CatchException(actAction));

        /// <summary>
        /// Define the <b>act</b>section of the test as an action
        /// </summary>
        public Acted ActAsync(Func<Task> actAction) =>
            new Acted(CatchExceptionAsync(actAction));

        /// <summary>
        /// Define the <b>act</b>section of the test as a function
        /// which returns the result of the test
        /// </summary>
        public Acted<TResult> Act<TResult>(Func<TResult> actFunc) =>
            new Acted<TResult>(CatchException(actFunc));

        /// <summary>
        /// Define the <b>act</b>section of the test as a function
        /// which returns the result of the test
        /// </summary>
        public Acted<TResult> ActAsync<TResult>(Func<Task<TResult>> actFunc) =>
            new Acted<TResult>(CatchExceptionAsync(actFunc));


        private static ActResult CatchException(Action action)
        {
            try
            {
                action.Invoke();
                return ActResult.Ok();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException(ex);
            }
        }

        private static ActResult CatchExceptionAsync(Func<Task> action)
        {
            try
            {
                action.Invoke().GetAwaiter().GetResult();
                return ActResult.Ok();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException(ex);
            }
        }

        private static ActResult<T> CatchException<T>(Func<T> func)
        {
            T result;

            try
            {
                result = func.Invoke();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException<T>(ex);
            }

            return ActResult.Ok(result);
        }

        private static ActResult<T> CatchExceptionAsync<T>(Func<Task<T>> func)
        {
            T result;

            try
            {
                result = func.Invoke().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException<T>(ex);
            }

            return ActResult.Ok(result);
        }
    }

    public sealed class Arranged<T>
    {
        private readonly T _underTest;

        internal Arranged(T underTest)
        {
            _underTest = underTest;
        }

        /// <summary>
        /// Define the <b>act</b>section of the test as an action
        /// </summary>
        public Acted Act(Action<T> actAction) =>
            new Acted(CatchException(actAction));

        /// <summary>
        /// Define the <b>act</b>section of the test as an action
        /// </summary>
        public Acted ActAsync(Func<T, Task> actAction) =>
            new Acted(CatchExceptionAsync(actAction));

        /// <summary>
        /// Define the <b>act</b>section of the test as a function
        /// which returns the result of the test
        /// </summary>
        public Acted<TResult> Act<TResult>(Func<T, TResult> actFunc) =>
            new Acted<TResult>(CatchException(actFunc));

        /// <summary>
        /// Define the <b>act</b>section of the test as a function
        /// which returns the result of the test
        /// </summary>
        public Acted<TResult> ActAsync<TResult>(Func<T, Task<TResult>> actFunc) =>
            new Acted<TResult>(CatchExceptionAsync(actFunc));


        private ActResult CatchException(Action<T> func)
        {
            try
            {
                func.Invoke(_underTest);
                return ActResult.Ok();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException(ex);
            }
        }

        private ActResult CatchExceptionAsync(Func<T, Task> func)
        {
            try
            {
                func.Invoke(_underTest).GetAwaiter().GetResult();
                return ActResult.Ok();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException(ex);
            }
        }

        private ActResult<TOut> CatchException<TOut>(Func<T, TOut> func)
        {
            TOut result;

            try
            {
                result = func.Invoke(_underTest);
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException<TOut>(ex);
            }

            return ActResult.Ok(result);
        }

        private ActResult<TOut> CatchExceptionAsync<TOut>(Func<T, Task<TOut>> func)
        {
            TOut result;

            try
            {
                result = func.Invoke(_underTest).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException<TOut>(ex);
            }

            return ActResult.Ok(result);
        }
    }

    public sealed class Arranged<T, TParam>
    {
        private readonly T _underTest;
        private readonly TParam _parameter;

        internal Arranged(T underTest, TParam parameter)
        {
            _underTest = underTest;
            _parameter = parameter;
        }

        /// <summary>
        /// Define the <b>act</b>section of the test as an action
        /// </summary>
        public Acted Act(Action<T, TParam> actAction) =>
            new Acted(CatchException(actAction));

        /// <summary>
        /// Define the <b>act</b>section of the test as an action
        /// </summary>
        public Acted ActAsync(Func<T, TParam, Task> actAction) =>
            new Acted(CatchExceptionAsync(actAction));

        /// <summary>
        /// Define the <b>act</b>section of the test as a function
        /// which returns the result of the test
        /// </summary>
        public Acted<TResult> Act<TResult>(Func<T, TParam, TResult> actFunc) =>
            new Acted<TResult>(CatchException(actFunc));

        /// <summary>
        /// Define the <b>act</b>section of the test as a function
        /// which returns the result of the test
        /// </summary>
        public Acted<TResult> ActAsync<TResult>(Func<T, TParam, Task<TResult>> actFunc) =>
            new Acted<TResult>(CatchExceptionAsync(actFunc));


        private ActResult CatchException(Action<T, TParam> action)
        {
            try
            {
                action.Invoke(_underTest, _parameter);
                return ActResult.Ok();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException(ex);
            }
        }

        private ActResult CatchExceptionAsync(Func<T, TParam, Task> action)
        {
            try
            {
                action.Invoke(_underTest, _parameter).GetAwaiter().GetResult();
                return ActResult.Ok();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException(ex);
            }
        }

        private ActResult<TOut> CatchException<TOut>(Func<T, TParam, TOut> func)
        {
            TOut result;

            try
            {
                result = func.Invoke(_underTest, _parameter);
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException<TOut>(ex);
            }

            return ActResult.Ok(result);
        }

        private ActResult<TOut> CatchExceptionAsync<TOut>(Func<T, TParam, Task<TOut>> func)
        {
            TOut result;

            try
            {
                result = func.Invoke(_underTest, _parameter).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException<TOut>(ex);
            }

            return ActResult.Ok(result);
        }
    }

    public sealed class Arranged<T, TParam1, TParam2>
    {
        private readonly T _underTest;
        private readonly TParam1 _parameter1;
        private readonly TParam2 _parameter2;

        internal Arranged(T underTest, TParam1 parameter1, TParam2 parameter2)
        {
            _underTest = underTest;
            _parameter1 = parameter1;
            _parameter2 = parameter2;
        }

        /// <summary>
        /// Define the <b>act</b>section of the test as an action
        /// </summary>
        public Acted Act(Action<T, TParam1, TParam2> actAction) =>
            new Acted(CatchException(actAction));

        /// <summary>
        /// Define the <b>act</b>section of the test as an action
        /// </summary>
        public Acted ActAsync(Func<T, TParam1, TParam2, Task> actAction) =>
            new Acted(CatchExceptionAsync(actAction));

        /// <summary>
        /// Define the <b>act</b>section of the test as a function
        /// which returns the result of the test
        /// </summary>
        public Acted<TResult> Act<TResult>(Func<T, TParam1, TParam2, TResult> actFunc) =>
            new Acted<TResult>(CatchException(actFunc));

        /// <summary>
        /// Define the <b>act</b>section of the test as a function
        /// which returns the result of the test
        /// </summary>
        public Acted<TResult> ActAsync<TResult>(Func<T, TParam1, TParam2, Task<TResult>> actFunc) =>
            new Acted<TResult>(CatchExceptionAsync(actFunc));


        private ActResult CatchException(Action<T, TParam1, TParam2> action)
        {
            try
            {
                action.Invoke(_underTest, _parameter1, _parameter2);
                return ActResult.Ok();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException(ex);
            }
        }

        private ActResult CatchExceptionAsync(Func<T, TParam1, TParam2, Task> action)
        {
            try
            {
                action
                    .Invoke(_underTest, _parameter1, _parameter2)
                    .GetAwaiter()
                    .GetResult();

                return ActResult.Ok();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException(ex);
            }
        }

        private ActResult<TOut> CatchException<TOut>(Func<T, TParam1, TParam2, TOut> func)
        {
            TOut result;

            try
            {
                result = func.Invoke(_underTest, _parameter1, _parameter2);
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException<TOut>(ex);
            }

            return ActResult.Ok(result);
        }

        private ActResult<TOut> CatchExceptionAsync<TOut>(Func<T, TParam1, TParam2, Task<TOut>> func)
        {
            TOut result;

            try
            {
                result = func
                    .Invoke(_underTest, _parameter1, _parameter2)
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception ex)
            {
                return ActResult.ThrewException<TOut>(ex);
            }

            return ActResult.Ok(result);
        }
    }
}