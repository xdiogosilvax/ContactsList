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
    public partial class frmDeletedContacts : Form
    {
        ContactDashboard obj = (ContactDashboard)Application.OpenForms["ContactDashboard"];
        CustomerRepository customerRepository = new CustomerRepository();
        public frmDeletedContacts()
        {
            InitializeComponent();
        }

        private void frmDeletedContacts_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData() 
        {
            var records = customerRepository.GetDeletedRecords();

            foreach (var r in records)
            {
                dataGridView1.Rows.Add(r.Id, r.FirstName, r.LastName, r.DOB, r.PhoneNumber, r.Email, r.CreatedOne, r.LastUpdated);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            obj.ClearData();
            obj.LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRecoverContact_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                var selectedId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (customerRepository.RecoverContact(int.Parse(selectedId)))
                {
                    MessageBox.Show("Contact Recovered with sucess");
                    dataGridView1.Rows.Clear();
                    LoadData();
                    obj.ClearData();
                    obj.LoadData();

                }
                else 
                {
                    MessageBox.Show("Failed to recover Customer Record");
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row");
                dataGridView1.Refresh();
            }






        }
    }
}
