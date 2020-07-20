using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactorialCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, System.EventArgs e)
        {
            long num = Convert.ToInt64(txtNumber.Text);
            long factorial = 1;


            while (num > 0 && num <= 20)
            {
                factorial *= num;
                num--;
            }
            txtFactorial.Text = factorial.ToString("n0");
            txtNumber.Focus();
        }
            


        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
