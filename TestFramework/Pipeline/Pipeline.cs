using System;
using System.Collections.Generic;

using TestFramework.Enums;
using TestFramework.Models;

namespace TestFramework.Pipeline
{
    public class TestPipeline
    {

        #region Private Members

        /// <summary>
        /// The list of methods are to be executed in a sequence
        /// </summary>
        private List<PipelineMethod> _methods = new List<PipelineMethod>();

        #endregion

        #region Public Members

        /// <summary>
        /// The pipeline of methods
        /// </summary>
        public IReadOnlyList<PipelineMethod> Pipeline => _methods;

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a method to the pipeline
        /// </summary>
        public void Add(PipelineMethod method) => _methods.Add(method);

        #endregion

        #region Static Members

        /// <summary>
        /// Executes the pipeline
        /// </summary>
        public static void Execute<T>(TestObject<T> tObject, bool shouldContinueOnFaliure = false)
            where T: new()
        {
            ///Iterating and executing all the methods
            foreach(PipelineMethod method in tObject.Pipeline._methods)
            {
                bool result = method.Method();

                if (!result)
                    tObject.Result.AddError(method.ErrorMessage ?? "Test Failed");

                //If the test has failed and the should continue is not allowed then return
                if (!result && !shouldContinueOnFaliure)
                    break;
            }
            if (tObject.Result.Errors.Count > 0)
                tObject.Result.TestStatus = Status.Falied;
            else
                tObject.Result.TestStatus = Status.Succeeded;
        }

        #endregion

    }
}
