using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pipeline
{
    public class ErrorContainer
    {

        #region Public Properties

        /// <summary>
        /// The list of errors
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        #endregion

    }
}
