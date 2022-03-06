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

    public partial class FormUpdate : Form
    {

        ContactDashboard obj = (ContactDashboard)Application.OpenForms["ContactDashboard"];

        public FormUpdate()
        {
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var customerRepository = new CustomerRepository();
            ContactDashboard obj = (ContactDashboard)Application.OpenForms["ContactDashboard"];
            var wasUpdated = customerRepository.UpdateCustomerById(int.Parse(txtID.Text),txtFirstName.Text, txtSurname.Text, dateTimePicker1.Value, txtEmail.Text, txtPhone.Text);
            if (wasUpdated)
                MessageBox.Show("Record Updated with Success");
            else
                MessageBox.Show("Failure to update Record");

            txtEmail.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();
            txtSurname.Clear();
            dateTimePicker1.ResetText();
            obj.LoadData();

        }
        public void PopulateTextBoxes(Customer record) 
        {
            txtID.Text = record.Id.ToString();
            txtEmail.Text = record.Email;
            txtFirstName.Text = record.FirstName;
            txtPhone.Text = record.PhoneNumber;
            txtSurname.Text = record.LastName;
            dateTimePicker1.Text = record.DOB.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            obj.ClearData();
            obj.LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();
            txtSurname.Clear();
            dateTimePicker1.ResetText();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Surname_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
