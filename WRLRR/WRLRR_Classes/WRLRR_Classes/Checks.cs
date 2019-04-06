using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Checks
    {
        #region Constructor
        public Checks()
        {

        }
        #endregion

        #region Private Variables
        private int _ID;
        private int _Number;
        private int _BankRouting;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the checks
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
        /// Gets or sets the check number for the checks
        /// </summary>
        public int Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
            }
        }

        /// <summary>
        /// Gets or sets the bank routing number for the checks
        /// </summary>
        public int BankRouting
        {
            get
            {
                return _BankRouting;
            }
            set
            {
                _BankRouting = value;
            }
        }
        #endregion
    }
}
