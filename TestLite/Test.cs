using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestLite.Tests")]

namespace TestLite
{
    public static class Test
    {
        /// <summary>
        /// Define an empty <b>arrange</b> section when no arrangement is needed
        /// </summary>
        /// <returns></returns>
        public static Arranged Arrange()
        {
            return new Arranged();
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test
        /// </summary>
        public static Arranged<T> Arrange<T>(Func<T> arrangeFunc)
        {
            var underTest = arrangeFunc.Invoke();
            return new Arranged<T>(underTest);
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test
        /// </summary>
        public static Arranged<T> ArrangeAsync<T>(Func<Task<T>> arrangeFunc)
        {
            var underTest = arrangeFunc.Invoke().GetAwaiter().GetResult();
            return new Arranged<T>(underTest);
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test and an additional parameter
        /// </summary>
        public static Arranged<T, TParameter> Arrange<T, TParameter>(Func<(T, TParameter)> arrangeFunc)
        {
            var (underTest, parameter) = arrangeFunc.Invoke();
            return new Arranged<T, TParameter>(underTest, parameter);
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test and an additional parameter
        /// </summary>
        public static Arranged<T, TParameter> ArrangeAsync<T, TParameter>(Func<Task<(T, TParameter)>> arrangeFunc)
        {
            var (underTest, parameter) = arrangeFunc.Invoke().GetAwaiter().GetResult();
            return new Arranged<T, TParameter>(underTest, parameter);
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test and two additional parameters
        /// </summary>
        public static Arranged<T, TParameter1, TParameter2> Arrange<T, TParameter1, TParameter2>(
            Func<(T, TParameter1, TParameter2)> arrangeFunc)
        {
            var (underTest, parameter1, parameter2) = arrangeFunc.Invoke();
            return new Arranged<T, TParameter1, TParameter2>(underTest, parameter1, parameter2);
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test and two additional parameters
        /// </summary>
        public static Arranged<T, TParameter1, TParameter2> ArrangeAsync<T, TParameter1, TParameter2>(
            Func<Task<(T, TParameter1, TParameter2)>> arrangeFunc)
        {
            var (underTest, parameter1, parameter2) = arrangeFunc.Invoke().GetAwaiter().GetResult();
            return new Arranged<T, TParameter1, TParameter2>(underTest, parameter1, parameter2);
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test and two additional parameters
        /// </summary>
        public static Arranged<T, TParameter1, TParameter2, TParameter3> Arrange<T, TParameter1, TParameter2, TParameter3>(
            Func<(T, TParameter1, TParameter2, TParameter3)> arrangeFunc)
        {
            var (underTest, parameter1, parameter2, parameter3) = arrangeFunc.Invoke();
            return new Arranged<T, TParameter1, TParameter2, TParameter3>(underTest, parameter1, parameter2, parameter3);
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test and two additional parameters
        /// </summary>
        public static Arranged<T, TParameter1, TParameter2, TParameter3> ArrangeAsync<T, TParameter1, TParameter2, TParameter3>(
            Func<Task<(T, TParameter1, TParameter2, TParameter3)>> arrangeFunc)
        {
            var (underTest, parameter1, parameter2, parameter3) = arrangeFunc.Invoke().GetAwaiter().GetResult();
            return new Arranged<T, TParameter1, TParameter2, TParameter3>(underTest, parameter1, parameter2, parameter3);
        }
    }
}