using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagementSystem
{
    static class RegistrationDB
    {
        public static bool AddRegistration(Registration s)
        {

            SqlConnection con = TechSupportDB.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"INSERT INTO [dbo].[Registrations]
                              ([CustomerID]
                              ,[ProductCode]
                              ,[RegistrationDate])
                        VALUES 
                               (@CustomerID
                               ,@ProductCode
                               ,@RegistrationDate)";
            cmd.Parameters.AddWithValue("@CustomerID", s.CustomerID);
            cmd.Parameters.AddWithValue("@ProductCode", s.ProductCode);
            cmd.Parameters.AddWithValue("@RegistrationDate", s.RegistrationDate);
            try
            {
                con.Open();
                int rowsAffected =
                    cmd.ExecuteNonQuery();
                if (rowsAffected == 1)

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