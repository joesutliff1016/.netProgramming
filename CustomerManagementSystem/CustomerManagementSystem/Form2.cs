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

namespace CustomerManagementSystem
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //validate form data
            if (IsValidCustomerData())
            {
                //if valid, create and populate object
                Customer custToBeAdded = new Customer();

                custToBeAdded.Name = txtAddCustomer.Text;
                custToBeAdded.Address = txtAddress.Text;
                custToBeAdded.City = txtCity.Text;
                custToBeAdded.State = (txtState.Text);
                custToBeAdded.ZipCode = txtZipCode.Text;


                //add to database 



                try
                {
                    if (CustomerDB.AddCustomer(custToBeAdded))
                        MessageBox.Show("Added");
                }
                catch (SqlException ex)
                {

                    throw ex;
                    //MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }
    
                
  
            
            private bool IsValidCustomerData()
        {
            return
                !Validator.IsEmpty(txtAddCustomer.Text);
                
                
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
           

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            

        }
    }
}
