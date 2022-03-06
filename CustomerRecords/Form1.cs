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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtpassword.Clear();
            this.txtUsername.Clear();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            CustomerRepository customerRepository = new CustomerRepository();

            var isUserValid=customerRepository.ValidateUser(txtUsername.Text, txtpassword.Text);
            if (isUserValid)
            {
                var frm = new ContactDashboard();
                frm.Show();
                
            }
            else
                MessageBox.Show("User Not Valid");

        }
    }
}
