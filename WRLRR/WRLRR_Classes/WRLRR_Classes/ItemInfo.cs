using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes
{
    public class ItemInfo
    {

        #region Constructor
        public ItemInfo()
        {

        }
        #endregion

        #region DatabaseString
        public const string db_SerialNumber = "SerialNumber";
        public const string db_ModelNumber = "ModelNumber";
        #endregion

        #region Private Variables
        private string _SerialNumber;
        private string _ModelNumber;
        #endregion

        #region Public Properties

        public string SerialNumber {
            get {
                return _SerialNumber;
            }
            set {
                _SerialNumber = value;
            }
        }


        public string ModelNumber {
            get {
                return _ModelNumber;
            }
            set {
                _ModelNumber = value;
            }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _SerialNumber = dr[db_SerialNumber].ToString();
            _ModelNumber = dr[db_ModelNumber].ToString();
        }
    }
}
