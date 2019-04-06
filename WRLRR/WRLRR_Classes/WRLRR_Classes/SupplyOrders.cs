using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    class SupplyOrders
    {
        #region Constructor
        public SupplyOrders()
        {

        }
        #endregion

        #region Private Variables
        private int _ID;
        private int _OrderNumber;
        private DateTime _DateRequested;
        private DateTime _DatePurchased;
        private DateTime _DateRecieved;
        private Items _Item;
        private int _ItemID;
        private Suppliers _Supplier;
        private int _SupplierID;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ID for the supply orders
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
        /// Gets or sets the order number for the supply orders
        /// </summary>
        public int OrderNumber
        {
            get
            {
                return _OrderNumber;
            }
            set
            {
                _OrderNumber = value;
            }
        }
        /// <summary>
        /// Gets or sets the date requested for the supply orders
        /// </summary>
        public DateTime DateRequested
        {
            get
            {
                return _DateRequested;
            }
            set
            {
                _DateRequested = value;
            }
        }

        /// <summary>
        /// Gets or sets the date purchased for the supply orders
        /// </summary>
        public DateTime DatePurchased
        {
            get
            {
                return _DatePurchased;
            }
            set
            {
                _DatePurchased = value;
            }
        }

        /// <summary>
        /// Gets or sets the date recieved for the supply orders
        /// </summary>
        public DateTime DateRecieved
        {
            get
            {
                return _DateRecieved;
            }
            set
            {
                _DateRecieved = value;
            }
        }
        /// <summary>
        /// Gets or sets the item for the supply orders
        /// </summary>
        [XmlIgnore]
        public Items Item
        {
            get
            {
                if (_Item == null)
                {
                }
                return _Item;
            }
            set
            {
                _Item = value;
                if (value == null)
                {
                    _ItemID = -1;
                }
                else
                {
                    _ItemID = value.ID;
                }
            }
        }
        /// <summary>
        /// Gets or sets the ItemID for the supply orders
        /// </summary>
        public int ItemID
        {
            get
            {
                return _ItemID;
            }
            set
            {
                _ItemID = value;
            }
        }

        /// <summary>
        /// Gets or sets the supplier for the supply orders
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
        /// Gets or sets the supplierID for the supply orders
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