using System;

using TestFramework.Models;
using TestFramework.Pipeline;
using TestFramework.PipelineMethods;

namespace TestFramework.Extensions
{
    public static class PipelineExtensions
    {

        #region Extension Methods

        /// <summary>
        /// Marks the field as required
        /// </summary>
        /// <typeparam name="T">The type of the object which is under test</typeparam>
        /// <param name="obj"> The object which is being tested </param>
        /// <param name="prop"> The property to test for </param>
        /// <param name="errorMessage"> The message to be displayed in case of false result </param>
        /// <returns></returns>
        public static TestObject<T> Required<T>(this TestObject<T> obj, Func<T, object> prop, string errorMessage = null)
            where T: new()
        {
            Required method = new Required(prop(obj.Object), errorMessage);
            obj.Pipeline.Add(method);
            return obj;
        }

        /// <summary>
        /// Checks for an excact length match
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="prop"></param>
        /// <param name="length"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static TestObject<T> Length<T>(this TestObject<T> obj, Func<T, string> prop, int length, string errorMessage = null)
            where T: new()
        {
            Length l = new Length(prop(obj.Object), length, errorMessage);
            obj.Pipeline.Add(l);
            return obj;
        }

        /// <summary>
        /// Checks for length in range
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="prop"></param>
        /// <param name="length"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static TestObject<T> Length<T>(this TestObject<T> obj, Func<T, string> prop, int min, int max, string errorMessage = null)
            where T : new()
        {
            Length l = new Length(prop(obj.Object), min, max, errorMessage);
            obj.Pipeline.Add(l);
            return obj;
        }

        /// <summary>
        /// Checks for a number to be in a given range
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="prop"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static TestObject<T> NumberRange<T>(this TestObject<T> obj, Func<T, IComparable> prop, IComparable min, IComparable max, string errorMessage = null)
            where T: new()
        {
            NumberRange range = new NumberRange(prop(obj.Object), min, max, errorMessage);
            obj.Pipeline.Add(range);
            return obj;
        }

        /// <summary>
        /// Executes the pipeline
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object under testing</param>
        /// <returns></returns>
        public static TestResult Execute<T>(this TestObject<T> obj)
            where T : new()
        {
            TestPipeline.Execute<T>(obj, obj.ShouldContinueOnFaliure);
            return obj.Result;
        }

        #endregion

    }
}
