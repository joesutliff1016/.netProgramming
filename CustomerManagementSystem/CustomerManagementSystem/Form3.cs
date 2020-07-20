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
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidProductData())
            {
                Product prodToBeAdded = new Product();

               
                prodToBeAdded.Name = cboProduct.Text;
                

                try
                {
                    if (ProductDB.AddProduct(prodToBeAdded))
                        MessageBox.Show("Product added.");
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

               
 
        private bool IsValidProductData()
        {
            return
                !Validator.IsEmpty(cboProduct.Text);
        }
    }
}


