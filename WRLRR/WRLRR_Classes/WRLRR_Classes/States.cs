using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class States
    {
        #region Constructor
        public States()
        {

        }
        #endregion

        #region DatabaseStrings
        public const string db_ID = "ID";
        public const string db_Name = "StateName";
        public const string db_Abbreviation = "StateAbbreviation";
        #endregion

        #region Private Variables
        private int _ID;
        private string _Name;
        private string _Abbreviation;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the states
        /// </summary>
        public int ID {
            get {
                return _ID;
            }
            set {
                _ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the name for the states
        /// </summary>
        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        /// <summary>
        /// Gets or sets the abbreviation for the states
        /// </summary>
        public string Abbreviation {
            get {
                return _Abbreviation;
            }
            set {
                _Abbreviation = value;
            }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _Name = (string)dr[db_Name];
            _Abbreviation = (string)dr[db_Abbreviation];

        }

    }
}

