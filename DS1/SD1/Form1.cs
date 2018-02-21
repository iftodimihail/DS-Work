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
        private bool dividedByZero = false;
        private const char guardian = '#'; //a flag to know when you reached the bottom of the stack
        private static char[] operators = { '+', '-', '*', '/', '^', '(' };

        //Hashmap for operators in the expresion
        private static Dictionary<char, int> opPriorityExpr = new Dictionary<char, int>()
        {
            {'#', -1},
            {'+', 1}, {'-', 1},
            {'*', 2}, {'/', 2},
            {'^', 4},
            {'(', 5}
        };

        //Hashmap for operators in the expresion in the Operators' Stack
        private static Dictionary<char, int> opPriorityStack = new Dictionary<char, int>()
        {
            {'#', -1},
            {'+', 1}, {'-', 1},
            {'*', 2}, {'/', 2},
            {'^', 3},
            {'(', 0}
        };

        private string Postfix(string expr)
        {
            StringBuilder sb = new StringBuilder();
            Stack<char> operatorStack = new Stack<char>();
            operatorStack.Push(guardian);

            foreach (char c in expr)
            {
                if (Char.IsDigit(c) || c == ',')
                {
                    sb.Append(c);
                }

                if (operators.Contains(c))
                {
                    if(c != '(')
                        sb.Append(' ');

                    if (opPriorityExpr[c] <= opPriorityStack[operatorStack.Peek()])
                    {
                        sb.Append(operatorStack.Pop());
                        sb.Append(' ');
                    }
                    operatorStack.Push(c);
                }
                else if (c == ')')
                {
                    sb.Append(' ');
                    while (operatorStack.Peek() != '(')
                    {
                        sb.Append(operatorStack.Pop());
                        sb.Append(' ');
                    }
                    operatorStack.Pop();
                }
            } // end of foreach loop

            while (operatorStack.Peek() != guardian)
            {
                sb.Append(operatorStack.Pop());
                sb.Append(' ');
            }
            return sb.ToString().Trim();
        }

        private string Evaluate(string expr)
        {
            double nmb = 0.0;
            //var chars = expr.ToCharArray();
            var vals = expr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<double> operandStack = new Stack<double>();

            foreach(string val in vals)
            {
                if (double.TryParse(val, out double a)) //verifies if val can be converted to double
                {
                    nmb = double.Parse(val);
                    operandStack.Push(nmb);
                }
                else //means val is an operator
                {
                    string op = string.Empty;
                    double firstOperand = operandStack.Pop();
                    double secondOperand = operandStack.Pop();

                    op = val;
                    switch (op)
                    {
                        case "+":
                            operandStack.Push(secondOperand + firstOperand);
                            break;
                        case "-":
                            operandStack.Push(secondOperand - firstOperand);
                            break;
                        case "*":
                            operandStack.Push(secondOperand * firstOperand);
                            break;
                        case "/":
                            if(Math.Abs(firstOperand) <= 1e-6) // verifies if operand we try to devide by is close to 0
                            {
                                dividedByZero = true;
                                operandStack.Push(0); //just so I don't get Empty stack
                            }
                            else
                                operandStack.Push(secondOperand / firstOperand);
                            break;
                        case "^":
                            operandStack.Push(Math.Pow(secondOperand, firstOperand));
                            break;
                    }
                }
            }
            if (dividedByZero)
            {
                return "Devided by Zero";
            }
            else
                return operandStack.Pop().ToString();
        }


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
                case "1":
                    display.Text += "1";
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
                case ",":
                    display.Text += ",";
                    break;
                case "(":
                    display.Text += "(";
                    break;
                case ")":
                    display.Text += ")";
                    break;
            }
        }

        private void equalsBtn_Click(object sender, EventArgs e)
        {
            display.Text = (Evaluate(Postfix(display.Text))).ToString();
            dividedByZero = false;
        }
    }
}
