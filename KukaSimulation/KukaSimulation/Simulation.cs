using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace be_isib_kuka
{
    class Simulation
    {
        public delegate void PictureBoxEventHandler(PictureBox pb);
        public event PictureBoxEventHandler AddPictureBox;
        public delegate void StringEventHandler(String s);
        public event StringEventHandler UpdateStatusEvent;
        public delegate void MoveEventHandler(Point p, bool isUp);
        public event MoveEventHandler MoveEvent;
        public delegate void UpdateStackEventHandler(Point p, bool isUp);
        public event UpdateStackEventHandler AddStackEvent;
        public delegate void RemoveStackEventHandler();
        public event RemoveStackEventHandler RemoveStackEvent;

        public List<Point> pointsStack = new List<Point>();
        public List<bool> boolStack = new List<bool>();

        public PictureBox currentPointBox = new PictureBox();
        public Point currentPoint = new Point(0, 0);
        public bool isUp = false;

        public Size boxSize = new Size(5, 5);

        public bool stopped = true;
        public System.Windows.Forms.Control controller;
        public int drawSpeed = 50;

        public Simulation(System.Windows.Forms.Control c)
        {
            controller = c;            
            currentPointBox.BackColor = Color.Blue;
            currentPointBox.Size = boxSize;
            currentPointBox.Location = currentPoint;
        }

        public PictureBox CurrentPointBox
        {
            get { return currentPointBox; }
            set { currentPointBox = value; }
        }

        public void createBox(Point p, Color c)
        {
            PictureBox pb = new PictureBox();
            pb.BackColor = c;
            pb.Size = boxSize;
            pb.Location = p;
            try
            {
                controller.Invoke(AddPictureBox, pb);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void DrawLine(Point start, Point end, bool isUp)
        {         
            float distance = (float)Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            float nbrBox = distance / (float)(Math.Sqrt(boxSize.Height * boxSize.Width));
            
            if (nbrBox > 0)
            {
                controller.BeginInvoke(UpdateStatusEvent, "(" + start.X + ";" + start.Y + ") -> (" + end.X + ";" + end.Y + ") -  Distance : " + distance + " - NbrBox : " + (int)nbrBox);
                int xI;
                int yI;

                float deltax = Math.Abs(start.X - end.X);
                float deltay = Math.Abs(start.Y - end.Y);

                for (int i = 0; i <= nbrBox; i++)
                {
                    double xD = ((start.X - end.X) > 0) ? (double)start.X - ((deltax / nbrBox) * i) : (double)start.X + ((deltax / nbrBox) * i);
                    double yD = ((start.Y - end.Y) > 0) ? (double)start.Y - ((deltay / nbrBox) * i) : (double)start.Y + ((deltay / nbrBox) * i);

                    xI = Convert.ToInt32(xD);
                    yI = Convert.ToInt32(yD);

                    Point p = new Point(xI, yI);                    
                    currentPoint = p;
                    controller.BeginInvoke(MoveEvent, p, isUp);

                    if (!isUp)
                    {
                        createBox(p, Color.Black);
                    }

                    Thread.Sleep(drawSpeed);
                }
            }
        }

        public void DrawCircle(Point Center, int radius)
        {
            double x;
            double y;
            int boxSizeAverage = (int)Math.Sqrt(boxSize.Height * boxSize.Width);
            for (int i = 0; i <= 361; i+=boxSizeAverage)
            {
                x = Center.X + radius * Math.Cos(i * Math.PI / 180);
                y = Center.Y + radius * Math.Sin(i * Math.PI / 180);

                Point p = new Point((int)x, (int)y);
                if (i != 0)
                {
                    SetPosition(p, false);
                }
                else
                {
                    SetPosition(p, true);
                }               

                Thread.Sleep(drawSpeed);
            }
            
        }

        public void StartDrawing()
        {
            Thread t = new Thread(Move);
            stopped = false;
            t.IsBackground = true;
            t.Name = "Move_Thread";
            t.Start();
        }        

        public void SetPosition(Point p, bool isUp)
        {
            pointsStack.Add(p);            
            boolStack.Add(isUp);
            controller.BeginInvoke(AddStackEvent, p, isUp);
        }

        public void Move()
        {
            while (!stopped)
            {
                if (pointsStack.Count > 0)
                {                    
                    DrawLine(currentPoint, pointsStack.First(), boolStack.First());
                    lock (pointsStack)
                    {
                        controller.BeginInvoke(RemoveStackEvent);
                        pointsStack.RemoveAt(0);

                        lock(boolStack)
                        {
                            boolStack.RemoveAt(0);
                        }
                    }
                }
                else { Thread.Sleep(1); }
            }
        }
    }
}
