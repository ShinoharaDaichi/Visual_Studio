using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Xml;

namespace be_isib_kuka
{
    public enum MotionType
    {
        LINE
    }
    public partial class Form1 : Form
    {
        RobotWrite2 W = new RobotWrite2(100, 200);
        List<Point> points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            stack.Columns.Add("Motion", "Motion");
            stack.Columns.Add("XS", "XS");
            stack.Columns.Add("YS", "YS");
            stack.Columns.Add("XE", "XE");
            stack.Columns.Add("YE", "YE");

            foreach (DataGridViewColumn d in stack.Columns)
            {
                d.Width = stack.Width / stack.Columns.Count;
            }

            Thread t = new Thread(Write1);
            t.Start();            
        }

        void setCoordinates()
        {
            points = new List<Point>(){
            new Point() {X = 200, Y = 200},
            new Point() {X = 500, Y = 200},
            new Point() {X = 500, Y = 500},
            new Point() {X = 200, Y = 500},
            new Point() {X = 200, Y = 200},
            
            };
        }

        void Write()
        {
            int x = 0;
            while (x < 300)
            {
                W.WriteLine(x, 1, x, 300);
                x += 5;
            }
        }
        void Write1()
        {
            W.WriteLine(500, 0, 500, 500);
            W.WriteLine(0, 500, 500, 500);
            W.WriteLine(27, 150, 30, 320);
            W.WriteLine(20, 40, 100, 10);
            W.WriteLine(65, 50, 55, 70);
            W.WriteLine(111, 222, 55, 70);
            W.WriteLine(100, 100, 55, 70);
            W.WriteLine(27, 150, 55, 70);
            W.WriteLine(20, 40, 55, 70);
            W.WriteLine(65, 50, 55, 70);
            W.WriteLine(0, 0, 555, 555);
            W.WriteLine(20, 0, 555, 555);
            W.WriteLine(40, 0, 555, 555);
            W.WriteLine(60, 0, 555, 555);
            W.WriteLine(80, 0, 555, 555);
            W.WriteLine(100, 0, 555, 555);
            W.WriteLine(120, 0, 555, 555);
            W.WriteLine(140, 0, 555, 555);
            W.WriteLine(160, 0, 555, 555);
            W.WriteLine(180, 0, 555, 555);
        }
        void Write2()
        {
            setCoordinates();

            for (int i = 0; i < points.Count - 1; i++)
            {
                W.WriteLine(points.ElementAt(i).X, points.ElementAt(i).Y, points.ElementAt(i + 1).X, points.ElementAt(i + 1).Y);
            }
        }

        private void btnSendMTP_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Double.Parse(tbX.Text);
                double y = Double.Parse(tbY.Text);
                bool isUp = positionBar.Value > 0 ? true : false;
                W.MoveToPoint(x, y, isUp);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
            }

        }

        private void positionBar_Scroll(object sender, EventArgs e)
        {
            positionValueLabel.Text = positionBar.Value > 0 ? "UP" : "DOWN";
        }

        private void buttonAddLine_Click(object sender, EventArgs e)
        {
            try
            {
                float xStart = float.Parse(textBoxXLineStart.Text);
                float yStart = float.Parse(textBoxYLineStart.Text);
                float xEnd = float.Parse(textBoxXLineEnd.Text);
                float yEnd = float.Parse(textBoxYLineEnd.Text);
                AddRow(MotionType.LINE, xStart, yStart, xEnd, yEnd);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
            }
        }

        private void AddRow(MotionType mt, float xS, float yS, float xE, float yE)
        {
            switch (mt)
            {
                case MotionType.LINE:
                    stack.Rows.Add("LINE", xS, yS, xE, yE);
                    break;
                default:
                    Debug.WriteLine("MotionType didn't match");
                    break;
            }
        }

        private void btnSendStack_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in stack.Rows)
                {
                    if(!r.IsNewRow)
                    {
                        switch (r.Cells[0].Value.ToString())
                        {
                            case "LINE":
                                W.WriteLine(Convert.ToDouble(r.Cells[1].Value), Convert.ToDouble(r.Cells[2].Value), Convert.ToDouble(r.Cells[3].Value), Convert.ToDouble(r.Cells[4].Value));
                                break;
                            default:                                
                                break;
                        }//end switch
                    }//end if                    
                }//end foreach

                RemoveRows();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
            }
        }//end method

        public void RemoveRows()
        {
            stack.Rows.Clear();
            stack.Refresh();
        }
    }//end class
}//end namespace
