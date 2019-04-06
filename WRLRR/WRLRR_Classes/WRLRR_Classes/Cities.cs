using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes
{
    public class ZipCodes
    {
        #region Constructors
        public ZipCodes() { }
        #endregion

        #region Database String
        public const string db_ID = "ID";
        public const string db_Number = "ZipCodeNumber";
        #endregion

        #region Private Variables
        private int _ID;
        private int _Number;
        #endregion

        #region Public Properties
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }

        public int Number {
            get { return _Number; }
            set { _Number = value; }
        }
        #endregion

        #region Fill
        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _Number = (int)dr[db_Number];
        }
        #endregion
    }
}
