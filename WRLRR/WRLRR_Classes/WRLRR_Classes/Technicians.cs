using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deliverable_6
{
    class Technicians
    {
        #region Constuctors
        public Technicians() { }
        #endregion

        #region Database String
        internal const string db_ID = "ID";
        internal const string db_TechNumber = "Tech Number";
        internal const string db_WeeklyHours = "Weekly Hours";
        internal const string db_HourlyWage = "Hourly Wage";
        #endregion

        #region Private Variables
        private int _ID;
        private int _TechNumber;
        private decimal _WeeklyHours;
        private decimal _HourlyWage;
        private Employees _Employee;
        #endregion

        #region Public Properties 
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int TechNumber
        {
            get { return _TechNumber; }
            set { _TechNumber = value; }
        }

        
        public decimal WeeklyHours
        {
            get { return _WeeklyHours; }
            set { _WeeklyHours = value; }
        }

        
        public decimal HourleyWage
        {
            get { return _HourlyWage; }
            set { _HourlyWage = value; }
        }

        [XmlIgnore]
        public Employees Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        #endregion

        public void Fill(System.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _TechNumber = (int)dr[db_TechNumber];
            _WeeklyHours = (decimal)dr[db_WeeklyHours];
            _HourlyWage = (decimal)dr[db_HourlyWage];
        }
    }
}
