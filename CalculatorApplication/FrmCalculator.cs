using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculatorApplication
{
    public partial class FrmCalculator : Form
    {
        private CalculatorClass cal;
        private double num1;
        private double num2;
        public FrmCalculator()
        {
            InitializeComponent();
            cal = new CalculatorClass();

            cbOperator.Items.Add("+");
            cbOperator.Items.Add("-");
            cbOperator.Items.Add("*");
            cbOperator.Items.Add("/");

        }

        private void FrmCalculator_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                double num1 = double.Parse(txtBoxInput1.Text);
                double num2 = double.Parse(txtBoxInput2.Text);

               
                string selectedOperator = cbOperator.SelectedItem.ToString();

               
                double result = 0;

                
                switch (selectedOperator)
                {
                    case "+":
                        
                        cal._CalculateEvent += cal.GetSum;
                        
                        result = cal.GetSum(num1, num2);
                      
                        cal._CalculateEvent -= cal.GetSum;
                        break;

                    case "-":
                       
                        cal._CalculateEvent += cal.GetDifference;
                       
                        result = cal.GetDifference(num1, num2);
                       
                        cal._CalculateEvent -= cal.GetDifference;
                        break;

                    case "*":
                        
                        cal._CalculateEvent += cal.GetProduct;
                       
                        result = cal.GetProduct(num1, num2);
                       
                        cal._CalculateEvent -= cal.GetProduct;
                        break;

                    case "/":
                       
                        cal._CalculateEvent += cal.GetQuotient;
                        
                        result = cal.GetQuotient(num1, num2);
                       
                        cal._CalculateEvent -= cal.GetQuotient;
                        break;

                    default:
                        MessageBox.Show("Please select a valid arithmetic operator.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                }

              
                textBox1.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers in both text boxes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
