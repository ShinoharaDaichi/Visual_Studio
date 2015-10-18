using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Shooter
{
    class Bullet:Projectile
    {

        public Bullet()
        {

        }

        public Bullet(Character host, Point location)
            : base(host, "Bullet", location)
        {
            speed = 2;
            damage = 100;
            lifetime = 150;
            sprite.BackColor = host.NormalColor;
            sprite.Size = new Size(10, 10);

        }
              
    }
}
