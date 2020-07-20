using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem
{
    public static class TechSupportDB 
    {
        public static SqlConnection GetConnection()
        {
            
            return new SqlConnection(@"Data Source = KRISHOME\SQLEXPRESS; Initial Catalog = TechSupport; Integrated Security = True"); 
            

       
        }
    }
}
