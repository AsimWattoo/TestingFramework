using System.Runtime.InteropServices;

using TestFramework.Enums;
using TestFramework.Pipeline;

namespace TestFramework.Models
{
    public class TestObject<T>
        where T : new()
    {

        #region Private Members

        /// <summary>
        /// The test object
        /// </summary>
        private T _obj = new T();

        /// <summary>
        /// The result of the testing
        /// </summary>
        private TestResult _result = new TestResult();

        /// <summary>
        /// The pipeline containg all the methods to execute
        /// </summary>
        private TestPipeline _pipeline = new TestPipeline();

        /// <summary>
        /// Indicates whether the pipeline shall continue to test for next values if a 
        /// test has failed for a property
        /// </summary>
        private bool _shouldContinueOnFaliure = false;

        #endregion

        #region Public Properties

        /// <summary>
        /// The object which is under testing
        /// </summary>
        public T Object => _obj;

        /// <summary>
        /// The result for the test object
        /// </summary>
        public TestResult Result => _result;

        /// <summary>
        /// The Pipeline for the test object
        /// </summary>
        public TestPipeline Pipeline => _pipeline;

        /// <summary>
        /// Indicates whether the pipeline shall continue to test for next values if a 
        /// test has failed for a property
        /// </summary>
        public bool ShouldContinueOnFaliure => _shouldContinueOnFaliure;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TestObject(T obj, bool shouldContinueOnFaliure = false)
        {
            _obj = obj;
            _shouldContinueOnFaliure = shouldContinueOnFaliure;
        }

        #endregion

        #region Overriden Methods

        /// <summary>
        /// Provides a string representation of the Test Object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Result: {_result.TestStatus} - Error Count: {_result.Errors.Count}";
        }

        #endregion

    }
}
