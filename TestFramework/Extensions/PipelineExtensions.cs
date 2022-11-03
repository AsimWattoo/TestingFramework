using System;

using TestFramework.Models;
using TestFramework.Pipeline;

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
            PipelineMethod method = new PipelineMethod(() => !(prop(obj.Object) == null), errorMessage);
            obj.Pipeline.Add(method);
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
            TestPipeline.Execute<T>(obj);
            return obj.Result;
        }

        #endregion

    }
}
