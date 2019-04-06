using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deliverable_6
{
    class CreditCards
    {
        #region Constuctors
        public CreditCards()
        {

        }
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_Number = "Number";
        internal const string db_DateOfExpiration = "Expiration Date";
        internal const string db_VerificationCode = "Verfification Code";
        #endregion

        #region Private Variables
        private int _ID;
        private int _Number;
        private DateTime _DateOfExpiration;
        private int _VerficationCode;
        private CreditCardTypes _CreditCardType;
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

        public int Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
            }
        }

        public DateTime DateOfExpiration
        {
            get
            {
                return _DateOfExpiration;
            }
            set
            {
                _DateOfExpiration = value;
            }
        }

        public int VerificationCode
        {
            get
            {
                return _VerficationCode;
            }
            set
            {
                _VerficationCode = value;
            }
        }

        [XmlIgnore]
        public CreditCardTypes CreditCardType
        {
            get
            {
                return _CreditCardType;
            }
            set
            {
                _CreditCardType = value;
            }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _Number = (int)dr[db_Number];
            _DateOfExpiration = (DateTime)dr[db_DateOfExpiration];
            _VerficationCode = (int)dr[db_VerificationCode];
        }
    }
}
