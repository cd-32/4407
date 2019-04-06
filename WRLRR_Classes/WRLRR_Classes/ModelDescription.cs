using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLRR_Classes
{
    public class ModelDescription
    {
        public ModelDescription()
        {
        }


        public const string db_ModelNumber = "ModelNumber";
        public const string db_Description = "Description";
        


        private string _ModelNumber;
        private string _Description;
        


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

       
        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {

            Description = dr[db_Description].ToString();
            ModelNumber = dr[db_ModelNumber].ToString();
           
        }
    }
}

