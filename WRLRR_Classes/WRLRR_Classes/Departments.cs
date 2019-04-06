using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes {
    public class Departments {
        #region Constructor
        public Departments() {

        }
        #endregion

        #region Database String
        internal const string db_ID = "DepartmentID";
        internal const string db_Name = "Name";
        #endregion

        #region Private Variables
        private int _ID;
        private string _Name;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the departments
        /// </summary>
        public int ID {
            get {
                return _ID;
            }
            set {
                _ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the name for the departments
        /// </summary>
        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr) {
            _ID = (int)dr[db_ID];
            _Name = (string)dr[db_Name];
        }
    }
}