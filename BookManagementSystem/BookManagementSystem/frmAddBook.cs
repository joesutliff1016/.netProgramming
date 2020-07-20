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
    public partial class frmAddBook : Form
    {
        public frmAddBook()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            SqlConnection connection = DBHelper.GetConnection();

            Book bookToBeAdded = new Book();
            bookToBeAdded.ISBN = txtISBN.Text;
            bookToBeAdded.Price = Convert.ToDecimal(txtPrice.Text);
            bookToBeAdded.Title = txtTitle.Text;

            try
            {
                if (BookDB.AddBook(bookToBeAdded))
                    MessageBox.Show("Added!");

                Application.Restart();

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
       
