using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes
{
    public class SerialNumbers
    {
        public SerialNumbers()
        {
        }

        public const string db_SerialNumber = "SerialNumber";

        private string _SerialNumber;

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

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            SerialNumber = dr[db_SerialNumber].ToString();
        }
    }
}
