using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WRLRR_Classes {
    public static class Employees {

        private static List<Employee> _EmployeeList = new List<Employee>();

        public static List<Employee> EmployeeList {
            get { return _EmployeeList; }
        }

        public static void AddEmployee(Employee emp) {
            _EmployeeList.Add(emp);
        }
        
    }
}
