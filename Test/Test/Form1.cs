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
        private double PNr { get; set; }
        private double PResult { get; set; }
        private char POperation { get; set; }
        private bool ResultDisplayed { get; set; }
        private double Memory { get; set; }
        private bool Bracket { get; set; }
        private bool FirstNumberInBrucket { get; set; }
        private bool InvFlag { get; set; }

        public Form1()
        {
            InitializeComponent();
            _7seg5.Number = "0";
            Nr = 0;
            Result = 0;
            Memory = 0;
            Operation = '=';
            PNr = 0;
            PResult = 0;
            ResultDisplayed = true;
            Bracket = false;
            FirstNumberInBrucket = false;
            InvFlag = false;
        }

        private void PCalculation()
        {
            if (POperation.Equals('+'))
            {
                PResult += PNr;
            }
            else if (POperation.Equals('-'))
            {
                PResult -= PNr;
            }
            else if (POperation.Equals('*'))
            {
                PResult = PResult * PNr;
            }
            else if (POperation.Equals('/'))
            {
                PResult = PResult / PNr;
            }
            else if (POperation.Equals('^'))
            {
                PResult = Math.Pow(PResult,PNr);
            }
            else if (POperation.Equals('r'))
            {
                PResult = Math.Pow(PResult, 1/PNr);
            }
            else
            {
                PResult = Convert.ToDouble(_7seg5.Number);
            }

            POperation = '\0';
        }

        private void LengthCheck()
        {

            if (_7seg5.Number.Length > 14 && !_7seg5.Number.Contains(","))
                _7seg5.Number = _7seg5.Number.Substring(0, 14);
            else if (_7seg5.Number.Length > 15 && _7seg5.Number.Contains(","))
                _7seg5.Number = _7seg5.Number.Substring(0, 15);

            InvFlag = false;
        }

        private void WriteNr(string nr)
        {

            if (_7seg5.Number.Equals("0") || ResultDisplayed || FirstNumberInBrucket)
            {
                _7seg5.Number = nr;
                FirstNumberInBrucket = false;
            }
            else
                _7seg5.Number += nr;

            LengthCheck();
            _7seg5.Invalidate();

            if (!_7seg5.Number.Equals("-"))
            {
                if (Bracket)
                    PNr = Convert.ToDouble(_7seg5.Number);
                else
                    Nr = Convert.ToDouble(_7seg5.Number);
            }

            if (ResultDisplayed && Operation.Equals('='))
                Result = 0;
            ResultDisplayed = false;
        }

        private void Calculation()
        {
            if (!ResultDisplayed)
            {
                if (Operation.Equals('+'))
                {
                    if (Bracket)
                        Result += PResult;
                    else
                        Result += Nr;
                }
                else if (Operation.Equals('-'))
                {
                    if (Bracket)
                        Result -= PResult;
                    else
                        Result -= Nr;
                }
                else if (Operation.Equals('*'))
                {
                    if (Bracket)
                        Result = Result * PResult;
                    else
                        Result = Result * Nr;
                }
                else if (Operation.Equals('/'))
                {
                    if (Bracket)
                        Result = Result / PResult;
                    else
                        Result = Result / Nr;
                }
                else if (Operation.Equals('^'))
                {
                    if (Bracket)
                        Result = Math.Pow(Result,PResult);
                    else
                        Result = Math.Pow(Result, Nr);
                }
                else if (Operation.Equals('r'))
                {
                    if (Bracket)
                        Result = Math.Pow(Result,1/PResult);
                    else
                        Result = Math.Pow(Result,1/Nr);
                }
                else
                {
                    if (Bracket)
                        Result = PResult;
                    else
                        Result = Convert.ToDouble(_7seg5.Number);
                }
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
            PNr = 0;
            PResult = 0;
            POperation = '\0';
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                POperation = '+';
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Operation = '+';
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
            Nr = 0;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if ((FirstNumberInBrucket || ResultDisplayed || _7seg5.Number.Equals("-")) && !Operation.Equals('='))
            {
                _7seg5.Number = "-";
                ResultDisplayed = false;
                FirstNumberInBrucket = false;

            }
            else
            {
                if (Bracket)
                {
                    PCalculation();
                    POperation = '-';
                    _7seg5.Number = PResult.ToString();

                }
                else
                {
                    Calculation();
                    Operation = '-';
                    _7seg5.Number = Result.ToString();
                }
                
                ResultDisplayed = true;
            }
            LengthCheck();
            _7seg5.Invalidate();
            Nr = 0;
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                POperation = '*';
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Operation = '*';
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
            Nr = 0;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                POperation = '/';
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Operation = '/';
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            Nr = 0;
            ResultDisplayed = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            _7seg5.Number = "0";
            PNr = 0;
            PResult = 0;
            POperation = '\0';
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
                if (Bracket)
                    PNr = Convert.ToDouble(_7seg5.Number);
                else
                    Nr = Convert.ToDouble(_7seg5.Number);
            }
        }

        private void btnMr_Click(object sender, EventArgs e)
        {            
            _7seg5.Number = Memory.ToString();

            if (!_7seg5.Number.Equals("-"))
            {
                if (Bracket)
                    PNr = Convert.ToDouble(_7seg5.Number);
                else
                    Nr = Convert.ToDouble(_7seg5.Number);
            }

            LengthCheck();
            _7seg5.Invalidate();

            ResultDisplayed = true;
        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            Memory += Convert.ToDouble(_7seg5.Number);
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            Memory -= Convert.ToDouble(_7seg5.Number);
        }

        private void btnMc_Click(object sender, EventArgs e)
        {
            Memory = 0;
        }

        private void btnBracketOpen_Click(object sender, EventArgs e)
        {
            Bracket = true;
            FirstNumberInBrucket = true;
            _7seg5.Bracket = true;
            _7seg5.Invalidate();
        }

        private void btnBracketClose_Click(object sender, EventArgs e)
        {
            PCalculation();
            Nr = PResult;
            Bracket = false;
            ResultDisplayed = false;
            Calculation();
            _7seg5.Number = Result.ToString();
            ResultDisplayed = true;
            _7seg5.Bracket = false;
            _7seg5.Invalidate();
        }

        private void btn1divx_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                PResult = 1/PResult;
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Result = 1 / Result;
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnXpow2_Click(object sender, EventArgs e)
        {
            
            if (Bracket)
            {
                PCalculation();
                PResult = Math.Pow(PResult, 2);
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Result = Math.Pow(Result, 2);
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnXpow3_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                PResult = Math.Pow(PResult, 3);
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Result = Math.Pow(Result, 3);
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnXpowY_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                POperation = '^';
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Operation = '^';
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
            Nr = 0;
        }

        private void btnFactorialX_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                int x = 0;
                for(int i = 1; i<=PResult; i++)
                {
                    x += i;
                }
                PResult = x;
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                int x = 0;
                for (int i = 1; i <= Result; i++)
                {
                    x += i;
                }
                Result = x;
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnSqrtX_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                PResult = Math.Sqrt(PResult);
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Result = Math.Sqrt(Result);
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnYrootX_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                POperation = 'r';
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Operation = 'r';
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
            Nr = 0;
        }

        private void btnE_Click(object sender, EventArgs e)
        {
           
            _7seg5.Number = Math.E.ToString();
            FirstNumberInBrucket = false;

            LengthCheck();
            _7seg5.Invalidate();

            if (!_7seg5.Number.Equals("-"))
            {
                if (Bracket)
                    PNr = Convert.ToDouble(_7seg5.Number);
                else
                    Nr = Convert.ToDouble(_7seg5.Number);
            }

            if (ResultDisplayed && Operation.Equals('='))
                Result = 0;
            ResultDisplayed = false;
        }

        private void btnLn_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                PResult = Math.Log(PResult);
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Result = Math.Log(Result);
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                PResult = Math.Log10(PResult);
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Result = Math.Log10(Result);
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                if (InvFlag) 
                {
                    PResult = Math.Asin(PResult / (Math.PI / 180));
                    InvFlag = false;
                }
                else
                {
                    PResult = Math.Sin(PResult * Math.PI / 180);
                }
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                if (InvFlag)
                {
                    Result = Math.Asin(Result) / (Math.PI / 180);
                }
                else
                {
                    Result = Math.Sin(Result * Math.PI / 180);
                }
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                if (InvFlag)
                {
                    PResult = Math.Acos(PResult / (Math.PI / 180));
                    InvFlag = false;
                }
                else
                {
                    PResult = Math.Cos(PResult * Math.PI / 180);
                }
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                if (InvFlag)
                {
                    Result = Math.Acos(Result) / (Math.PI / 180);
                }
                else
                {
                    Result = Math.Cos(Result * Math.PI / 180);
                }
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnTg_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                if (InvFlag)
                {
                    PResult = Math.Atan(PResult / (Math.PI / 180));
                    InvFlag = false;
                }
                else
                {
                    PResult = Math.Tan(PResult * Math.PI / 180);
                }
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                if (InvFlag)
                {
                    Result = Math.Atan(Result) / (Math.PI / 180);
                }
                else
                {
                    Result = Math.Tan(Result * Math.PI / 180);
                }
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            _7seg5.Number = Math.PI.ToString();
            FirstNumberInBrucket = false;

            LengthCheck();
            _7seg5.Invalidate();

            if (!_7seg5.Number.Equals("-"))
            {
                if (Bracket)
                    PNr = Convert.ToDouble(_7seg5.Number);
                else
                    Nr = Convert.ToDouble(_7seg5.Number);
            }

            if (ResultDisplayed && Operation.Equals('='))
                Result = 0;
            ResultDisplayed = false;
        }

        private void btnRad_Click(object sender, EventArgs e)
        {
            if (Bracket)
            {
                PCalculation();
                PResult = PResult * Math.PI/180;
                _7seg5.Number = PResult.ToString();
            }
            else
            {
                Calculation();
                Result = Result * Math.PI/180;
                _7seg5.Number = Result.ToString();
            }
            LengthCheck();
            _7seg5.Invalidate();
            ResultDisplayed = true;
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            InvFlag = true;
        }
    }
}
