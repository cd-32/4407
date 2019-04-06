using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    class ItemDetails
    {
        #region Constructor
        public ItemDetails()
        {

        }
        #endregion

        #region Private Variables
        private int _ID;
        private string _Name;
        private string _Description;
        private string _ModelNumber;
        private double _UnitPrice;
        private ProductCategories _ProductCategory;
        private int _ProductCategoryID;
        
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the item details
        /// </summary>
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

        /// <summary>
        /// Gets or sets the name for the item details
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        /// <summary>
        /// Gets or sets the description for the item details
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        /// <summary>
        /// Gets or sets the model number for the item details
        /// </summary>
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
        /// <summary>
        /// Gets or sets the unit price for the item details
        /// </summary>
        public double UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                _UnitPrice = value;
            }
        }

        /// <summary>
        /// Gets or sets the product category for the item details
        /// </summary>
        [XmlIgnore]
        public ProductCategories ProductCategory
        {
            get
            {
                if (_ProductCategory == null)
                {
                }
                return _ProductCategory;
            }
            set
            {
                _ProductCategory = value;
                if (value == null)
                {
                    _ProductCategoryID = -1;
                }
                else
                {
                    _ProductCategoryID = value.ID;
                }
            }
        }
        /// <summary>
        /// Gets or sets the ProductCategoryID for the unit price
        /// </summary>
        public int ProductCategoryID
        {
            get
            {
                return _ProductCategoryID;
            }
            set
            {
                _ProductCategoryID = value;
            }
        }
        #endregion
    }
}
