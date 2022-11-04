using System.Collections.Generic;

using TestFramework.Pipeline;

namespace TestFramework.Interfaces
{
    public interface IPipelineMethod
    {
        /// <summary>
        /// The next method to be called
        /// </summary>
        IPipelineMethod Next { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// The method to execute
        /// </summary>
        /// <returns></returns>
        void Execute(ErrorContainer container,bool shouldContinueOnFaliure);
    }
}
