using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRRClasses {
    public class ServiceForms {

        #region Constructors

        public ServiceForms() {

        }

        #endregion


        #region Database String

        internal const string db_ID = "ID";
        internal const string db_DateIssued = "DateIssued";
        internal const string db_ProblemDescription = "ProblemDescription";
        internal const string db_CustomerID = "CustomerID";
        internal const string db_TechnicianID = "TechnicianID";
        internal const string db_ItemDetailID = "ItemDetailID";

        #endregion


        #region Private Variables

        private int _ID;
        private DateTime _DateIssued;
        private string _ProblemDescription;
        private int _CustomerID;
        private int _TechnicianID;
        private int _ItemDetailID;

        #endregion


        public void Fill(System.Data.SqlClient.SqlDataReader dr) {

            _ID = (int)dr[db_ID];
            _DateIssued = (DateTime)dr[db_DateIssued];
            _ProblemDescription = (string)dr[db_ProblemDescription];
            _CustomerID = (int)dr[db_CustomerID];
            _TechnicianID = (int)dr[db_TechnicianID];
            _ItemDetailID = (int)dr[db_ItemDetailID];

        }

    }
}
