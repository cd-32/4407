using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class ReasonForReturns
    {
        #region Constructor
        public ReasonForReturns()
        {

        }
        #endregion

        #region Private Variables
        private int _ID;
        private string _Reason;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the reason for return
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the reason for the reason for return
        /// </summary>
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }
        #endregion
    }
}
