using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ProductCategories
    {

        #region DatabaseStrings
        public const string db_ID = "ProductCategoryID";
        public const string db_Type = "Type";
        #region Constructor
        public ProductCategories()
        {

        }
        #endregion

        #region Private Variables
        private int _ID;
        private string _Type;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the product categories
        /// </summary>
        public int ID {
            get {
                return _ID;
            }
            set {
                _ID = value;
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets the type of product
        /// </summary>
        public string Type {
            get {
                return _Type;
            }
            set {
                _Type = value;
            }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _Type = (string)dr[db_Type];
        }
    }
}
