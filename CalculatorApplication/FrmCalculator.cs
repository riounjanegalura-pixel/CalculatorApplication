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

         
            cbOperator.SelectedIndex = 0;



        }

        private void FrmCalculator_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                num1 = double.Parse(txtBoxInput1.Text);
                num2 = double.Parse(txtBoxInput2.Text);

             
                cal._CalculateEvent += cal.GetSum;
                cal._CalculateEvent += cal.GetDifference;

                cal.InvokeCalculateEvent(num1, num2);

                double sumResult = cal.GetSum(num1, num2);
                double differenceResult = cal.GetDifference(num1, num2);
                textBox1.Text = $"Sum: {sumResult}\nDifference: {differenceResult}";

                cal._CalculateEvent -= cal.GetSum;
                cal._CalculateEvent -= cal.GetDifference;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers in both text boxes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
