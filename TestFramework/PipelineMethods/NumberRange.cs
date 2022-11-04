using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestFramework.Pipeline;

namespace TestFramework.PipelineMethods
{
    public class NumberRange : BasePipelineMethod
    {

        #region Private Members

        private IComparable value;

        private IComparable min;

        private IComparable max;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public NumberRange(IComparable _value, IComparable _min, IComparable _max, string error = "Value must be in the specified range") : base(error)
        {
            value = _value;
            min = _min;
            max = _max;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Excutes the method for checking
        /// </summary>
        /// <param name="container"></param>
        /// <param name="shouldContinueOnFaliure"></param>
        public override void Execute(ErrorContainer container, bool shouldContinueOnFaliure)
        {
            bool correct = value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;

            if (!correct)
            {
                container.Errors.Add(ErrorMessage);
                if (!shouldContinueOnFaliure)
                    return;
            }

            Next?.Execute(container, shouldContinueOnFaliure);
        }

        #endregion
    }
}
