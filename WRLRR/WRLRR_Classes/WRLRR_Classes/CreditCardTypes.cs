using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_6
{
    class CreditCardTypes
    {
        #region Constuctors
        public CreditCardTypes() { }
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_Name = "Name";
        #endregion

        #region Private Variables
        private int _ID;
        private string _Name;
        #endregion

        #region Public Properties 
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _Name = (string)dr[db_Name];
        }
    }
}
