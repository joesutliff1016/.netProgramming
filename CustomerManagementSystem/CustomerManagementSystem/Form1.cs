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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.customersTableAdapter.Fill(this.techSupportDataSet.Customers);
            this.productsTableAdapter.Fill(this.techSupportDataSet4.Products);

            DateTime currentDate = DateTime.Today;
            txtRegDate.Text = currentDate.ToShortDateString();

            PopulateCustomerListBox();

      
          

        }

        private void PopulateCustomerListBox()
        {
            cboBoxCustomer.Items.Clear();
            List<Customer> customers = CustomerDB.GetCustomers();
            foreach (var s in customers)
            {
                cboBoxCustomer.Items.Add(s);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void txtRegDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cboBoxCustomer.Text = " ";
            cboBoxProduct.Text = " ";


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {



            if (IsValidCustomerData())
            {
                Customer custToBeAdded = new Customer();
                Product prodToBeAdded = new Product();
                Registration regToBeAdded = new Registration();



                custToBeAdded.Name = cboBoxCustomer.Text;
                prodToBeAdded.Name = cboBoxProduct.Text;
                regToBeAdded.RegistrationDate = Convert.ToDateTime(txtRegDate.Text);


                try
                {
                    if (RegistrationDB.AddRegistration(regToBeAdded))
                        MessageBox.Show("Registration added!");
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //MessageBox.Show("Error");

                }
            }
            else MessageBox.Show("Invalid data");
        }

                
            

        private bool IsValidCustomerData()
        {
            return
                !Validator.IsEmpty(cboBoxCustomer.Text)
                &&
                !Validator.IsEmpty(cboBoxProduct.Text)
                &&
                Validator.IsDateTime(txtRegDate.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

          
        }

        private void btnAddCust_Click(object sender, EventArgs e)
        {
            frmAddProduct thirdForm = new frmAddProduct();
            thirdForm.Show();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmAddCustomer secondForm = new frmAddCustomer();
            secondForm.Show();
        }
    }
}













