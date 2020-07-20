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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCustomerComboBox();
            LoadBookComboBox();
            DateTime currentDate = DateTime.Today;
        }

        private void LoadCustomerComboBox()
        {
            List<Customer> cust = new List<Customer>();
            try
            {
                cust = CustomerDB.GetAllCustomers();
                cboCustomer.DataSource = cust;
                cboCustomer.DisplayMember = "FullName";
                cboCustomer.ValueMember = "CustomerID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());

            }
        }

        private void LoadBookComboBox()
        {
            List<Book> book = new List<Book>();
            try
            {
                book = BookDB.GetAllBooks();
                cboBook.DataSource = book;
                cboBook.DisplayMember = "Title";
                cboBook.ValueMember = "ISBN";
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());

            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration regToBeAdded = new Registration();

            regToBeAdded.ISBN = cboBook.SelectedValue.ToString();
            regToBeAdded.RegDate = dateTimePicker1.Value;
            regToBeAdded.CustomerID = Convert.ToInt32(cboCustomer.SelectedValue.ToString());

            try
            {
                if (BookRegistrationDB.AddRegistration(regToBeAdded))
                    MessageBox.Show("Registration added!");
               
            }
            catch (SqlException ex)
            {
                throw ex;

            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            FrmAddCustomer secondForm = new FrmAddCustomer();
            secondForm.Show();

        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddBook thirdForm = new frmAddBook();
            thirdForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cboBook.Text = " ";
            cboCustomer.Text = " ";
        }
  
        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}


           
        


