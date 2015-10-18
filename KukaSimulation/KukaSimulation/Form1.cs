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

namespace be_isib_kuka
{
    public partial class Form1 : Form
    {
        Simulation simulation;
        Server server;

        public Form1()
        {
            InitializeComponent();
            
            LogUpdateText("Starting Test...");
            labelSpeedValue.Text = speedBar.Value.ToString();
            stack.Columns.Add("X", "X");
            stack.Columns.Add("Y", "Y");
            stack.Columns.Add("Z", "Z");

            foreach(DataGridViewColumn d in stack.Columns)
            {
                d.Width = stack.Width/stack.Columns.Count;
            }

            simulation = new Simulation(this);
            simulation.AddPictureBox += new Simulation.PictureBoxEventHandler(AddPictureBox);
            simulation.UpdateStatusEvent += new Simulation.StringEventHandler(LogUpdateText);
            simulation.MoveEvent += new Simulation.MoveEventHandler(UpdatePosition);
            simulation.AddStackEvent += new Simulation.UpdateStackEventHandler(AddStack);
            simulation.RemoveStackEvent += new Simulation.RemoveStackEventHandler(RemoveStack);
            mainPanel.Controls.Add(simulation.CurrentPointBox);
            simulation.StartDrawing();
            
            server = new Server(this);
            server.UpdateStatusEvent += new Server.StringEventHandler(LogUpdateText);
            server.MoveEvent += new Server.MoveEventHandler(MoveEvent);
            server.StartListening();

            Thread t = new Thread(DrawCharacter);
            t.Start();
        }

        public void DrawCharacter()
        {
            Point headCenter = new Point((mainPanel.Width/2), ((mainPanel.Height/20)+(mainPanel.Height/10)));
            simulation.DrawCircle(headCenter, (mainPanel.Height/10));
            Point torsoStart = new Point((mainPanel.Width/2),(mainPanel.Height/4));
            simulation.SetPosition(torsoStart, true);
            Point torsoEnd = new Point((mainPanel.Width / 2), ((mainPanel.Height / 4)*3));
            simulation.SetPosition(torsoEnd, false);
            Point leftArm = new Point((mainPanel.Width / 3), (mainPanel.Height / 2));
            simulation.SetPosition(leftArm, true);
            Point rightArm = new Point(((mainPanel.Width / 3)*2), (mainPanel.Height / 2));
            simulation.SetPosition(rightArm, false);
            Point leftFoot = new Point((mainPanel.Width / 3), ((mainPanel.Height / 10) * 9));
            simulation.SetPosition(leftFoot, true);
            simulation.SetPosition(torsoEnd, false);
            Point rightFoot = new Point(((mainPanel.Width / 3) * 2), ((mainPanel.Height / 10) * 9));
            simulation.SetPosition(rightFoot, false);
            simulation.SetPosition(headCenter, true);
        }

        public void LogUpdateText(String text)
        {
            tb.AppendText(text + "\n");
            tb.SelectionStart = tb.Text.Length;
            tb.ScrollToCaret();
        }

        public void AddPictureBox(PictureBox pb)
        {
            mainPanel.Controls.Add(pb);
        }

        public void MoveEvent(Point p, bool isUp)
        {
            simulation.SetPosition(p, isUp);
        }

        public void UpdatePosition(Point p, bool isUp)
        {
            labelXValue.Text = p.X.ToString();
            labelYValue.Text = p.Y.ToString();
            positionValueLabel.Text = isUp ? "UP" : "DOWN";
            positionBar.Value = isUp ? 1 : 0;

            simulation.CurrentPointBox.BackColor = isUp ? Color.Blue : Color.Red;
            simulation.CurrentPointBox.Location = p;
        }

        public void AddStack(Point p, bool isUp)
        {
            String z = isUp ? "UP" : "DOWN";
            stack.Rows.Add(p.X, p.Y, z);
        }

        public void RemoveStack()
        {
          stack.Rows.RemoveAt(0);
        }

        private void bar_Scroll(object sender, EventArgs e)
        {
            labelSpeedValue.Text = speedBar.Value.ToString();
            simulation.drawSpeed = 100-speedBar.Value;
        }

        private void btnUp_Click(object sender, EventArgs e)
        { 
            Point p = new Point(simulation.currentPoint.X,simulation.currentPoint.Y - simulation.boxSize.Height);
            bool isUp = positionBar.Value > 0 ? true : false;
            simulation.SetPosition(p, isUp);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Point p = new Point(simulation.currentPoint.X, simulation.currentPoint.Y + simulation.boxSize.Height);
            bool isUp = positionBar.Value > 0 ? true : false;
            simulation.SetPosition(p, isUp);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Point p = new Point(simulation.currentPoint.X - simulation.boxSize.Width, simulation.currentPoint.Y);
            bool isUp = positionBar.Value > 0 ? true : false;
            simulation.SetPosition(p, isUp);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Point p = new Point(simulation.currentPoint.X + simulation.boxSize.Width, simulation.currentPoint.Y);
            bool isUp = positionBar.Value > 0 ? true : false;
            simulation.SetPosition(p, isUp);
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Int32.Parse(tbX.Text);
                int y = Int32.Parse(tbY.Text);
                Point p = new Point(x, y);
                bool isUp = positionBar.Value > 0 ? true : false;
                simulation.SetPosition(p, isUp);
                simulation.createBox(p, Color.Green);
            }
            catch(Exception exc)
            {
                Debug.WriteLine(exc.ToString());
            }
            tbX.Text = "";
            tbY.Text = "";            
        }

        private void positionBar_Scroll(object sender, EventArgs e)
        {
            positionValueLabel.Text = positionBar.Value > 0 ? "UP" : "DOWN";
            bool isUp = positionBar.Value > 0 ? true : false;
            simulation.SetPosition(simulation.currentPoint, isUp);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Int32.Parse(tbX.Text);
                int y = Int32.Parse(tbY.Text);
                int radius = Int32.Parse(tbRadius.Text);
                Point p = new Point(x, y);
  
                simulation.createBox(p, Color.Green);
                Thread t = new Thread(() => simulation.DrawCircle(p, radius));
                t.Start();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
            }
            tbX.Text = "";
            tbY.Text = "";
            tbRadius.Text = "";
        }


    }//end class
}//end namespace
