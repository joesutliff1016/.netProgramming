using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookManagementSystem
{
    public partial class FrmAddCustomer : Form
    {
        public FrmAddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = DBHelper.GetConnection();
          

            Customer custToBeAdded = new Customer();

            
            custToBeAdded.Title = cboTitle.Text;
            custToBeAdded.FirstName = txtFirstName.Text;
            custToBeAdded.LastName = txtLastName.Text;
            custToBeAdded.DateOfBirth = Convert.ToDateTime(txtDOB.Text);

            try
            {
                if (CustomerDB.AddCustomer(custToBeAdded))
                    MessageBox.Show("Added!");

                Application.Restart();

            }

            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void FrmAddCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
