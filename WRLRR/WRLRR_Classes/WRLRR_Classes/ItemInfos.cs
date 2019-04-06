using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes
{
    public static class ItemInfos
    {
        private static List<ItemInfo> _ItemInfoList = new List<ItemInfo>();

        public static List<ItemInfo> ItemInfoList {
            get { return _ItemInfoList; }
            set { _ItemInfoList = value; }
        }

        public static void AddItemInfo(ItemInfo i)
        {
            _ItemInfoList.Add(i);
        }
    }
}
