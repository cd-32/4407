using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes {
    public static class SalesForms {

        private static List<SalesForm> _SalesFormList = new List<SalesForm>();

        public static List<SalesForm> SalesFormList {
            get { return _SalesFormList; }
        }

        public static void AddSalesForm(SalesForm sf) {
            _SalesFormList.Add(sf);
        }

    }
}
