using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WRLRR_Classes;

namespace WRLRR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Employees        

        /// <summary>
        /// Get all Employees in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAllEmployees_Click(object sender, RoutedEventArgs e)
        {

            lvShowData.Items.Clear();
            Employees.EmployeeList.Clear();

            DAL.GetAllEmployees();

            foreach (Employee empl in Employees.EmployeeList)
            {
                lvShowData.Items.Add(empl);
            }

        }

        /// <summary>
        /// Get and employee by their ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetEmployee_Click(object sender, RoutedEventArgs e)
        {

            Employee emp = DAL.GetEmployee(int.Parse(tbEmployeeID.Text));

            UpdateEmployeeTextboxes(emp);

            lvShowData.Items.Clear();

            lvShowData.Items.Add($"{emp.Person.FirstName} {emp.Person.LastName}");

        }

        /// <summary>
        /// Add a new employee to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

            Employee emp = new Employee
            {
                Person = new People()
                {
                    FirstName = tbFirstName.Text,
                    MiddleName = tbMiddleName.Text,
                    LastName = tbLastName.Text,
                },
                EmployeNumber = int.Parse(tbEmployeeNumber.Text)
            };

            int employeeAdded = DAL.AddEmployee(emp);

            lvShowData.Items.Clear();

            if (employeeAdded > 1)
            {
                lvShowData.Items.Add("Success! The Employee was added to the database.");
            }
            else
            {
                lvShowData.Items.Add("Failure! The Employee was not added to the database.");
            }
        }

        /// <summary>
        /// update and existing employee with any changes that have been made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUPdateEmployee_Click(object sender, RoutedEventArgs e)
        {

            lvShowData.Items.Clear();

            Employee newEmp = new Employee()
            {
                ID = int.Parse(tbEmployeeID.Text)
                ,
                EmployeNumber = int.Parse(tbEmployeeNumber.Text)
            };
            newEmp.Person.FirstName = tbFirstName.Text;
            newEmp.Person.MiddleName = tbMiddleName.Text;
            newEmp.Person.LastName = tbLastName.Text;

            Employee oldEmp = new Employee()
            {
                ID = int.Parse(tbEmployeeID.Text)
            };

            oldEmp = DAL.GetEmployee(oldEmp.ID);

            int employeeAdded = DAL.UpdateEmployee(newEmp);

            if (employeeAdded > 1)
            {
                lvShowData.Items.Add($"You have updated employee {oldEmp.Person.FirstName} {oldEmp.Person.LastName} to {newEmp.Person.FirstName} {newEmp.Person.LastName}");
            }
            else
            {
                lvShowData.Items.Add("Failure! The Employee was not updated in the database.");
            }

        }

        /// <summary>
        /// Enable the update employee button when an employee id has been entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEmployeeID_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text != null)
            {
                btnUPdateEmployee.IsEnabled = true;
            }
            else
            {
                btnUPdateEmployee.IsEnabled = false;
            }
        }

        /// <summary>
        /// Update all the Textboxes in the Employee section
        /// </summary>
        /// <param name="emp"></param>
        private void UpdateEmployeeTextboxes(Employee emp)
        {
            tbEmployeeID.Text = emp.ID.ToString();
            tbFirstName.Text = emp.Person.FirstName;
            tbMiddleName.Text = emp.Person.MiddleName;
            tbLastName.Text = emp.Person.LastName;
            tbEmployeeNumber.Text = emp.EmployeNumber.ToString();
        }

        /// <summary>
        /// Clear all the textoxes in the employee section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearEmployee_Click(object sender, RoutedEventArgs e)
        {
            tbEmployeeID.Text = "";
            tbFirstName.Text = "";
            tbMiddleName.Text = "";
            tbLastName.Text = "";
            tbEmployeeNumber.Text = "";
            lvShowData.Items.Clear();
        }
        private void btnDoesEmployeeExist_Click(object sender, RoutedEventArgs e)
        {
            lvShowData.Items.Clear();
            int val;
            Employee emp = new Employee();
            emp.Person.FirstName = tbFirstName.Text;
            emp.Person.LastName = tbLastName.Text;
            val = DAL.DoesEmployeeExistByName(emp);
            if (val == 1)
            {
                lvShowData.Items.Add("Employee was found.");
            }
            else
            {
                lvShowData.Items.Add("Employee was not found.");
            }
        }
        #endregion

        #region Customers

        /// <summary>
        /// Get All customers in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAllCustomers_Click(object sender, RoutedEventArgs e)
        {

            lvShowData.Items.Clear();
            Customers.CustomerList.Clear();

            DAL.GetAllCustomers();

            foreach (Customer cust in Customers.CustomerList)
            {
                lvShowData.Items.Add(cust);
            }

        }

        /// <summary>
        /// Get a customer by their ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetCustomer_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(tbCustomerID.Text))
            {
                Customer cust = DAL.GetCustomer(int.Parse(tbCustomerID.Text));

                UpdateCustomerTextboxes(cust);

                lvShowData.Items.Clear();

                lvShowData.Items.Add($"{cust.Person.FirstName} {cust.Person.LastName}");
            }

        }

        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer
            {
                Person = new People()
                {
                    FirstName = tbCFirstName.Text,
                    MiddleName = tbCMiddleName.Text,
                    LastName = tbCLastName.Text,
                },
                CustomerNumber = int.Parse(tbCustomerNumber.Text)
            };

            int customerAdded = DAL.AddCustomer(cust);

            lvShowData.Items.Clear();

            if (customerAdded > 0)
            {
                lvShowData.Items.Add("Success! The Customer was added to the database.");
            }
            else
            {
                lvShowData.Items.Add("Failure! The Customer was not added to the database.");
            }
        }

        /// <summary>
        /// Update the customers data with any changes that have been made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {

            lvShowData.Items.Clear();

            Customer newcust = new Customer()
            {
                ID = int.Parse(tbCustomerID.Text)
                ,
                CustomerNumber = int.Parse(tbCustomerNumber.Text)
            };
            newcust.Person.FirstName = tbCFirstName.Text;
            newcust.Person.MiddleName = tbCMiddleName.Text;
            newcust.Person.LastName = tbCLastName.Text;

            Customer oldCust = new Customer()
            {
                ID = int.Parse(tbCustomerID.Text)
            };

            oldCust = DAL.GetCustomer(oldCust.ID);

            int customerAdded = DAL.UpdateCustomer(newcust);

            if (customerAdded > 1)
            {
                lvShowData.Items.Add($"You have updated Customer {oldCust.Person.FirstName} {oldCust.Person.LastName} to {newcust.Person.FirstName} {newcust.Person.LastName}");
            }
            else
            {
                lvShowData.Items.Add("Failure! The Customer was not updated in the database.");
            }

        }

        /// <summary>
        /// Enable the update button if the Customer Id has been populated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCustomerID_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text != null)
            {
                btnUpdateCustomer.IsEnabled = true;
            }
            else
            {
                btnUpdateCustomer.IsEnabled = false;
            }
        }

        /// <summary>
        /// Clear the Customer section of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCustomer_Click(object sender, RoutedEventArgs e)
        {
            tbCustomerID.Text = "";
            tbCFirstName.Text = "";
            tbCMiddleName.Text = "";
            tbCLastName.Text = "";
            tbCustomerNumber.Text = "";
            lvShowData.Items.Clear();
        }

        /// <summary>
        /// Update all the texboxes on the form
        /// </summary>
        /// <param name="cust"></param>
        private void UpdateCustomerTextboxes(Customer cust)
        {

            tbCustomerID.Text = cust.ID.ToString();
            tbCFirstName.Text = cust.Person.FirstName;
            tbCMiddleName.Text = cust.Person.MiddleName;
            tbCLastName.Text = cust.Person.LastName;
            tbCustomerNumber.Text = cust.CustomerNumber.ToString();

        }

        #endregion

        #region Sales Forms

        /// <summary>
        /// Get all the Sales Form data from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAllSalesForms_Click(object sender, RoutedEventArgs e)
        {

            lvShowData.Items.Clear();
            SalesForms.SalesFormList.Clear();

            DAL.GetAllSalesForms();

            foreach (SalesForm sf in SalesForms.SalesFormList)
            {
                lvShowData.Items.Add(sf);
            }
        }

        /// <summary>
        /// Get a Sales Form information by it's ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetSalesForm_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(tbSalesFormID.Text))
            {
                SalesForm sf = DAL.GetSalesForm(int.Parse(tbSalesFormID.Text));

                UpdateSalesFormTextboxes(sf);

                lvShowData.Items.Clear();

                lvShowData.Items.Add($"Date Issued = {sf.DateIssued.ToShortDateString()} for the amount of ${sf.Amount}");
            }

        }

        /// <summary>
        /// Add a sales form to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSalesForm_Click(object sender, RoutedEventArgs e)
        {

            SalesForm sf = new SalesForm
            {
                DateIssued = (DateTime)dpDateIssued.SelectedDate
                ,
                Amount = decimal.Parse(tbAmount.Text)
            };

            int salesFormAdded = DAL.AddSalesForm(sf);

            lvShowData.Items.Clear();

            if (salesFormAdded > 0)
            {
                lvShowData.Items.Add("Success! The Sales Form was added to the database.");
            }
            else
            {
                lvShowData.Items.Add("Failure! The Sales Form was not added to the database.");
            }

        }

        /// <summary>
        /// Enable the update sales form button when and ID is in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSalesFormID_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox tb = (TextBox)sender;

            if (tb.Text != null)
            {
                btnUpdateSalesForm.IsEnabled = true;
            }
            else
            {
                btnUpdateSalesForm.IsEnabled = false;
            }

        }

        /// <summary>
        /// Update the sales form in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateSalesForm_Click(object sender, RoutedEventArgs e)
        {

            lvShowData.Items.Clear();

            SalesForm newSF = new SalesForm()
            {
                ID = int.Parse(tbSalesFormID.Text)
                ,
                DateIssued = (DateTime)dpDateIssued.SelectedDate
                ,
                Amount = decimal.Parse(tbAmount.Text)
            };

            SalesForm oldSF = new SalesForm()
            {
                ID = int.Parse(tbSalesFormID.Text)
            };

            oldSF = DAL.GetSalesForm(oldSF.ID);

            int salesFormUpdated = DAL.UpdateSalesForm(newSF);

            if (salesFormUpdated > 0)
            {
                lvShowData.Items.Add($"You have updated Sales Form Date Issued: {oldSF.DateIssued}, Amount: ${oldSF.Amount} to Date Issued: {newSF.DateIssued} , Amount: ${newSF.Amount}");
            }
            else
            {
                lvShowData.Items.Add("Failure! The Sales Form was not updated in the database.");
            }

        }

        private void ClearSalesForm_Click(object sender, RoutedEventArgs e)
        {

            tbSalesFormID.Text = "";
            tbAmount.Text = "";
            dpDateIssued.ClearValue(DatePicker.SelectedDateProperty);
            dpDateIssued.SelectedDate = null;
            lvShowData.Items.Clear();
        }

        /// <summary>
        /// Update all the texboxes on the form
        /// </summary>
        /// <param name="sf"></param>
        private void UpdateSalesFormTextboxes(SalesForm sf)
        {

            tbSalesFormID.Text = sf.ID.ToString();
            dpDateIssued.SelectedDate = sf.DateIssued;
            tbAmount.Text = sf.Amount.ToString();

        }

        #endregion

        /// <summary>
        /// Used to show the data on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvShowData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListView lv = (ListView)sender;
            if (lv.Items.Count > 0)
            {
                if (lv.SelectedItem is Employee)
                {
                    UpdateEmployeeTextboxes((Employee)lv.SelectedItem);
                }
                else if (lv.SelectedItem is Customer)
                {
                    UpdateCustomerTextboxes((Customer)lv.SelectedItem);
                }
                else if (lv.SelectedItem is SalesForm)
                {
                    UpdateSalesFormTextboxes((SalesForm)lv.SelectedItem);
                }
            }

        }

        private void btnFindEmployeeFirstName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddLocation_Click(object sender, RoutedEventArgs e)
        {
            lvShowData.Items.Clear();

            ZipCodes z = new ZipCodes();
            Cities c = new Cities();
            States s = new States();

            z.Number = int.Parse(tbZipCode.Text);
            c.Name = tbCityName.Text;
            s.Name = tbStateName.Text;
            s.Abbreviation = tbStateAbbreviation.Text;





            int locationAdded = DAL.AddLocation(c, z, s);

            if (locationAdded > 0)
            {
                lvShowData.Items.Add($"You have added a location.");
            }
            else
            {
                lvShowData.Items.Add("Failure! The Location was not added to the database.");
            }
        }

        private void btnGetSuppliers_Click(object sender, RoutedEventArgs e)
        {
            lvShowData.Items.Clear();
            Suppliers.SupplierList.Clear();
            int orderCount = int.Parse(tbNumberOfOrders.Text);

            DAL.GetSupplierByLessThanOrderNumber(orderCount);

            foreach (Supplier supp in Suppliers.SupplierList)
            {
                lvShowData.Items.Add($"{supp.Name} | {supp.Number}");
            }
        }

        private void btnGetItemInfo_Click(object sender, RoutedEventArgs e)
        {
            lvShowData.Items.Clear();
            ItemInfos.ItemInfoList.Clear();

            DateTime d = (DateTime)dpDatePurchased.SelectedDate;
            ProductCategories pc = new ProductCategories();
            pc.ID = int.Parse(tbCategoryID.Text);

            DAL.GetModelInfoByDate(d, pc);

            foreach (ItemInfo ii in ItemInfos.ItemInfoList)
            {
                lvShowData.Items.Add($"{ii.ModelNumber} | {ii.SerialNumber}");
            }

        }
        private void btnPurchaseInfoByDate_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime dateToUse = (DateTime)dpDate.SelectedDate;
            List<PurchaseInformation> listsf = DAL.GetPurchases(dateToUse);
            lvShowData.Items.Clear();
            foreach (PurchaseInformation sfs in listsf)
            {
                lvShowData.Items.Add($"{sfs.FirstName} {sfs.LastName} Model: {sfs.ModelNumber} | Serial Number: {sfs.SerialNumber} | Date Issued: {sfs.DateIssued}");
            }
        }

        private void btnTechID_Click_1(object sender, RoutedEventArgs e)
        {
            int techID = int.Parse(tbTechID.Text);
            List<ItemGetByServiceTechnician> listi = DAL.GetItemByTechnician(techID);
            lvShowData.Items.Clear();
            foreach (ItemGetByServiceTechnician ist in listi)
            {
                lvShowData.Items.Add($"Equipment Serial Number: {ist.SerialNumber} | Equipment Repair Number: {ist.RepairNumber}");
            }
        }

        private void btnFindEmployeeName_Click(object sender, RoutedEventArgs e)
        {
            Employees.EmployeeList.Clear();
            lvShowData.Items.Clear();

            Employee emp = DAL.GetEmployeeByFirstName(tbFirstName.Text);

            foreach (Employee empl in Employees.EmployeeList)
            {
                lvShowData.Items.Add(empl);
            }
        }

        private void btRepairYear_Click(object sender, RoutedEventArgs e)
        {
            lvShowData.Items.Clear();
            DateTime date;
            date = (DateTime)dpDate.SelectedDate;
            foreach (ModelDescription md in DAL.GetRepairsByYear(date))
            {
                lvShowData.Items.Add($"Model:{md.ModelNumber} | Description:{md.Description}");
            }
        }

        private void btGetSerial_Click(object sender, RoutedEventArgs e)
        {

            lvShowData.Items.Clear();

            DateTime dStart;
            DateTime dEnd;
            dStart = (DateTime)dpStart.SelectedDate;
            dEnd = (DateTime)dpEnd.SelectedDate;
            foreach (SerialNumbers sn in DAL.GetSerialNumber(dStart, dEnd))
            {
                lvShowData.Items.Add($"Serial Number: {sn.SerialNumber}");
            }

        }

    }
}
