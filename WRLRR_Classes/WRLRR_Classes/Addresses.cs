using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WRLRR_Classes
{
    public class Addresses
    {
        #region Constuctors
        public Addresses() { }
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_StreetAddress = "Street Address";
        #endregion

        #region Private Variables
        private int _ID;
        private string _StreetAddress;
        private ZipCodes _ZipCode;
        private Cities _Cities;
        #endregion

        #region Public Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        [XmlIgnore]
        public ZipCodes ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        [XmlIgnore]
        public Cities Cities
        {
            get { return _Cities; }
            set { _Cities = value; }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _StreetAddress = (string)dr[db_StreetAddress];
        }
    }
}
