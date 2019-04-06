using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRRClasses {
    public class Inventories {

        #region Constructors

        public Inventories() {

        }

        #endregion


        #region Database String

        internal const string db_ID = "ID";
        internal const string db_ReorderPoint = "ReorderPoint";
        internal const string db_ItemDetailID = "ItemDetailID";

        #endregion


        #region Private Variables

        private int _ID;
        private int _ReorderPoint;
        private int _ItemDetailID;

        #endregion


        public void Fill(System.Data.SqlClient.SqlDataReader dr) {

            _ID = (int)dr[db_ID];
            _ReorderPoint = (int)dr[db_ReorderPoint];
            _ItemDetailID = (int)dr[db_ItemDetailID];

        }

    }
}
