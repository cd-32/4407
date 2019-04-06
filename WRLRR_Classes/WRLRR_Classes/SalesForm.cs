using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes {
    public class SalesForm {

        #region Constructors

        public SalesForm() {

        }

        #endregion


        #region Database String

        public const string db_ID = "SalesFormID";
        public const string db_DateIssued = "DateIssued";
        public const string db_Amount = "Amount";
        public const string db_SalespersonID = "SalespersonID";
        public const string db_CustomerID = "CustomerID";
        public const string db_ItemID = "ItemID";

        #endregion


        #region Private Variables

        private int _ID;
        private DateTime _DateIssued;
        private decimal _Amount;
        private int _SalespersonID;
        private int _CustomerID;
        private int _ItemID;


        #endregion

        #region Public Properties

        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }

        public DateTime DateIssued {
            get { return _DateIssued; }
            set { _DateIssued = value; }
        }

        public decimal Amount {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public int SalesPersonID {
            get { return _SalespersonID; }
        }

        public int CustomerID {
            get { return _CustomerID; }
        }

        public int ItemID {
            get { return _ItemID; }
        }

        #endregion


        public void Fill(System.Data.SqlClient.SqlDataReader dr) {

            ID = (int)dr[db_ID];
            DateIssued = (DateTime)dr[db_DateIssued];
            Amount = (decimal)dr[db_Amount];
            //SalespersonID = (int)dr[db_SalespersonID];
            //CustomerID = (int)dr[db_CustomerID];
            //ItemID = (int)dr[db_ItemID];

        }

        public override string ToString() {
            return $"Date Issued = {_DateIssued.ToShortDateString()} for the amount of ${_Amount}";
        }

    }
}
