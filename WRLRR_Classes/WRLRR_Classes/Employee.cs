using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WRLRR_Classes {
    public class Employee {

        public Employee() { }

        #region Database String
        public const string db_ID = "EmployeeID";
        public const string db_EmployeeNumber = "EmployeeNumber";
        public const string db_DepartmentID = "DepartmentID";
        #endregion

        #region Private Variables
        private int _ID;
        private int _EmployeeNumber;
        private int _DepartmentID;
        private People _Person = new People();
        #endregion

        #region Public Properties 
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        public int EmployeNumber {
            get { return _EmployeeNumber; }
            set { _EmployeeNumber = value; }
        }

        public int DepartmentID{
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        public People Person {
            get { return _Person; }
            set { _Person = value; }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr) {
            _ID = (int)dr[db_ID];
            _EmployeeNumber = (int)dr[db_EmployeeNumber];
            _DepartmentID = (int)dr[db_DepartmentID];
            Person.Fill(dr);
        }

        public override string ToString() {
            return $"{Person.FirstName} {Person.LastName}";
        }
    }
}
