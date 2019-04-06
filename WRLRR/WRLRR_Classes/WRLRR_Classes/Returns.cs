using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WRLRRClasses {
    public class Returns {

        #region Constructors

        public Returns() {

        }

        #endregion


        #region Database String

        internal const string db_ID = "ID";
        internal const string db_DateReturned = "DateReturned";
        internal const string db_Signiture = "Signiture";
        internal const string db_SalespersonID = "SalespersonID";
        internal const string db_ReasonForReturnID = "ReasonForReturnID";
        internal const string db_SalesFormID = "SalesFormID";

        #endregion


        #region Private Variables

        private int _ID;
        private DateTime _DateReturned;
        private Image _Signiture;
        private int _SalespersonID;
        private int _ReasonForReturnID;
        private int _SalesFormID;

        #endregion


        public void Fill(System.Data.SqlClient.SqlDataReader dr) {

            _ID = (int)dr[db_ID];
            _DateReturned = (DateTime)dr[db_DateReturned];
            _Signiture = (Image)dr[db_Signiture];
            _SalespersonID = (int)dr[db_SalespersonID];
            _ReasonForReturnID = (int)dr[db_ReasonForReturnID];
            _SalesFormID = (int)dr[db_SalesFormID];

        }

    }
}
