using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SD1
{
    public partial class Calculator : Form
    {
        string input = string.Empty;
        public Calculator()
        {
            InitializeComponent();
            display.Text = "";
        }

        private void Button_Number(object sender, EventArgs e)
        {
            string number = sender.ToString().Substring(sender.ToString().Length - 1, 1);
            Console.WriteLine(number);
            switch (number)
            {
                case "1": display.Text += "1";
                    break;
                case "2":
                    display.Text += "2";
                    break;
                case "3":
                    display.Text += "3";
                    break;
                case "4":
                    display.Text += "4";
                    break;
                case "5":
                    display.Text += "5";
                    break;
                case "6":
                    display.Text += "6";
                    break;
                case "7":
                    display.Text += "7";
                    break;
                case "8":
                    display.Text += "8";
                    break;
                case "9":
                    display.Text += "9";
                    break;
                case "0":
                    display.Text += "0";
                    break;
            }
        }

        private void display_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button_Operator(object sender, EventArgs e)
        {
            string oprator = sender.ToString().Substring(sender.ToString().Length - 1, 1);
            switch (oprator)
            {
                case "+":
                    display.Text += "+";
                    break;
                case "-":
                    display.Text += "-";
                    break;
                case "*":
                    display.Text += "*";
                    break;
                case "/":
                    display.Text += "/";
                    break;
                case "^":
                    display.Text += "^";
                    break;
                case ".":
                    display.Text += ".";
                    break;
                case "(":
                    display.Text += "(";
                    break;
                case ")":
                    display.Text += ")";
                    break;
            }
        }
    }
}
