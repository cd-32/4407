using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes {
    public class Customer {

        #region Constuctors
        public Customer() { }
        #endregion

        #region Database String
        public const string db_ID = "CustomerID";
        public const string db_CustomerNumber = "CustomerNumber";
        #endregion

        #region Private Variables
        private int _ID;
        private int _CustomerNumber;
        private People _Person = new People();
        #endregion

        #region Public Properties 
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        public int CustomerNumber {
            get { return _CustomerNumber; }
            set { _CustomerNumber = value; }
        }

        public People Person {
            get { return _Person; }
            set { _Person = value; }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr) {
            ID = (int)dr[db_ID];
            CustomerNumber = (int)dr[db_CustomerNumber];
            Person.Fill(dr);
        }

        public override string ToString() {
            return $"{Person.FirstName} {Person.LastName}";
        }

    }
}
