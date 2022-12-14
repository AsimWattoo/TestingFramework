using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestFramework.Interfaces;
using TestFramework.Pipeline;

namespace TestFramework.PipelineMethods
{
    /// <summary>
    /// Ensures that an element is present
    /// </summary>
    public class Required : BasePipelineMethod
    {

        #region Private Members

        private object _value;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Required(object value, string error = "Value is requried") : base(error)
        {
            _value = value;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Executes the pipeline
        /// </summary>
        /// <param name="shouldContinueOnFaliure"></param>
        /// <returns></returns>
        public override void Execute(ErrorContainer container, bool shouldContinueOnFaliure)
        {
            //Checking the required attribute

            if(_value == null)
            {
                container.Errors.Add(ErrorMessage);
                if(!shouldContinueOnFaliure)
                    return;
            }

            Next?.Execute(container, shouldContinueOnFaliure);
        }

        #endregion
    }
}
