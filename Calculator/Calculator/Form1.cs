using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        float num1 = 0;
        string operation = ""; // variables that let calc remember the numbers & operators clicked

        float currentValue = 0;
        string currentOperator = "";
        bool isNewEntry = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // get which button was clicked

            if (isNewEntry)
            {
                txtNum1.Text = btn.Text;
                isNewEntry = false;
            }
            else
            {
                txtNum1.Text += btn.Text;
            }
        }


        private void Form1_Click(object sender, EventArgs e)
        {

        }


        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            float input = float.Parse(txtNum1.Text);

            if (currentOperator != "")
            {
                if (currentOperator == "+")
                    currentValue += input;
                else if (currentOperator == "-")
                    currentValue -= input;
                else if (currentOperator == "*")
                    currentValue *= input;
                else if (currentOperator == "/")
                {
                    if (input != 0)
                        currentValue /= input;
                    else
                        MessageBox.Show("Cannot divide by zero.");
                }
            }
            else
            {
                currentValue = input;
            }

            txtNum1.Text = currentValue.ToString();
            currentOperator = btn.Text;
            isNewEntry = true;
        }


        private void EqualsButton_Click(object sender, EventArgs e)
        {
            float input = float.Parse(txtNum1.Text);

            if (currentOperator == "+")
            {
                currentValue += input;
            }
            else if (currentOperator == "-")
            {
                currentValue -= input;
            }
            else if (currentOperator == "*")
            {
                currentValue *= input;
            }
            else if (currentOperator == "/")
            {
                if (input != 0)
                {
                    currentValue /= input;
                }
                else
                {
                    MessageBox.Show("Cannot divide by zero.");
                    return;
                }
            }

            txtNum1.Text = currentValue.ToString();
            currentOperator = "";
            isNewEntry = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            txtNum1.Text = "";
            num1 = 0;
            operation = "";
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (txtNum1.Text.Length > 0)
            {
                txtNum1.Text = txtNum1.Text.Substring(0, txtNum1.Text.Length - 1); // Remove the last character from the display
            }

            if (txtNum1.Text == "") // If the box becomes empty, show 0
            {
                txtNum1.Text = "0";
            }
        }
        private void DecimalButton_Click(object sender, EventArgs e)
        {
         
            if (!txtNum1.Text.Contains(".")) // Only add a decimal if one doesn't already exist in the current number
            {
                txtNum1.Text += ".";
            }
        }
        private void ChangeSignButton_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtNum1.Text, out float value))
            {
                value = -value; // Flip the sign
                txtNum1.Text = value.ToString();
            }
        }

        private void PercentageButton_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtNum1.Text, out float value))
            {
                value = value / 100; // Convert to percentage
                txtNum1.Text = value.ToString();
            }
        }

    }
}
