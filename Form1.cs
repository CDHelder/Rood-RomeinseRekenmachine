using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rood_RomeinseRekenmachine
{
    public partial class Form1 : Form
    {
        double resultvalue = 0;
        string operationPerformed = "";
        bool isOperationPerformed;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (isOperationPerformed))
            {
                textBox1.Text = "";
            }

            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button operatorButton = (Button)sender;
            if ((resultvalue != 0) && (labelInvoer.Text != ""))
            {
                buttonCalculate.PerformClick();
                operationPerformed = operatorButton.Text;
                labelInvoer.Text = resultvalue + " " + operatorButton.Text;
                isOperationPerformed = true;
                textBox1.Text = "0";
            }
            else
            {
                operationPerformed = operatorButton.Text;
                resultvalue = Double.Parse(textBox1.Text);
                labelInvoer.Text = textBox1.Text + " " + operatorButton.Text;
                isOperationPerformed = true;
                textBox1.Text = "0";
            }
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            labelInvoer.Text = "";
            operationPerformed = "";
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = "0";
            }
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
                switch (operationPerformed)
                {
                    case "/":
                        textBox1.Text = (resultvalue / Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "-":
                        textBox1.Text = (resultvalue - Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "+":
                        textBox1.Text = (resultvalue + Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "X":
                        textBox1.Text = (resultvalue * Double.Parse(textBox1.Text)).ToString();
                        break;
                    default:
                        break;
                }
                resultvalue = Double.Parse(textBox1.Text);
                labelInvoer.Text = "";
                isOperationPerformed = false;
        }
    }
}
