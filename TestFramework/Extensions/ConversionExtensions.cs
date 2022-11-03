using TestFramework.Models;

namespace TestFramework.Extensions
{
    public static class ConversionExtensions
    {

        #region Extension Methods

        /// <summary>
        /// Converts an object to a test object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="shouldContinueOnFaliure">Tells whether faliure of a test case shall stop pipelinee execution or not</param>
        /// <returns></returns>
        public static TestObject<T> ToTestObject<T>(this T t, bool shouldContinueOnFaliure = false)
            where T : new()
        {
            return new TestObject<T>(t, shouldContinueOnFaliure);
        }

        #endregion

    }
}
