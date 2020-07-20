using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CustomerManagementSystem
{
    static class CustomerDB
    {
        public static List<Customer> GetCustomers()
        {

            SqlConnection dbCon = TechSupportDB.GetConnection();

            SqlCommand getCustomersCmd =
                new SqlCommand();
            getCustomersCmd.Connection = dbCon;
            getCustomersCmd.CommandText =
                "SELECT CustomerID, Name, Address, City, State, ZipCode FROM Customers";

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
                    tempCust.Name = rd["Name"].ToString();
                    tempCust.Address = (string)rd["Address"];
                    tempCust.City = (string)rd["City"];
                    tempCust.State = (char)rd["State"];
                    tempCust.ZipCode = (string)rd["ZipCode"];


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
            SqlConnection con = TechSupportDB.GetConnection();

            SqlCommand addCommand =
                new SqlCommand();
            string query = @"INSERT INTO [dbo].[Customers]
                       ( [CustomerID],[Name], [Address], [City], [State], [ZipCode])

                 VALUES
                       ( @Name, @Address, @City, @State, @ZipCode)";
            addCommand.CommandText = query;
            addCommand.Connection = con;


            addCommand.Parameters.AddWithValue("@CustomerID", s.CustomerID);
            addCommand.Parameters.AddWithValue("@Name", s.Name);
            addCommand.Parameters.AddWithValue("@Address", s.Address);
            addCommand.Parameters.AddWithValue("@City", s.City);
            addCommand.Parameters.AddWithValue("@State", s.State);
            addCommand.Parameters.AddWithValue("@ZipCode", s.ZipCode);




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





