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
    public partial class ContactDashboard : Form
    {
        DataGridViewRow SelectedRow { get; set; }
        CustomerRepository customerRepository = new CustomerRepository();

        public ContactDashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var addUserFrm = new frmAddUser();
            addUserFrm.Show();
        }
        public void LoadData() 
        {

            var records = customerRepository.GetCustomer();

            foreach (var r in records)
            {
                dataGridView1.Rows.Add(r.Id, r.FirstName, r.LastName, r.DOB, r.PhoneNumber, r.Email, r.CreatedOne, r.LastUpdated);
            }
        }
        public void ClearData() 
        {
            dataGridView1.Rows.Clear();
        }
        private void ContactDashboard_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                var text = "Are you sure you want to delete this Contact";
                var caption = "Delete Contact";
                var confirmation= MessageBox.Show(text,caption ,MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                var selectedId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (confirmation == DialogResult.Yes)
                {
                    if (customerRepository.DeleteContact(int.Parse(selectedId)))
                    {
                        MessageBox.Show("Contact Deleted with Success");
                        ClearData();
                        LoadData();
                    }
                    else 
                    {
                        MessageBox.Show("Failure to Delete Contact");
                        LoadData();
                    }
                }
                else 
                {
                    MessageBox.Show("NO");
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row");
                dataGridView1.Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            FormUpdate frm = new FormUpdate();
            
            
            if (dataGridView1.CurrentRow.Cells[0].Value != null) 
            {
                var selectedId = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                var rec = customerRepository.GetCustomerByID(int.Parse(selectedId));

                frm.PopulateTextBoxes(rec);
                dataGridView1.Rows.Clear();
                frm.Show();    
            }
            else
            {
                MessageBox.Show("Please Select a Row");
                dataGridView1.Refresh();
            }


        }

        private void btnShowDeletedContacts_Click(object sender, EventArgs e)
        {
            var frm=new frmDeletedContacts();
            frm.Show();
        }
    }
}
