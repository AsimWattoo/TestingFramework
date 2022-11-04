using System.Collections.Generic;

using TestFramework.Interfaces;

namespace TestFramework.Pipeline
{
    public abstract class BasePipelineMethod : IPipelineMethod
    {
        #region Public Properties

        public IPipelineMethod Next { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePipelineMethod(string error = null)
        {
            ErrorMessage = error;
        }

        #endregion

        #region Abstract Methods

        public abstract void Execute(ErrorContainer container, bool shouldContinueOnFaliure);

        #endregion
    }
}
