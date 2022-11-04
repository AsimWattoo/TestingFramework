using System.Collections.Generic;

using TestFramework.Enums;

namespace TestFramework.Models
{
    public class TestResult
    {

        #region Private Members

        /// <summary>
        /// The list of errors that have occured for the object in the pipeline
        /// </summary>
        private List<string> _errors = new List<string>();

        #endregion

        #region Public Properties

        /// <summary>
        /// The current test status of the object
        /// </summary>
        public Status TestStatus { get; set; } = Status.NotExecuted;

        /// <summary>
        /// A read only array of all the errors in the testing pipeline
        /// </summary>
        public IReadOnlyCollection<string> Errors => _errors.AsReadOnly();

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an error to the status
        /// </summary>
        /// <param name="error"></param>
        public void AddError(string error) => _errors.Add(error);

        /// <summary>
        /// Adds a list of errors
        /// </summary>
        /// <param name="errors"></param>
        public void AddErrors (List<string> errors) => _errors.AddRange(errors);

        #endregion

        #region Overriden Methods

        /// <summary>
        /// Provides a string representation of the result
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string representation = $"Status: {TestStatus}";

            if(TestStatus == Status.Falied) 
            {
                representation += $"\n<---------------Errors-------------------->";
                foreach(string error in _errors)
                {
                    representation += $"\n{error}";
                }
            }

            return representation;
        }

        #endregion
    }
}
