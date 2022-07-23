using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Panels.Model;
using Panels.ViewModels;
using Panels.Views;
using MetroFramework;
using System.Windows;

namespace Panels.Views
{
    public partial class Zeitarbeit : Form
    {
        BindingSource employeeBindingSource;
        BindingSource departmentBindingSource; 
        
        public Zeitarbeit()
        {
            InitializeComponent();
            initializeShiftCombobox();
            employeeBindingSource = new BindingSource();
            departmentBindingSource = new BindingSource();
        }
   
        public Employee SetEmployee()
        {
            string entryDepartName = txt_department.Text;
            Employee employee = null;
            int department_id = 0;

            if (!string.IsNullOrWhiteSpace(entryDepartName))
            {
                Department Department = new Department { Name = entryDepartName };
                department_id = EmployeeViewModel.getInstance().AddDepartment(Department);
                employee = new Employee
                {
                    FirstName = txt_firstName.Text,
                    LastName = txt_lastName.Text,
                    Design = txt_designation.Text,
                    Email = txt_Email.Text,
                    address = txt_address.Text,
                    Gender = rbMale.Checked ? "Male" : "Female",
                    Employee_ID = txt_EmpId.Text.ToString(),
                    Date_today = DateTime.Parse(date.Text.ToString()),
                    Date_from = DateTime.Parse(date_from.Text.ToString()),
                    Date_to = DateTime.Parse(date_to.Text.ToString()),
                    shift = txt_shift.Text,
                    Department_Id = department_id
                };
            }
          
            return employee;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            Employee employee = SetEmployee();
            if(employee == null)
            {
                setBorderColor();
                MetroMessageBox.Show(this, "Woups an error occured Please enter all Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!employee.FirstName.Equals("") && !employee.LastName.Equals("") && !employee.Gender.Equals("") && !employee.Design.Equals("") && !employee.Email.Equals("") && !employee.Date_today.Equals("") && !employee.Employee_ID.Equals("") && !employee.shift.Equals("") && !employee.shift.Equals("") && !employee.address.Equals(""))
            {
                setBorderColor();
                try
                {
                    EmployeeViewModel.getInstance().AddEmployee(employee);
                    this.tblEmployeesTableAdapter1.Fill(this.myDbDataSet1.tblEmployees);
                    MetroMessageBox.Show(this, "Data is successfully saved in the Database!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                    Reset();
                }
                catch(EmployeeAlreadyExistException ea)
                {
                    MetroMessageBox.Show(this, ea.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                setBorderColor();
                MetroMessageBox.Show(this, "Woups an error occured Please enter all Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            Employee employee = SetEmployee();
            if (employee == null)
            {
                setBorderColor();
                MetroMessageBox.Show(this, "Woups an error occured Please enter all Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!employee.FirstName.Equals("") && !employee.LastName.Equals("") && !employee.Gender.Equals("") && !employee.Design.Equals("") && !employee.Email.Equals("") && !employee.Date_today.Equals("") && !employee.Employee_ID.Equals("") && !employee.shift.Equals("") && !employee.address.Equals(""))
            {
                setBorderColor();
                EmployeeViewModel.getInstance().UpdateEmployee(employee);
                this.tblEmployeesTableAdapter1.Fill(this.myDbDataSet1.tblEmployees);
                MetroMessageBox.Show(this, "Data is successfully updated in the Database!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                setBorderColor();
                MetroMessageBox.Show(this, "Woups an error occured Please enter all Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            Employee employee = EmployeeViewModel.getInstance().GetEmployeeById(txt_EmpId.Text.ToString());
            
            if(employee!= null)
            {              
                txt_EmpId.Text = employee.Employee_ID;
                txt_department.Text = EmployeeViewModel.getInstance().GetDepartmentById(employee.Department_Id);
                txt_address.Text = employee.address;
                txt_designation.Text = employee.Design;
                txt_Email.Text = employee.Email;
                txt_firstName.Text = employee.FirstName;
                txt_lastName.Text = employee.LastName;
                txt_shift.Text = employee.shift;
                date.Value = DateTime.Parse(employee.Date_today.ToString());
                date_from.Value = DateTime.Parse(employee.Date_from.ToString());
                date_to.Value = DateTime.Parse(employee.Date_to.ToString());
                if (employee.Gender.Equals("Male"))
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }

                setBorderColor();
            }
            else
            {
                setBorderColor();
                MetroMessageBox.Show(this, "No Data or Employee with the id: " + txt_EmpId.Text + " does not exist in the Database.", "Database Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Reset()
        {
            txt_EmpId.Text = "";
            txt_department.Text = "";
            txt_address.Text = "";
            txt_designation.Text = "";
            txt_Email.Text = "";
            txt_firstName.Text = "";
            txt_lastName.Text = "";
            txt_shift.Text = "";
            date.Text = "";
            date_from.Text = "";
            date_to.Text = "";
        }
        private void setBorderColor()
        {
            if (string.IsNullOrWhiteSpace(txt_EmpId.Text))
            {
                lbId.ForeColor = Color.Red;
                
            }
            else
            {
                lbId.ForeColor = Color.Black;
               
            }
            if (string.IsNullOrWhiteSpace(txt_department.Text))
            {
                lbDepart.ForeColor = Color.Red;              
            }
            else
            {
                lbDepart.ForeColor = Color.Black;               
            }
            if (string.IsNullOrWhiteSpace(txt_address.Text))
            {
                lbAddress.ForeColor = Color.Red;              
            }
            else
            {
                lbAddress.ForeColor = Color.Black;
               
            }
            if (string.IsNullOrWhiteSpace(txt_designation.Text))
            {
                lbDesign.ForeColor = Color.Red;
            }
            else
            {
                lbDesign.ForeColor = Color.Black;
            }
            if (string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                lbEmail.ForeColor = Color.Red;
            }
            else
            {
                lbEmail.ForeColor = Color.Black;
            }
            if (string.IsNullOrWhiteSpace(txt_firstName.Text))
            {
                lbFirstName.ForeColor = Color.Red;
            }
            else {
                lbFirstName.ForeColor = Color.Black;
            }
            if (string.IsNullOrWhiteSpace(txt_lastName.Text))
            {
                lbLastName.ForeColor = Color.Red;
            }
            else
            {
                lbLastName.ForeColor = Color.Black;
            }
            if (string.IsNullOrWhiteSpace(txt_shift.Text))
            {
                lbShift.ForeColor = Color.Red;
            }
            else
            {
                lbShift.ForeColor = Color.Black;
            }

        }
        private void bt_delete_Click(object sender, EventArgs e)
        {
            string empId = txt_EmpId.Text.ToString();
            setBorderColor();
            if (!empId.Equals("") && MetroMessageBox.Show(this, "Are you sure you want to delete this Operation ?", "Delete operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    EmployeeViewModel.getInstance().DeleteEmployee(empId);
                    this.tblEmployeesTableAdapter1.Fill(this.myDbDataSet1.tblEmployees);
                    MetroMessageBox.Show(this, "The employee wth the Id: " + empId + " is successfully deleted from the Database!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (EmployeeNotFoundException Ex)
                {
                    MetroMessageBox.Show(this, Ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDbDataSet1.tblEmployees' table. You can move, or remove it, as needed.
            this.tblEmployeesTableAdapter1.Fill(this.myDbDataSet1.tblEmployees);
            tblDepartmentsTableAdapter.Fill(this.myDbDataSet1.tblDepartments);

            employeeBindingSource.DataSource = myDbDataSet1.Tables[1];
            departmentBindingSource.DataSource = myDbDataSet1.Tables[0];

            txt_firstName.DataBindings.Add(new Binding("Text", employeeBindingSource, "FirstName"));
            txt_lastName.DataBindings.Add(new Binding("Text", employeeBindingSource, "LastName"));
            txt_address.DataBindings.Add(new Binding("Text", employeeBindingSource, "address"));
            txt_designation.DataBindings.Add(new Binding("Text", employeeBindingSource, "Design"));
            txt_Email.DataBindings.Add(new Binding("Text", employeeBindingSource, "Email"));
            txt_EmpId.DataBindings.Add(new Binding("Text", employeeBindingSource, "Employee_ID"));
            txt_shift.DataBindings.Add(new Binding("Text", employeeBindingSource, "shift"));
            DataBindings.Add(new Binding("Text", employeeBindingSource, "Gender"));
            date_to.DataBindings.Add(new Binding("Text", employeeBindingSource, "Date_to"));
            date_from.DataBindings.Add(new Binding("Text", employeeBindingSource, "Date_from"));

            txt_department.DataBindings.Add(new Binding("Text", departmentBindingSource, "Name"));

            EmployeeDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.PowderBlue;
            EmployeeDataGridView.EnableHeadersVisualStyles = false;
            //backgroundWorker1.RunWorkerAsync();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Environment.Exit(0);            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_EmpId.Text = "";
            txt_department.Text = "";
            txt_address.Text = "";
            txt_designation.Text = "";
            txt_Email.Text = "";
            txt_firstName.Text = "";
            txt_lastName.Text = "";
            txt_shift.Text = "";
            date.Text = "";
            date_from.Text = "";
            date_to.Text = "";
        }

        private void EmployeeDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(EmployeeDataGridView.SelectedRows.Count > 0 && EmployeeDataGridView.SelectedRows[0].Cells[0].Value!= null)
            {
                txt_EmpId.Text = EmployeeDataGridView.SelectedRows[0].Cells[7].Value.ToString();
                txt_department.Text = EmployeeViewModel.getInstance().GetDepartmentById(Convert.ToInt16(EmployeeDataGridView.SelectedRows[0].Cells[12].Value)); 
                txt_address.Text = EmployeeDataGridView.SelectedRows[0].Cells[5].Value.ToString(); 
                txt_designation.Text = EmployeeDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                txt_Email.Text = EmployeeDataGridView.SelectedRows[0].Cells[4].Value.ToString();
                txt_firstName.Text = EmployeeDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                txt_lastName.Text = EmployeeDataGridView.SelectedRows[0].Cells[2].Value.ToString();

                if (EmployeeDataGridView.SelectedRows[0].Cells[6].Value.ToString().Equals("Male")) rbMale.Checked = true;
                else rbFemale.Checked = true;               
                txt_shift.Text = EmployeeDataGridView.SelectedRows[0].Cells[11].Value.ToString();               
                date_from.Text = EmployeeDataGridView.SelectedRows[0].Cells[9].Value.ToString();
                date_to.Text = EmployeeDataGridView.SelectedRows[0].Cells[10].Value.ToString();
            }
        }

        private void initializeShiftCombobox()
        {
            txt_shift.Items.Add("Frühschicht");
            txt_shift.Items.Add("Spätschicht");
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            employeeBindingSource.MovePrevious();
            employeeDataGridUpdate();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            employeeBindingSource.MoveFirst();
            employeeDataGridUpdate();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            employeeBindingSource.MoveLast();
            employeeDataGridUpdate();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            employeeBindingSource.MoveNext();
            employeeDataGridUpdate();
        }

        private void employeeDataGridUpdate()
        {
            EmployeeDataGridView.ClearSelection();
            EmployeeDataGridView.Rows[employeeBindingSource.Position].Selected = true;
        }
    }
}
