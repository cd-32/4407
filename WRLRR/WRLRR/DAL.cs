using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WRLRR_Classes;

namespace WRLRR {
    public static class DAL {

        private static string _EditConnectionString = "Server=;Database=;User Id =; Password=;";
        private static string _ReadConnectionString = "Server=;Database=;User Id =; Password=;";        

        #region Employees

        /// <summary>
        /// Get all Employees from the database
        /// </summary>
        /// <returns></returns>
        internal static void GetAllEmployees() {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocEmployeesGetALL", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dr = command.ExecuteReader();
                
                while (dr.Read()) {
                    Employee emp = new Employee();
                    emp.Fill(dr);
                    Employees.EmployeeList.Add(emp);
                }

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }

        }

        /// <summary>
        /// Get and employee from the datbase by their ID
        /// </summary>
        /// <param name="id">The Employee Database ID</param>
        /// <returns></returns>
        public static Employee GetEmployee(int id) {

            Employee retEmp = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocEmployeeGet",conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{Employee.db_ID}", id);
                SqlDataReader dr = command.ExecuteReader();

                Employee emp = new Employee();
                while (dr.Read()) {                    
                    emp.Fill(dr);
                }

                retEmp = emp;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }
            return retEmp;

        }

        public static int AddEmployee(Employee e) {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _EditConnectionString;

            int recordAdded = -1;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sproc_EmployeeAdd", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue($"@{People.db_FirstName}", e.Person.FirstName);
                command.Parameters.AddWithValue($"@{People.db_MiddleName}", e.Person.MiddleName);
                command.Parameters.AddWithValue($"@{People.db_LastName}", e.Person.LastName);
                command.Parameters.AddWithValue($"@{Employee.db_EmployeeNumber}", e.EmployeNumber.ToString());

                recordAdded = command.ExecuteNonQuery();
                
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }

            return recordAdded;        

        }

        public static int UpdateEmployee(Employee e) {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _EditConnectionString;

            int recordUpdated = -1;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sproc_EmployeeUpdate", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{Employee.db_ID}", e.ID);
                command.Parameters.AddWithValue($"@{People.db_FirstName}", e.Person.FirstName);
                command.Parameters.AddWithValue($"@{People.db_MiddleName}", e.Person.MiddleName);
                command.Parameters.AddWithValue($"@{People.db_LastName}", e.Person.LastName);
                command.Parameters.AddWithValue($"@{Employee.db_EmployeeNumber}", e.EmployeNumber.ToString());

                recordUpdated = command.ExecuteNonQuery();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }

            return recordUpdated;

        }


        public static Employee GetEmployeeByFirstName(string FirstName) {
            Employee retEmp = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocEmployeesFindName", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{People.db_FirstName}", FirstName);
                SqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Fill(dr);
                    Employees.EmployeeList.Add(emp);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return retEmp;
        }

        public static int DoesEmployeeExistByName(Employee e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;
            int value = 0;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocEmployeeFind", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue($"@{People.db_FirstName}", e.Person.FirstName);
                command.Parameters.AddWithValue($"@{People.db_LastName}", e.Person.LastName);
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    value = (int)dr["Exists"];
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                conn.Close();
            }
            return value;
        }

        #endregion

        #region Sales Forms

        /// <summary>
        /// Get all the Sales form information from the database
        /// </summary>
        public static void GetAllSalesForms() {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocSalesFormsGetALL", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read()) {
                    SalesForm sf = new SalesForm();
                    sf.Fill(dr);
                    SalesForms.SalesFormList.Add(sf);
                }

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }

        }

        /// <summary>
        /// Get a Sales Forms information by it's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SalesForm GetSalesForm(int id) {

            SalesForm retSalesForm = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocSalesFormGet", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{SalesForm.db_ID}", id);
                SqlDataReader dr = command.ExecuteReader();

                SalesForm sf = new SalesForm();
                while (dr.Read()) {
                    sf.Fill(dr);
                }

                retSalesForm = sf;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }
            return retSalesForm;

        }

        /// <summary>
        /// Add a new Sales Form
        /// </summary>
        /// <param name="sf"></param>
        /// <returns></returns>
        public static int AddSalesForm(SalesForm sf) {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _EditConnectionString;

            int recordAdded = -1;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sproc_SalesFormAdd", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{SalesForm.db_DateIssued}", sf.DateIssued);
                command.Parameters.AddWithValue($"@{SalesForm.db_Amount}", sf.Amount);

                recordAdded = command.ExecuteNonQuery();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }

            return recordAdded;

        }

        /// <summary>
        /// Update and existing Sales Form
        /// </summary>
        /// <param name="sf"></param>
        /// <returns></returns>
        public static int UpdateSalesForm(SalesForm sf) {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _EditConnectionString;

            int recordUpdated = -1;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sproc_SalesFormUpdate", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{SalesForm.db_ID}", sf.ID);
                command.Parameters.AddWithValue($"@{SalesForm.db_DateIssued}", sf.DateIssued);
                command.Parameters.AddWithValue($"@{SalesForm.db_Amount}", sf.Amount);

                recordUpdated = command.ExecuteNonQuery();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }

            return recordUpdated;

        }

        #endregion

        #region Customer

        public static void GetAllCustomers() {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocCustomersGetALL", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read()) {
                    Customer cust = new Customer();
                    cust.Fill(dr);
                    Customers.CustomerList.Add(cust);
                }

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }
        }

        public static Customer GetCustomer(int id) {

            Customer retCust = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocCustomerGet", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{Customer.db_ID}", id);
                SqlDataReader dr = command.ExecuteReader();

                Customer cust = new Customer();
                while (dr.Read()) {
                    cust.Fill(dr);
                }

                retCust = cust;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }
            return retCust;

        }

        public static int AddCustomer(Customer c) {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _EditConnectionString;

            int recordAdded = -1;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sproc_CustomerAdd", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{People.db_FirstName}", c.Person.FirstName);
                command.Parameters.AddWithValue($"@{People.db_MiddleName}", c.Person.MiddleName);
                command.Parameters.AddWithValue($"@{People.db_LastName}", c.Person.LastName);
                command.Parameters.AddWithValue($"@{Customer.db_CustomerNumber}", c.CustomerNumber.ToString());

                recordAdded = command.ExecuteNonQuery();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }

            return recordAdded;

        }

        public static int UpdateCustomer(Customer c) {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _EditConnectionString;

            int recordUpdated = -1;

            try {
                conn.Open();
                SqlCommand command = new SqlCommand("sproc_CustomerUpdate", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{Customer.db_ID}", c.ID);
                command.Parameters.AddWithValue($"@{People.db_FirstName}", c.Person.FirstName);
                command.Parameters.AddWithValue($"@{People.db_MiddleName}", c.Person.MiddleName);
                command.Parameters.AddWithValue($"@{People.db_LastName}", c.Person.LastName);
                command.Parameters.AddWithValue($"@{Customer.db_CustomerNumber}", c.CustomerNumber.ToString());

                recordUpdated = command.ExecuteNonQuery();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally {
                conn.Close();
            }

            return recordUpdated;

        }

        #endregion

        #region Miscellaneous

        public static int AddLocation(Cities c, ZipCodes z, States s)
        {

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = _EditConnectionString;

            int recordsAdded = -1;

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("sproc_LocationAdd", conn);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{Cities.db_Name}", c.Name);

                command.Parameters.AddWithValue($"@{States.db_Name}", s.Name);

                command.Parameters.AddWithValue($"@{States.db_Abbreviation}", s.Abbreviation);

                command.Parameters.AddWithValue($"@{ZipCodes.db_Number}", z.Number);

                recordsAdded = command.ExecuteNonQuery();

            }

            catch (Exception e)

            {
                System.Diagnostics.Debug.WriteLine(e.Message);

            }
            finally
            {
                conn.Close();
            }

            return recordsAdded;
        }

        public static List<PurchaseInformation> GetPurchases(DateTime dt)
        {
            List<PurchaseInformation> retlist = new List<PurchaseInformation>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocPurchaseInformation", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PurchaseDate", dt);
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    PurchaseInformation safor = new PurchaseInformation();
                    safor.Fill(dr);
                    retlist.Add(safor);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                conn.Close();
            }
            return retlist;
        }

        public static List<SerialNumbers> GetSerialNumber(DateTime startDate, DateTime endDate) {
            List<SerialNumbers> retlist = new List<SerialNumbers>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("sprocReturnsSerialNumber", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@FirstDate", startDate);
                comm.Parameters.AddWithValue("@SecondDate", endDate);
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    SerialNumbers sn = new SerialNumbers();
                    sn.Fill(dr);
                    retlist.Add(sn);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return retlist;
        }

        public static void GetModelInfoByDate(DateTime d, ProductCategories pc)
        {


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocModelInfoByDate", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Date", d));
                command.Parameters.AddWithValue($"@{ProductCategories.db_ID}", pc.ID);

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    ItemInfo inf = new ItemInfo();
                    inf.Fill(dr);
                    ItemInfos.ItemInfoList.Add(inf);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<ItemGetByServiceTechnician> GetItemByTechnician(int id)
        {
            List<ItemGetByServiceTechnician> retList = new List<ItemGetByServiceTechnician>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocItemGetByServiceTechnician", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TechnicianID", id);
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    ItemGetByServiceTechnician st = new ItemGetByServiceTechnician();
                    st.Fill(dr);
                    retList.Add(st);

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                conn.Close();
            }
            return retList;
        }

        public static List<ModelDescription> GetRepairsByYear(DateTime date) {
            List<ModelDescription> retlist = new List<ModelDescription>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("sprocRepairsInAYear", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@Date", date);
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    ModelDescription md = new ModelDescription();
                    md.Fill(dr);
                    retlist.Add(md);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return retlist;
        }

        public static void GetSupplierByLessThanOrderNumber(int o)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _ReadConnectionString;

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("sprocSupplierGetOrders", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NumberOfOrders", o));

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Supplier s = new Supplier();
                    s.Fill(dr);
                    Suppliers.SupplierList.Add(s);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                conn.Close();
            }
        }


        #endregion


    }
}
