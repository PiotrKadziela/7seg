using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private double Nr { get; set; }
        private double Result { get; set; }
        private char Operation { get; set; }
        private bool ResultDisplayed { get; set; }
        public Form1()
        {
            InitializeComponent();
            _7seg5.Number = "0";
            Nr = 0;
            Result = 0;
            ResultDisplayed = true;
        }

        private void LengthCheck()
        {

            if (_7seg5.Number.Length > 14 && !_7seg5.Number.Contains(","))
                _7seg5.Number = _7seg5.Number.Substring(0, 14);
            else if (_7seg5.Number.Length > 15 && _7seg5.Number.Contains(","))
                _7seg5.Number = _7seg5.Number.Substring(0, 15);
        }

        private void WriteNr(string nr)
        {

            if (_7seg5.Number.Equals("0") || ResultDisplayed)
                _7seg5.Number = nr;
            else
                _7seg5.Number += nr;

            LengthCheck();
            _7seg5.Invalidate();

            if (!_7seg5.Number.Equals("-"))
                Nr = Convert.ToDouble(_7seg5.Number);

            if (ResultDisplayed && Operation.Equals('='))
                Result = 0;
            ResultDisplayed = false;
        }

        private void Calculation()
        {
            if (Operation.Equals('+'))
            {
                Result += Nr;
            }
            else if (Operation.Equals('-'))
            {
                Result -= Nr;
            }
            else if (Operation.Equals('*'))
            {
                Result = Result * Nr;
            }
            else if (Operation.Equals('/'))
            {
                Result = Result / Nr;
            }
            else
            {
                Result = Nr;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            WriteNr("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            WriteNr("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            WriteNr("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            WriteNr("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            WriteNr("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            WriteNr("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            WriteNr("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            WriteNr("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            WriteNr("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            WriteNr("0");
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Calculation();
            _7seg5.Number = Result.ToString();
            LengthCheck();
            _7seg5.Invalidate();
            Nr = Result;
            ResultDisplayed = true;
            Operation = '=';
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Calculation();
            Operation = '+';
            _7seg5.Number = Result.ToString();
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if ((ResultDisplayed || _7seg5.Number.Equals("-")) && !Operation.Equals('='))
            {
                _7seg5.Number = "-";
                ResultDisplayed = false;

            }
            else
            {
                Calculation();
                Operation = '-';
                _7seg5.Number = Result.ToString();
                ResultDisplayed = true;
            }
            LengthCheck();
            _7seg5.Invalidate();
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            if (!ResultDisplayed)
                Calculation();
            Operation = '*';
            _7seg5.Number = Result.ToString();
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            Calculation();
            Operation = '/';
            _7seg5.Number = Result.ToString();
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            _7seg5.Number = "0";
            Nr = 0;
            Result = 0;
            Operation = '\0';
            _7seg5.Number = Result.ToString();
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (ResultDisplayed)
            {
                _7seg5.Number = "0,";
                LengthCheck();
                _7seg5.Invalidate();
                Nr = 0;
                ResultDisplayed = false;
            }

            else if (!_7seg5.Number.Contains(","))
            {
                _7seg5.Number += ",";
                LengthCheck();
                _7seg5.Invalidate();
                ResultDisplayed = false;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (ResultDisplayed || _7seg5.Number.Length < 2)
            {
                _7seg5.Number = "0";
                _7seg5.Invalidate();
            }
            else
            {
                _7seg5.Number = _7seg5.Number.Substring(0,_7seg5.Number.Length-1);
                _7seg5.Invalidate();
                Nr = Convert.ToDouble(_7seg5.Number);
            }
        }
    }
}
