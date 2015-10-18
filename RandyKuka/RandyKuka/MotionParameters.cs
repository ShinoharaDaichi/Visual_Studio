using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be_isib_kuka
{
    public class MotionParameters : Motion
    {
        private double _C_DIS;                 //valeur du C_DIS dans le programme
        private Boolean _stateGripClose = true; //correspond à l'état de la pince fermée

        //dans ce cas on peut construire un objet sans paramètre et utiliser les fonctions de copie d'attributs
        public MotionParameters() { }

        public MotionParameters(double X, double Y, double Z, double A, double B, double C, String name, double C_DIS, Boolean gripClose)
            : base(X, Y, Z, A, B, C, name)
        {
            this._C_DIS = C_DIS;
            this.gripClose = gripClose;
        }

        public double C_DIS
        {
            get { return _C_DIS; }
            set { _C_DIS = value; }
        }

        public Boolean gripClose
        {
            get { return _stateGripClose; }
            set { _stateGripClose = value; }
        }

        public void copyM(MotionParameters mP)
        {
            this.copy((Motion)mP);
            this._C_DIS = mP.C_DIS;
            this._stateGripClose = mP.gripClose;
        }

    }
}
