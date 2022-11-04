using System;
using System.Collections.Generic;
using System.Linq;

using TestFramework.Enums;
using TestFramework.Interfaces;
using TestFramework.Models;

namespace TestFramework.Pipeline
{
    public class TestPipeline
    {

        #region Private Members

        /// <summary>
        /// The list of methods are to be executed in a sequence
        /// </summary>
        private List<IPipelineMethod> _methods = new List<IPipelineMethod>();

        /// <summary>
        /// The last added method
        /// </summary>
        private IPipelineMethod _lastMethod;

        #endregion

        #region Public Members

        /// <summary>
        /// The pipeline of methods
        /// </summary>
        public IReadOnlyList<IPipelineMethod> Pipeline => _methods;

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a method to the pipeline
        /// </summary>
        public void Add(IPipelineMethod method)
        {
            _methods.Add(method);
            _lastMethod.Next = method;
            _lastMethod = method;
        }

        #endregion

        #region Static Members

        /// <summary>
        /// Executes the pipeline
        /// </summary>
        public static void Execute<T>(TestObject<T> tObject, bool shouldContinueOnFaliure = false)
            where T: new()
        {
            List<string> errors = tObject.Pipeline.Pipeline.First().Execute(shouldContinueOnFaliure);
            if (errors.Count > 0)
            {
                tObject.Result.AddErrors(errors);
                tObject.Result.TestStatus = Status.Falied;
            }
            else
                tObject.Result.TestStatus = Status.Succeeded;
        }

        #endregion
    }
}
