using System;
using System.Runtime.CompilerServices;

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
        /// which returns the unit under test and an additional paramater
        /// </summary>
        public static Arranged<T, TParameter> Arrange<T, TParameter>(Func<(T, TParameter)> arrangeFunc)
        {
            var (underTest, parameter) = arrangeFunc.Invoke();
            return new Arranged<T, TParameter>(underTest, parameter);
        }

        /// <summary>
        /// Define the <b>arrange</b> section of the test as a function
        /// which returns the unit under test and two additional paramaters
        /// </summary>
        public static Arranged<T, TParameter1, TParameter2> Arrange<T, TParameter1, TParameter2>(
            Func<(T, TParameter1, TParameter2)> arrangeFunc)
        {
            var (underTest, parameter1, parameter2) = arrangeFunc.Invoke();
            return new Arranged<T, TParameter1, TParameter2>(underTest, parameter1, parameter2);
        }
    }
}