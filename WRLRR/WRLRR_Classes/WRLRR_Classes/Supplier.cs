using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deliverable_6
{
    public class Supplier
    {
        #region Constuctors
        public Supplier() { }
        #endregion

        #region Database String
        //internal const string db_ID = "SupplierID";
        internal const string db_Number = "Number";
        internal const string db_Name = "Name";
        #endregion

        #region Private Variables
        private int _ID;
        private int _Number;
        private string _Name;
        //private PhoneNumbers _PhoneNumber;
        private Addresses _Address;
        //private EmailAddresses _EmailAddress;
        #endregion

        #region Public Properties 
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        public int Number {
            get { return _Number; }
            set { _Number = value; }
        }


        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }

        //[XmlIgnore]
        //public PhoneNumbers PhoneNumber {
        //    get { return _PhoneNumber; }
        //    set { _PhoneNumber = value; }
        //}

        //[XmlIgnore]
        //public Addresses Address {
        //    get { return _Address; }
        //    set { _Address = value; }
        //}


        //public EmailAddresses EmailAddress {
        //    get { return _EmailAddress; }
        //    set { _EmailAddress = value; }
        //}
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            // _ID = (int)dr[db_ID];
            _Number = (int)dr[db_Number];
            _Name = (string)dr[db_Name];
        }
    }
}
