using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagementSystem
{
    static class ProductDB
    {
        
        

        public static List<Product> GetProducts()
        {
            
            SqlConnection dbCon = TechSupportDB.GetConnection();

            SqlCommand getProductsCmd =
                new SqlCommand();
            getProductsCmd.Connection = dbCon;
            getProductsCmd.CommandText =
                "SELECT ProductCode, Name, Version, ReleaseDate FROM Products";

            try
            {
                dbCon.Open();
                SqlDataReader rd =
                    getProductsCmd.ExecuteReader();

                List<Product> prods = new List<Product>();
                while (rd.Read())
                {
                    Product tempProd = new Product();
                    tempProd.ProductCode = (char)rd["ProductCode"];
                    tempProd.Name = rd["Name"].ToString();
                    tempProd.Version = (char)rd["Version"];
                    tempProd.ReleaseDate = (DateTime)rd["ReleaseDate"];


                    prods.Add(tempProd);
                }
                return prods;
            }
            finally
            {
                dbCon.Dispose();
            }




        }
        public static bool AddProduct(Product s)
        {
            SqlConnection con = TechSupportDB.GetConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"INSERT INTO [dbo].[Products]
                              ([ProductCode], [Name], [Version], [ReleaseDate])
                        VALUES
                              (@ProductCode, @Name, @Version, @ReleaseDate)";


            cmd.Parameters.AddWithValue("@ProductCode", s.ProductCode);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Version", s.Version);
            cmd.Parameters.AddWithValue("@ReleaseDate", s.ReleaseDate);






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
