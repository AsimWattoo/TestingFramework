using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestFramework.Pipeline;

namespace TestFramework.PipelineMethods
{
    public class Length : BasePipelineMethod
    {

        #region Private Members

        private string value;

        private int minLength;

        private int maxLength;

        private bool exactMatch = false;

        private int length;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructors
        /// </summary>
        public Length(string value, int length, string error = "Value must be of the specified length") : base(error)
        {
            this.value = value;
            this.length = length;
            this.exactMatch = true;
        }

        /// <summary>
        /// Constructor for min and max length
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="error"></param>
        public Length(string value, int minLength, int maxLength, string error = "Length of the value must be in the specified range") : base(error)
        {
            this.value = value;
            this.minLength = minLength;
            this.maxLength = maxLength;
        }


        #endregion

        #region Public Methods

        public override void Execute(ErrorContainer container, bool shouldContinueOnFaliure)
        {
            bool correct = false;
            if (exactMatch)
                correct = value.Length == length;
            else
                correct = value.Length >= minLength && value.Length <= maxLength;

            if (!correct)
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
