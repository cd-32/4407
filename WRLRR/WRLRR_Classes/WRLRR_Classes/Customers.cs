using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deliverable_6
{
    class Customers
    {
        #region Constuctors
        public Customers() { }
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_CustomerNumber = "CustomerNumber";
        #endregion

        #region Private Variables
        private int _ID;
        private int _CustomerNumber;
        private People _Person;
        #endregion

        #region Public Properties 
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int CustomerNumber
        {
            get { return _CustomerNumber; }
            set { _CustomerNumber = value; }
        }

        [XmlIgnore]
        public People Person
        {
            get { return _Person; }
            set { _Person = value; }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _CustomerNumber = (int)dr[db_CustomerNumber];
        }
    }
}
