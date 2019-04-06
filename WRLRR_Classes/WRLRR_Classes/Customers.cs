using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WRLRR_Classes {
    public static class Customers {

        private static List<Customer> _CustomerList = new List<Customer>();

        public static List<Customer> CustomerList {
            get { return _CustomerList; }
        }

        public static void AddEmployee(Customer cust) {
            _CustomerList.Add(cust);
        }
    }
}
