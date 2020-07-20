using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookManagementSystem
{
    static class BookDB
    {
        public static List<Book> GetAllBooks()
        {
            SqlConnection dbCon = DBHelper.GetConnection();

            SqlCommand getBooksCmd =
                new SqlCommand();
            getBooksCmd.Connection = dbCon;
            getBooksCmd.CommandText = "SELECT ISBN, Price, Title FROM Book";

            try
            {
                dbCon.Open();
                SqlDataReader rd =
                    getBooksCmd.ExecuteReader();

                List<Book> book = new List<Book>();
                while (rd.Read())
                {
                    Book books = new Book();
                    books.ISBN = (string)rd["ISBN"];
                    books.Price = (decimal)rd["Price"];
                    books.Title = (string)rd["Title"];
                    book.Add(books);
                }
                return book;
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        public static bool AddBook(Book s)
        {
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCommand = new SqlCommand();

            string query = @" INSERT INTO [dbo].[Book]
                       ( [Title], [ISBN], [Price])

                 VALUES
                       (@Title, @ISBN, @Price)";

            addCommand.CommandText = query;
            addCommand.Connection = con;


            addCommand.Parameters.AddWithValue("@Title", s.Title);
            addCommand.Parameters.AddWithValue("@ISBN", s.ISBN);
            addCommand.Parameters.AddWithValue("@Price", s.Price);
         
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

 