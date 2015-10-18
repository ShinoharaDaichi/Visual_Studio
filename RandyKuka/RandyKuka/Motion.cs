using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be_isib_kuka
{
    public class Motion : Coordinates
    {
        StringBuilder _motionName = new StringBuilder();

        public Motion() { }

        public Motion(double X, double Y, double Z, double A, double B, double C, String name)
            : base(X, Y, Z, A, B, C)
        {
            _motionName.Append(name);
        }

        public String name
        {
            get { return _motionName.ToString(); }
            set
            {
                _motionName.Remove(0, _motionName.Length);
                _motionName.Append(value);
            }
        }


        public void copy(Motion m)
        {
            this.copy((Coordinates)m);
            _motionName.Remove(0, _motionName.Length);
            _motionName.Append(m.name);
        }
    }
}
