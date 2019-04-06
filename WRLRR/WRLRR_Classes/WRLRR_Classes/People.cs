using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deliverable_6
{
    class People
    {
        #region Constructor
        public People()
        {

        }
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_FirstName = "First Name";
        internal const string db_MiddleName = "Middle Name";
        internal const string db_LastName = "Last Name";
        #endregion

        #region Private Variables
        private int _ID;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private EmailAddresses _EmailAdress;
        private Addresses _Address;
        private PhoneNumbers _PhoneNumber;
        #endregion

        #region Public Properties
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                _MiddleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        [XmlIgnore]
        public EmailAddresses EmailAdress
        {
            get
            {
                return _EmailAdress;
            }
            set
            {
                _EmailAdress = value;
            }
        }

        [XmlIgnore]
        public PhoneNumbers PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }

        [XmlIgnore]
        public Addresses Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _FirstName = (string)dr[db_FirstName];
            _MiddleName = (string)dr[db_MiddleName];
            _LastName = (string)dr[db_LastName];
        }
    }
}
