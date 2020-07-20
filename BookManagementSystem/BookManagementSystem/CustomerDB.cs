using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookManagementSystem
{
    static class CustomerDB
    {
        public static List<Customer> GetAllCustomers()
        {

            SqlConnection dbCon = DBHelper.GetConnection();

            SqlCommand getCustomersCmd =
                new SqlCommand();
            getCustomersCmd.Connection = dbCon;
            getCustomersCmd.CommandText =
                 "SELECT CustomerID, DateOfBirth, FirstName, LastName, Title FROM Customer";
            

            try
            {
                dbCon.Open();
                SqlDataReader rd =
                    getCustomersCmd.ExecuteReader();

                List<Customer> cust = new List<Customer>();
                while (rd.Read())
                {
                    Customer tempCust = new Customer();
                    tempCust.CustomerID = (int)rd["CustomerID"];
                    tempCust.DateOfBirth = (DateTime)rd["DateOfBirth"];
                    tempCust.FirstName = (string)rd["FirstName"];
                    tempCust.LastName = (string)rd["LastName"];
                    tempCust.Title = (string)rd["Title"];
                    cust.Add(tempCust);

                }
                return cust;
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        public static bool AddCustomer(Customer s)
        {
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCommand = new SqlCommand();

            string query = @" INSERT [dbo].[Customer]
                       (  [Title], [DateOfBirth], [FirstName], [LastName])

                 VALUES
                       (@Title, @DateOfBirth, @FirstName, @LastName)";

            addCommand.CommandText = query;
            addCommand.Connection = con;

            addCommand.Parameters.AddWithValue("@Title", s.Title);
            addCommand.Parameters.AddWithValue("@DateOfBirth", s.DateOfBirth);
            addCommand.Parameters.AddWithValue("@FirstName", s.FirstName);
            addCommand.Parameters.AddWithValue("@LastName", s.LastName);
            

            try
            {
                con.Open();
                int rows = addCommand.ExecuteNonQuery();
                if (rows == 1)
                    return true;

                return false;
            }
            finally
            {
                con.Dispose();
            }

        }
    }
}
