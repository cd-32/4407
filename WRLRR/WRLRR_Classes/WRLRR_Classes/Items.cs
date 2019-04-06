using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    class Items
    {
        #region Constructor
        public Items()
        {

        }
        #endregion

        #region Private Variables
        private int _ID;
        private int _InventoryTag;
        private string _SerialNumber;
        private ItemDetails _ItemDetail;
        private int _ItemDetailID;
        private Suppliers _Supplier;
        private int _SupplierID;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the items
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
        /// Gets or sets the inventory tag for the items
        /// </summary>
        public int InventoryTag
        {
            get
            {
                return _InventoryTag;
            }
            set
            {
                _InventoryTag = value;
            }
        }
        /// <summary>
        /// Gets or sets the serial number for the items
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

        /// <summary>
        /// Gets or sets the ItemDetails for the item
        /// </summary>
        [XmlIgnore]
        public ItemDetails ItemDetail
        {
            get
            {
                if (_ItemDetail == null)
                {
                }
                return _ItemDetail;
            }
            set
            {
                _ItemDetail = value;
                if (value == null)
                {
                    _ItemDetailID = -1;
                }
                else
                {
                    _ItemDetailID = value.ID;
                }
            }
        }
        /// <summary>
        /// Gets or sets the ItemDetailID for the item
        /// </summary>
        public int ItemDetailID
        {
            get
            {
                return _ItemDetailID;
            }
            set
            {
                _ItemDetailID = value;
            }
        }

        /// <summary>
        /// Gets or sets the supplier for the item
        /// </summary>
        [XmlIgnore]
        public ItemDetails Supplier
        {
            get
            {
                if (_Supplier == null)
                {
                }
                return _Supplier;
            }
            set
            {
                _Supplier = value;
                if (value == null)
                {
                    _SupplierID = -1;
                }
                else
                {
                    _SupplierID = value.ID;
                }
            }
        }
        /// <summary>
        /// Gets or sets the supplierID for the item
        /// </summary>
        public int SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                _SupplierID = value;
            }
        }
        #endregion
    }
}
