using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes
{
    public class ItemGetByServiceTechnician
    {
        #region Constructor
        public ItemGetByServiceTechnician()
        {

        }
        #endregion

        #region Database String
        internal const string db_SerialNumber = "SerialNumber";
        internal const string db_RepairNumber = "RepairNumber";

        #endregion

        #region Private Variables
        private string _SerialNumber;
        private int _RepairNumber;
        #endregion

        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                _SerialNumber = value;
            }
        }

        public int RepairNumber
        {
            get
            {
                return _RepairNumber;
            }
            set
            {
                _RepairNumber = value;
            }
        }
        #endregion

        public void Fill(SqlDataReader dr)
        {
            SerialNumber = dr[db_SerialNumber].ToString();
            RepairNumber = (int)dr[db_RepairNumber];
        }
    }
}
