using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Shooter
{
    public class Projectile : GameObject
    {
        protected Character host;
        protected String name = "Projectile";
        protected int damage;
        protected int lifetime;
        protected Point lastLocation;

        public enum ProjectileType
        {
            Bullet,Laser,Missile
        }

        public Projectile()
        {

        }
        public Projectile(Character host, String name, Point location):base()
        {
            this.host = host;
            this.name = name;
            Location = location;
        }

        public Character Host
        {
            get { return host; }
            set { host = value; }
        }

         public Point LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }
        
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Lifetime
        {
            get { return lifetime; }
            set { lifetime = value; }
        }

    }
}
