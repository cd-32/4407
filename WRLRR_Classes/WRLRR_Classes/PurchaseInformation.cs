using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes
{
    public class PurchaseInformation
    {
        #region Constructor
        public PurchaseInformation()
        {

        }
        #endregion

        public const string db_FirstName = "FirstName";
        public const string db_LastName = "LastName";
        public const string db_SerialNumber = "SerialNumber";
        public const string db_ModelNumber = "ModelNumber";
        public const string db_DateIssued = "DateIssued";

        #region Private Variables
        private string _FirstName;
        private string _LastName;
        private string _SerialNumber;
        private string _ModelNumber;
        private DateTime _DateIssued;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the product categories
        /// </summary>
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

        /// <summary>
        /// Gets or sets the type of product
        /// </summary>
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

        public string ModelNumber
        {
            get
            {
                return _ModelNumber;
            }
            set
            {
                _ModelNumber = value;
            }
        }

        public DateTime DateIssued
        {
            get
            {
                return _DateIssued;
            }
            set
            {
                _DateIssued = value;
            }
        }
        #endregion

        public void Fill(SqlDataReader dr)
        {
            FirstName = dr[db_FirstName].ToString();
            LastName = dr[db_LastName].ToString();
            SerialNumber = dr[db_SerialNumber].ToString();
            ModelNumber = dr[db_ModelNumber].ToString();
            DateIssued = (DateTime)dr[db_DateIssued];
        }
    }    
}
