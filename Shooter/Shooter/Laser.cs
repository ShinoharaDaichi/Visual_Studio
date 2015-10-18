using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Shooter
{
    class Laser : Projectile
    {
        public Laser(Character host, Point location, Direction direction)
            : base(host, "Laser", location)
        {
            speed = 7; //is too fast sometimes to get detected for the collision, but is intended feature 
            damage = 200;
            lifetime = 20;
            sprite.BackColor = host.NormalColor;
            this.direction = direction;
                       switch (direction)
                        {
                            case Direction.Up:
                                sprite.Size = new Size(2, 30);
                                break;

                            case Direction.Down:
                                sprite.Size = new Size(2, 30);
                                break;

                           case Direction.Left:
                                sprite.Size = new Size(30, 2);
                                break;

                           case Direction.Right:
                                sprite.Size = new Size(30, 2);
                                break;
                        }

        }
               
    }
}
