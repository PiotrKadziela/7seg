using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wysw7seg
{
    public partial class _7seg : UserControl
    {
        private Color ColA { get; set; }
        private Color ColB { get; set; }
        private Color ColC { get; set; }
        private Color ColD { get; set; }
        private Color ColE { get; set; }
        private Color ColF { get; set; }
        private Color ColG { get; set; }
        private Color ColOff = Color.FromArgb(64, 0, 0);
        private Color ColOn = Color.Red;
        public int Nr { get; set; }
        public bool isOn { get; set; }
        public _7seg()
        {
            InitializeComponent();

           

        }

        private void _7seg_Paint(object sender, PaintEventArgs e)
        {
            if (isOn)
                CheckNr();

            else
            {
                ColA = ColOff;
                ColB = ColOff;
                ColC = ColOff;
                ColD = ColOff;
                ColE = ColOff;
                ColF = ColOff;
                ColG = ColOff;
            }

            BackColor = Color.Black;
            Graphics g = e.Graphics;

            DrawSegHor(ColA, g, 17, 14);
            DrawSegVer(ColC, g, 79, 75);
            DrawSegVer(ColB, g, 79, 15);
            DrawSegHor(ColD, g, 17, 135);
            DrawSegVer(ColE, g, 15, 75);
            DrawSegVer(ColF, g, 15, 15);
            DrawSegHor(ColG, g, 17, 75);
        }

        void DrawSegVer(Color Col, Graphics g, int x, int y)
        {

            Brush brush = new SolidBrush(Col);
            g.FillRectangle(brush, x-5, y+5, 10, 50);
            Point point1 = new Point(x-5, y+5);
            Point point2 = new Point(x, y);
            Point point3 = new Point(x+5, y+5);
            Point[] points = { point1, point2, point3 };
            g.FillPolygon(brush, points);
            Point point4 = new Point(x-5, y+55);
            Point point5 = new Point(x, y+60);
            Point point6 = new Point(x + 5, y + 55);
            Point[] points2 = { point4, point5, point6 };
            g.FillPolygon(brush, points2);
        }

        void DrawSegHor(Color Col, Graphics g, int x, int y)
        {
            Brush brush = new SolidBrush(Col);
            g.FillRectangle(brush, x+5, y-5, 50, 10);
            Point point1 = new Point(x+5, y-5);
            Point point2 = new Point(x, y);
            Point point3 = new Point(x+5, y+5);
            Point[] points = { point1, point2, point3 };
            g.FillPolygon(brush, points);
            Point point4 = new Point(x+55, y-5);
            Point point5 = new Point(x+60, y);
            Point point6 = new Point(x+55, y+5);
            Point[] points2 = { point4, point5, point6 };
            g.FillPolygon(brush, points2);
        }

        void CheckNr()
        {
            if (Nr == 0)
            {
                ColA = ColOn;
                ColB = ColOn;
                ColC = ColOn;
                ColD = ColOn;
                ColE = ColOn;
                ColF = ColOn;
                ColG = ColOff;
            }

            else if (Nr == 1)
            {
                ColA = ColOff;
                ColB = ColOn;
                ColC = ColOn;
                ColD = ColOff;
                ColE = ColOff;
                ColF = ColOff;
                ColG = ColOff;
            }

            else if (Nr == 2)
            {
                ColA = ColOn;
                ColB = ColOn;
                ColC = ColOff;
                ColD = ColOn;
                ColE = ColOn;
                ColF = ColOff;
                ColG = ColOn;
            }

            else if (Nr == 3)
            {
                ColA = ColOn;
                ColB = ColOn;
                ColC = ColOn;
                ColD = ColOn;
                ColE = ColOff;
                ColF = ColOff;
                ColG = ColOn;
            }

            else if (Nr == 4)
            {
                ColA = ColOff;
                ColB = ColOn;
                ColC = ColOn;
                ColD = ColOff;
                ColE = ColOff;
                ColF = ColOn;
                ColG = ColOn;
            }

            else if (Nr == 5)
            {
                ColA = ColOn;
                ColB = ColOff;
                ColC = ColOn;
                ColD = ColOn;
                ColE = ColOff;
                ColF = ColOn;
                ColG = ColOn;
            }

            else if (Nr == 6)
            {
                ColA = ColOn;
                ColB = ColOff;
                ColC = ColOn;
                ColD = ColOn;
                ColE = ColOn;
                ColF = ColOn;
                ColG = ColOn;
            }

            else if (Nr == 7)
            {
                ColA = ColOn;
                ColB = ColOn;
                ColC = ColOn;
                ColD = ColOff;
                ColE = ColOff;
                ColF = ColOff;
                ColG = ColOff;
            }

            else if (Nr == 8)
            {
                ColA = ColOn;
                ColB = ColOn;
                ColC = ColOn;
                ColD = ColOn;
                ColE = ColOn;
                ColF = ColOn;
                ColG = ColOn;
            }

            else if (Nr == 9)
            {
                ColA = ColOn;
                ColB = ColOn;
                ColC = ColOn;
                ColD = ColOn;
                ColE = ColOff;
                ColF = ColOn;
                ColG = ColOn;
            }
        }
    }
}
