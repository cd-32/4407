using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes
{
    public static class Suppliers
    {
        private static List<Supplier> _SupplierList = new List<Supplier>();

        public static List<Supplier> SupplierList {
            get { return _SupplierList; }
            set { _SupplierList = value; }
        }

        public static void AddSupplier(Supplier s)
        {
            _SupplierList.Add(s);
        }
    }
}
