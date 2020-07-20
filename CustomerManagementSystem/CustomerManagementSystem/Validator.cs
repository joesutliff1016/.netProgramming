using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagementSystem
{
    class Validator
    {
        public static bool IsEmpty(string testStr)
        {
           
            return string.IsNullOrWhiteSpace(testStr);
        }

       
        public static bool IsEmpty(TextBox box)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDateTime(string test)
        {
            try
            {
                Convert.ToDateTime(test);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

