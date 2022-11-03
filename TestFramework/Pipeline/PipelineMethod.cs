using System;

namespace TestFramework.Pipeline
{
    public class PipelineMethod
    {

        #region Public Members

        /// <summary>
        /// The method which can be executed for testing
        /// </summary>
        public Func<bool> Method { get; set; }

        /// <summary>
        /// The Error message
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PipelineMethod()
        {

        }

        /// <summary>
        /// Constructor accepting method and error  message as input
        /// </summary>
        public PipelineMethod(Func<bool> _method, string errorMessage = null)
        {
            Method = _method;
            ErrorMessage = errorMessage;
        }

        #endregion
    }
}
