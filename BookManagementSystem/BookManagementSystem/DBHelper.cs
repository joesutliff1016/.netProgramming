using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookManagementSystem
{
    static class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=KRISHOME\SQLEXPRESS;Initial Catalog=BookRegistration;Integrated Security=True");
        }
    }
}
