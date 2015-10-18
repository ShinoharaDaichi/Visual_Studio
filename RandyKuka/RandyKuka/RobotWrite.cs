using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be_isib_kuka
{
    public class RobotWrite
    {
        Robot R;
        double X_Max;
        double Y_Max;
        Motion motionArm;
        MotionParameters motionArmP;
        double up = 10;
        double down = 0;
        //Z = -1.5 => Contact avec le papier; 8.5 => pas de contact

        public RobotWrite(double X, double Y)
        {
            R = new Robot();
            X_Max = X;
            Y_Max = Y;
            motionArm = new Motion(0, 0, 8.5, 0, 0, 180, "PTP");
            R.addMotion(motionArm);
        }

        public void WriteLine(double X1, double Y1, double X2, double Y2)
        {
            motionArm = new Motion(X1, Y1, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(X1, Y1, down, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(X2, Y2, down, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(X2, Y2, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
        }

        public void WriteCircle(double CenterX, double CenterY, double Radius)
        {
            //Besoin de 3 point
            motionArm = new Motion(CenterX + Radius, CenterY, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            //Point 1: le départ
            motionArm = new Motion(CenterX + Radius, CenterY, down, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            //Point 2: un point du cercle
            motionArm = new Motion(CenterX, CenterY + Radius, down, 0, 0, 180, "CIRC");
            R.addMotion(motionArm);
            // Point 3: point d'arrivé;depart du suivant
            motionArm = new Motion(CenterX - Radius, CenterY, down, 0, 0, 180, "CIRC");
            R.addMotion(motionArm);
            //Point 4=: un point du cercle
            motionArm = new Motion(CenterX, CenterY - Radius, down, 0, 0, 180, "CIRC");
            R.addMotion(motionArm);
            //Point 5 = Point 1 fin du cercle
            motionArm = new Motion(CenterX + Radius, CenterY, down, 0, 0, 180, "CIRC");
            R.addMotion(motionArm);
            // On releve la pointe
            motionArm = new Motion(CenterX + Radius, CenterY, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(CenterX + Radius, CenterY, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
        }

        public void WriteHalfCircle(double CenterX, double CenterY, double Radius, Boolean circledown)
        {
            Double Point2Y = CenterY + Radius;
            //Besoin de 3 point
            motionArm = new Motion(CenterX + Radius, CenterY, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            //Point 1: le départ
            motionArm = new Motion(CenterX + Radius, CenterY, down, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            //Point 2: un point du cercle.
            if (circledown) { Point2Y = CenterY - Radius; }
            motionArmP = new MotionParameters(CenterX, Point2Y, down, 0, 0, 180, "CIRC", 5, true);
            R.addMotion(motionArmP);
            // Point 3: point d'arrivé
            motionArmP = new MotionParameters(CenterX - Radius, CenterY, down, 0, 0, 180, "CIRC", 5, true);
            R.addMotion(motionArmP);
            // On releve la pointe
            motionArm = new Motion(CenterX - Radius, CenterY, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(CenterX - Radius, CenterY, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
        }

        /*public void WriteArc(double X1, double Y1,double X2,double Y2, double Radius)
        {
            //Calcul du centre du cercle
            double Xc, Yc;
            double Xd, Yd;
            double a; //distance entre point 1 et point D
            double b; //Distance entre point d et centre c
            Xd = ((X2 - X1) / 2) + X1;
            Yd = ((Y2 - Y1) / 2) + Y1;
            a = Math.Sqrt(Math.Pow(Xd - X1, 2) + Math.Pow(Yd - Y1, 2));
            //Pythagore
            b = Math.Sqrt(Math.Pow(Radius, 2) - Math.Pow(a, 2));
            //Besoin de 3 point
            motionArm = new MotionParameters(X1, Y1, up, 0, 0, 180, "PTP", 5, true);
            R.addMotion(motionArm);
            //Point 1: le départ
            motionArm = new MotionParameters(X1, Y1, down, 0, 0, 180, "PTP", 5, true);
            R.addMotion(motionArm);
            //Point 2: un point du cercle
            motionArm = new MotionParameters(((X2 - X1)/2) + X1,  Y1 + Radius, down, 0, 0, 180, "CIRC", 5, true);
            R.addMotion(motionArm);
            // Point 3: point d'arrivé
            motionArm = new MotionParameters(X2, Y2, down, 0, 0, 180, "CIRC", 5, true);
            R.addMotion(motionArm);
            motionArm = new MotionParameters(X2, Y2, up, 0, 0, 180, "PTP", 5, true);
            R.addMotion(motionArm);
        }*/

        public void WritePoint(double X, double Y)
        {
            motionArm = new Motion(X, Y, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(X, Y, down, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(X, Y, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
        }

        //A Tester au niveau de l'axe z... => OK peut être interressant
        public void WritePTP(double X1, double Y1, double X2, double Y2)
        {
            motionArm = new Motion(X1, Y1, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(X1, Y1, down, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
            motionArm = new Motion(X2, Y2, down, 0, 0, 180, "PTP");
            R.addMotion(motionArm);
            motionArm = new Motion(X2, Y2, up, 0, 0, 180, "LIN");
            R.addMotion(motionArm);
        }

        public void WriteWave(double startx, double starty, double radius)
        {
            this.WriteHalfCircle(startx, starty, radius, false);
            this.WriteHalfCircle(startx + 2 * radius, starty, radius, false);
            this.WriteHalfCircle(startx + 4 * radius, starty, radius, false);
        }

        public void WriteSinus(double startx, double starty, double radius)
        {
            this.WriteHalfCircle(startx, starty, radius, false);
            this.WriteHalfCircle(startx + 2 * radius, starty, radius, true);
            this.WriteHalfCircle(startx + 4 * radius, starty, radius, false);
        }

        public void WriteRectangle(double startx, double starty, double l, double h)
        {
            this.WriteLine(startx, starty, startx + l, starty);
            this.WriteLine(startx + l, starty, startx + l, starty + h);
            this.WriteLine(startx + l, starty + h, startx, starty + h);
            this.WriteLine(startx, starty + h, startx, starty);
        }

        public void WriteTriangle(double startx, double starty, double l, double h)
        {
            this.WriteLine(startx, starty, startx + (l / 2), starty + h);
            this.WriteLine(startx + (l / 2), starty + h, startx + l, starty);
            this.WriteLine(startx + l, starty, startx, starty);
        }

        public void WriteSquareWave(double startx, double starty, double l)
        {
            this.WriteLine(startx, starty, startx, starty + l);
            this.WriteLine(startx, starty + l, startx + l, starty + l);
            this.WriteLine(startx + l, starty + l, startx + l, starty + (2 * l));
            this.WriteLine(startx + l, starty + (2 * l), startx + (2 * l), starty + (2 * l));
        }


    }
}
