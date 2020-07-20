using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {

            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
               
            
            if (IsValidData())
            {
                if (Convert.ToDecimal(txtOperand1.Text) <= 0
                    || Convert.ToDecimal(txtOperand1.Text) >= 1000000
                    || Convert.ToDecimal(txtOperand2.Text) <= 0
                    || Convert.ToDecimal(txtOperand2.Text) >= 1000000)
                {
                    MessageBox.Show("Please enter a number between 0 and 1,000,000(non-inclusive).");
                    return;

                }

                decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
                decimal operand2 = Convert.ToDecimal(txtOperand2.Text);
                string Operator = txtOperator.Text;

                decimal result = Calculate(operand1, operand2, Operator);
                result = Math.Round(result, 4);
                this.txtResult.Text = result.ToString();

            }
           
        }

        private bool IsPresent(TextBox box)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
                return false;
            return true;

        }

        private bool IsValidData()
        {
            return IsPresent(txtOperand1)
                && IsPresent(txtOperand2)
                && IsPresent(txtOperator)
                && IsDecimal(txtOperand1)
                && IsDecimal(txtOperand2)
                && IsOperator((txtOperator));

        }

        private bool IsOperator(TextBox box)
        {
            if (box.Text == ("-") || box.Text == ("+") || box.Text == ("*") || box.Text == ("/"))
            {
                Convert.ToString(box.Text);
                return true;
            }
            else if (box.Text != ("-") || box.Text != ("+") || box.Text != ("*") || box.Text != ("/"))

                MessageBox.Show("Must enter an operator.");
                box.Focus();
                return false;

        }


        private bool IsDecimal(TextBox box)
        {
            
            try
            {
               
                Convert.ToDecimal(box.Text);
                return true;
            }
            catch
            {
                MessageBox.Show("Must enter a number.");
                box.Focus();
                return false;

            }


        }


               
        private decimal Calculate(decimal operand1, decimal operand2, string Operator)
        {
         
                decimal result = 0;

                if (Operator == "+")
                    result = operand1 + operand2;
                else if (Operator == "-")
                    result = operand1 - operand2;
                else if (Operator == "/")

                    result = operand1 / operand2;
                else if (Operator == "*")
                    result = operand1 * operand2;
                return result;
       
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

   
    
        private void txtOperand1_TextChanged(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void txtOperand2_TextChanged(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void txtOperator_TextChanged(object sender, EventArgs e)
        {
            txtResult.Clear();

        }
    }
}
