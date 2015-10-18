using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be_isib_kuka
{
    public class Coordinates
    {
        private double _X, _Y, _Z, _A, _B, _C;

        public Coordinates() { }

        public Coordinates(double X, double Y, double Z, double A, double B, double C)
        {
            _X = X;
            _Y = Y;
            _Z = Z;
            _A = A;
            _B = B;
            _C = C;
        }

        public void copy(Coordinates C)
        {
            _X = C._X;
            _Y = C._Y;
            _Z = C._Z;
            _A = C._A;
            _B = C._B;
            _C = C._C;
        }

        public double X
        {
            get { return _X; }
            set { _X = value; }
        }

        public double Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        public double Z
        {
            get { return _Z; }
            set { _Z = value; }
        }

        public double A
        {
            get { return _A; }
            set { _A = value; }
        }

        public double B
        {
            get { return _B; }
            set { _B = value; }
        }

        public double C
        {
            get { return _C; }
            set { _C = value; }
        }


        //deux méthodes pour comparer les coordonnées, cependant distCart ne prend pas en compte A, B et C
        public bool diffCoords(Coordinates m2, int coeff, double diffMax)
        {
            double diffX = Math.Abs(this.X - m2.X / coeff);
            double diffY = Math.Abs(this.Y - m2.Y / coeff);
            double diffZ = Math.Abs(this.Z - m2.Z / coeff);
            double diffA = Math.Abs(this.A - m2.A / coeff);
            double diffB = Math.Abs(this.B - m2.B / coeff);
            double diffC = Math.Abs(this.C - Math.Abs(m2.C) / coeff);//incorrect mais suffit ici (valeur absolue sur l'angle)

            //System.Windows.Forms.MessageBox.Show(" X:" + diffX + " Y:" + diffY + " Z:" + diffZ + " A:" + diffA + " B:" + diffB + " C:" + diffC + " Max:" + diffMax); 

            if (diffX < diffMax && diffY < diffMax && diffZ < diffMax && diffA < diffMax && diffB < diffMax && diffC < diffMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //calcul de la distance cartésienne en 3 dimensions
        //retourne la distance calculée
        public double distCart(Coordinates m2, int coeff)
        {

            double diffX = this.X - m2.X / coeff;
            double diffY = this.Y - m2.Y / coeff;
            double diffZ = this.Z - m2.Z / coeff;

            double dist = Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2) + Math.Pow(diffZ, 2));

            //System.Windows.Forms.MessageBox.Show(" dist:" + dist + " distMax:" + distMax); 

            return dist;
        }

        //retourne un booléen
        public bool distCartBool(Coordinates m2, int coeff, double distMax)
        {

            double dist = this.distCart(m2, coeff);
            //System.Windows.Forms.MessageBox.Show(" dist:" + dist + " distMax:" + distMax); 

            if (dist < distMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        override public String ToString()
        {
            return "X=" + _X + " Y=" + _Y + " Z=" + _Z + " A=" + _A + " B=" + _B + " C=" + _C;
        }

        public String ToStringMilli()
        {
            return "X=" + _X / 10000 + " Y=" + _Y / 10000 + " Z=" + _Z / 10000 + " A=" + _A / 10000 + " B=" + _B / 10000 + " C=" + _C / 10000;
        }
    }
}
