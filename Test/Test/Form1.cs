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
        public Form1()
        {
            InitializeComponent();
            textBox1.MaxLength = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text;

            _7seg4.Nr = Convert.ToInt32(new string(number[number.Length - 1], 1));


            if (number.Length > 1)
            {
                _7seg3.isOn = true;
                _7seg3.Nr = Convert.ToInt32(new string(number[number.Length - 2], 1));
            }

            else
                _7seg3.isOn = false;

            if (number.Length > 2)
            {
                _7seg2.isOn = true;
                _7seg2.Nr = Convert.ToInt32(new string(number[number.Length - 3], 1));
            }

            else
                _7seg2.isOn = false;

            if (number.Length > 3)
            {
                _7seg1.isOn = true;
                _7seg1.Nr = Convert.ToInt32(new string(number[number.Length - 4], 1));
            }

            else
                _7seg1.isOn = false;

            _7seg4.Invalidate();
            _7seg3.Invalidate();
            _7seg2.Invalidate();
            _7seg1.Invalidate();
        }
    }
}
