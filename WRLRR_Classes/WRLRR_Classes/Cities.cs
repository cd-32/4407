using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes {
    public class Cities {

        #region Constructors
        public Cities() { }
        #endregion

        #region DatabaseString
        public const string db_ID = "ID";
        public const string db_Name = "CityName";
        #endregion

        #region PrivateVariables
        private int _ID;
        private string _Name;
        #endregion

        #region Properties
        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }

        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _Name = (string)dr[db_Name];
        }
    }
}
