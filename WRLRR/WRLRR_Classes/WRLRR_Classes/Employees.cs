using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deliverable_6
{
    class Employees
    {
        #region Constuctors
        public Employees() { }
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_EmployeeNumber = "Employee Number";
        #endregion

        #region Private Variables
        private int _ID;
        private int _EmployeeNumber;
        private Departments _Department;
        private People _Person;
        #endregion

        #region Public Properties 
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int EmployeNumber
        {
            get { return _EmployeeNumber; }
            set { _EmployeeNumber = value; }
        }

        [XmlIgnore]
        public Departments Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        [XmlIgnore]
        public People Person
        {
            get { return _Person; }
            set { _Person = value; }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _EmployeeNumber = (int)dr[db_EmployeeNumber];
        }
    }
}
