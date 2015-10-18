using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Shooter
{
    class Missile : Projectile
    {
        private Character target;
        private bool isMovingHorizontally = true;
        private int changeDirectionDelay;
        public Missile()
        {

        }

        public Missile(Character host, Point location, Character target) : base(host, "Missile", location)
        {
            speed = 2;
            damage = 10;
            lifetime = 10000; //in milliseconds
            changeDirectionDelay = 200; //in ms
            
            sprite.BackColor = host.NormalColor;
            sprite.Size = new Size(10, 10);
            this.target = target;

            Thread t = new Thread(Homing);
            t.Name = "MissileHoming";
            t.Start();
        }

        public void Homing()
        {
            Random rnd = new Random();
            while (!stopped)
            {
                lock (locker)
                {
                    if (isMovingHorizontally)
                    {
                        if (Sprite.Location.X > target.Sprite.Location.X)
                        {
                            direction = Direction.Left;
                        }

                        else
                        {
                            direction = Direction.Right;
                        }
                    }
                    else
                    {
                        if (Sprite.Location.Y > target.Sprite.Location.Y)
                        {
                            direction = Direction.Up;
                        }

                        else
                        {
                            direction = Direction.Down;
                        }
                    }
                }//end lock
                lifetime -= (changeDirectionDelay);
                isMovingHorizontally = !isMovingHorizontally;
                Thread.Sleep(changeDirectionDelay);
            }//end while
        }//end moving

     }//end class
}//end namespace