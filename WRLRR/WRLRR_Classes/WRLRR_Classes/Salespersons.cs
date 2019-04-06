using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deliverable_6
{
    class Salespersons
    {
        #region Constuctors
        public Salespersons() { }
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_SalesNumber = "Sales Number";
        #endregion

        #region Private Variables
        private int _ID;
        private int _SalesNumber;
        private Employees _Employee;
        #endregion

        #region Public Properties 
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int SalesNumber
        {
            get { return _SalesNumber; }
            set { _SalesNumber = value; }
        }

        [XmlIgnore]
        public Employees Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _SalesNumber = (int)dr[db_SalesNumber];
        }
    }
}
