using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Shooter
{
    public class Character : GameObject
    {
        protected int health;
        protected int shootDelay;
        protected Label characterLabel;
        protected bool isDamaged = false;
        protected Color normalColor;
        protected Color damagedColor = Color.Red;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int ShootDelay
        {
            get { return shootDelay; }
            set { shootDelay = value; }
        }

        public bool IsDamaged
        {
            get { return isDamaged; }
            set { isDamaged = value; }
        }

        public Label CharacterLabel
        {
            get { return characterLabel; }
            set { characterLabel = value; }
        }

        public Color NormalColor
        {
            get { return normalColor; }
            set { normalColor = value; }
        }

        public virtual void TakeDamage(int damage)
        {
            health -= damage;
            isDamaged = true;
        }

        public override void DestroyObject()
        {
            base.DestroyObject();
            DisposeComponent(CharacterLabel);           
        }

        protected void DamageBlink()
        {
            while (!stopped)
            {
                lock (locker)
                {
                    if (isDamaged)
                    {
                        sprite.BackColor = damagedColor;
                        Thread.Sleep(50);
                        sprite.BackColor = normalColor;
                        isDamaged = false;
                    }
                }
            }
        }

        public Projectile Shoot(Projectile.ProjectileType pt, Direction d)
        {
            Point projectileLocation = new Point(Sprite.Location.X + (Sprite.Width / 2), Sprite.Location.Y + (Sprite.Height / 2));
            Projectile pr = new Projectile();
            switch (pt)
            {
                case Projectile.ProjectileType.Bullet:
                    pr = new Bullet(this, projectileLocation);
                    pr.Direction = d;
                    pr.SetController(controller);
                    pr.StartMoving();
                    break;

                case Projectile.ProjectileType.Laser:
                    if (d != Direction.Stop)
                    {
                        pr = new Laser(this, projectileLocation, d);
                        pr.SetController(controller);
                        pr.StartMoving();
                    }
                    break;

                //case Projectile.ProjectileType.Missile:
                //    pr = new Missile(this, projectileLocation, GetRandomEnemy(this));
                //    pr.SetController(controller);
                //    pr.StartMoving();
                //    break;
            }
            return pr;
        }

    }
}
