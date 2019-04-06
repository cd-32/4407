using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRRClasses {
    public class SalesForms {

        #region Constructors

        public SalesForms() {

        }

        #endregion


        #region Database String

        internal const string db_ID = "ID";
        internal const string db_DateIssued = "DateIssued";
        internal const string db_Amount = "Amount";
        internal const string db_SalespersonID = "SalespersonID";
        internal const string db_CustomerID = "CustomerID";
        internal const string db_ItemID = "ItemID";

        #endregion


        #region Private Variables

        private int _ID;
        private DateTime _DateIssued;
        private double _Amount;
        private int _SalespersonID;
        private int _CustomerID;
        private int _ItemID;


        #endregion


        public void Fill(System.Data.SqlClient.SqlDataReader dr) {

            _ID = (int)dr[db_ID];
            _DateIssued = (DateTime)dr[db_DateIssued];
            _Amount = (double)dr[db_Amount];
            _SalespersonID = (int)dr[db_SalespersonID];
            _CustomerID = (int)dr[db_CustomerID];
            _ItemID = (int)dr[db_ItemID];

        }
    }
}
