using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRRClasses {
    public class Services {

        #region Constructors

        public Services() {

        }

        #endregion


        #region Database String

        internal const string db_ID = "ID";
        internal const string db_RepairNumber = "RepairNumber";
        internal const string db_LaborHours = "LaborHours";
        internal const string db_DateBegan = "DateBegan";
        internal const string db_DateEnded = "DateEnded";
        internal const string db_ServiceFormID = "ServiceFormID";

        #endregion


        #region Private Variables

        private int _ID;
        private int _RepairNumber;
        private decimal _LaborHours;
        private DateTime _DateBegan;
        private DateTime _DateEnded;
        private int _ServiceFormID;


        #endregion


        public void Fill(System.Data.SqlClient.SqlDataReader dr) {

            _ID = (int)dr[db_ID];
            _RepairNumber = (int)dr[db_RepairNumber];
            _LaborHours = (decimal)dr[db_LaborHours];
            _DateBegan = (DateTime)dr[db_DateBegan];
            _DateEnded = (DateTime)dr[db_DateEnded];
            _ServiceFormID = (int)dr[db_ServiceFormID];

        }
    }
}
