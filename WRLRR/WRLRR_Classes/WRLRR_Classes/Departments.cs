using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Departments
    {
        #region Constructor
        public Departments()
        {

        }
        #endregion

        #region Private Variables
        private int _ID;
        private string _Name;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the departments
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
        /// Gets or sets the name for the departments
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        #endregion
    }
}