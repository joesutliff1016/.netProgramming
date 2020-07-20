using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectangleTwo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, System.EventArgs e)
        {
            decimal length = Convert.ToDecimal(txtLength.Text);
            decimal width = Convert.ToDecimal(txtWidth.Text);

            decimal area = length * width;
            decimal perimeter = 2 * width + 2 * length;

            Area.Text = area.ToString();
            Perimeter.Text = perimeter.ToString();
            txtLength.Focus();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        

        
        }
    }
}
