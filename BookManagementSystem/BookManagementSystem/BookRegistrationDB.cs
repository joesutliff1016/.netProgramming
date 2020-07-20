using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookManagementSystem
{
    static class BookRegistrationDB
    {
        public static List<Registration> RegisterBook()
        {
            SqlConnection dbCon = DBHelper.GetConnection();

            SqlCommand registerBooksCmd =
                new SqlCommand();
            registerBooksCmd.Connection = dbCon;
            registerBooksCmd.CommandText = "SELECT CustomerID, ISBN, RegDate FROM Registration";
            try
            {
                dbCon.Open();
                SqlDataReader rd =
                    registerBooksCmd.ExecuteReader();

                List<Registration> reg = new List<Registration>();
                while (rd.Read())
                {
                    Registration tempReg = new Registration();
                    tempReg.CustomerID = (int)rd["CustomerID"];
                    tempReg.ISBN = (string)rd["ISBN"];
                    tempReg.RegDate = (DateTime)rd["RegDate"];
                    reg.Add(tempReg);
                }
                return reg;
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        public static bool AddRegistration(Registration s)
        {

            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCommand = new SqlCommand();

            string query = @"INSERT INTO [dbo].[Registration]
                                 ([CustomerID]
                                , [ISBN]
                                , [RegDate])
                        VALUES 
                                 (@CustomerID
                                 ,@ISBN
                                 ,@RegDate)";

            addCommand.CommandText = query;
            addCommand.Connection = con;

            addCommand.Parameters.AddWithValue("@CustomerID", s.CustomerID);
            addCommand.Parameters.AddWithValue("@ISBN", s.ISBN);
            addCommand.Parameters.AddWithValue("@RegDate", s.RegDate);

            try
            {
                con.Open();
                int rows =
                    addCommand.ExecuteNonQuery();
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
