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
    class Enemy : Character
    {
        private Character player;

        public delegate void MissileFiredDelegate(Missile m);
        public event MissileFiredDelegate MissileFiredEvent;

        public Enemy(Character p)
        {
            this.player = p;
            health = 500;
            speed = 0;
            ShootDelay = 10000;
            direction = Direction.Stop;

            normalColor = Color.Green;

            sprite.BackColor = normalColor;
            sprite.Size = new Size(40, 40);

            characterLabel = new Label();
            characterLabel.AutoSize = true;
            characterLabel.Name = "EnemyLabel";
            characterLabel.Text = this.health.ToString();
            characterLabel.Size = sprite.Size;
            characterLabel.ForeColor = normalColor;
            characterLabel.BackColor = Color.Transparent;

            Thread t = new Thread(DamageBlink);
            t.Name = "DamageBlink";
            IsDamaged = false;
            t.IsBackground = true;
            t.Start();

            Thread t2 = new Thread(AI_Thread);
            t2.Name = "AI_Thread";
            t2.IsBackground = true;
            t2.Start();
        }

        private void AI_Thread()
        {
            try
            {
                while (!destroyed)
                {
                    Thread.Sleep(ShootDelay);

                    Point projectileLocation = new Point(Sprite.Location.X + (Sprite.Width / 2), Sprite.Location.Y + (Sprite.Height / 2));
                    Missile m = new Missile(this, projectileLocation, player);

                    if (MissileFiredEvent != null)
                    {
                        if (controller != null)
                        {
                            controller.BeginInvoke(MissileFiredEvent, m);
                        }
                        else//sinon, classe mère exécute évènement
                        {
                            MissileFiredEvent(m);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
