using CustomerRecords.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRecords
{
    public partial class frmAddUser : Form
    {
        private DataGridViewRow selectedCustomer;

        public frmAddUser()
        {
            InitializeComponent();
        }
        ContactDashboard obj = (ContactDashboard)Application.OpenForms["ContactDashboard"];


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            obj.ClearData();
            obj.LoadData();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //clear and reset all the inputs
            txtEmail.Clear();
            txtFirstName.Clear();
            txtSurname.Clear();
            txtPhone.Clear();
            dateTimePicker1.ResetText();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var customerRepository=new CustomerRepository();

            var wasCreated = customerRepository.AddContact(txtFirstName.Text, txtSurname.Text, dateTimePicker1.Value, txtPhone.Text, txtEmail.Text);

            if (wasCreated)
                MessageBox.Show("Contact Added to the Database with Success!");
            else
                MessageBox.Show("Failure to Add Contact to Database!");

            txtEmail.Clear();
            txtFirstName.Clear();
            txtSurname.Clear();
            txtPhone.Clear();
            dateTimePicker1.ResetText();
            obj.LoadData();
            
            
        }
    }
}
