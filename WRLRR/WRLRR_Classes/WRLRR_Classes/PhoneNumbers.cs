using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class PhoneNumbers
    {
        #region Constructor
        public PhoneNumbers()
        {

        }
        #endregion

        #region Private Variables
        private int _ID;
        private int _Number;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the phone numbers
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
        /// Gets or sets the number for the phone numbers
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
        #endregion
    }
}
