using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;

namespace Shooter
{
    public class GameObject
    {
        protected System.Windows.Forms.Control controller;

        public delegate void MovedEventHandler(GameObject go, Point location);
        public event MovedEventHandler GameObjectMoved;

        public delegate void DisposeComponentDelegate(Component o);
        public event DisposeComponentDelegate DisposeComponentEvent;

        protected int speed;
        protected PictureBox sprite;
        protected bool destroyed;
        protected bool stopped = true; //used for stopping threads
        protected Direction direction;
        protected object locker = new object();

        public GameObject()
        {
            sprite = new PictureBox();
            stopped = false;
        }

        public Point Location
        {
            get { return sprite.Location; }
            set { sprite.Location = value; }
        }

        public PictureBox Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public bool Destroyed
        {
            get { return destroyed; }
        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public virtual void DestroyObject()
        {
            DisposeComponent(Sprite);
            destroyed = true;
            stopped = true;
        }

        protected void DisposeComponent(Component o)//only called by daughters
        {
            controller.BeginInvoke(DisposeComponentEvent, o);
        }

        public void Stop()
        {
            stopped = true;
        }

        public virtual void Move()
        {
            try
            {
                while (!stopped)
                {
                    Point location = Location; //needed because Location is not a variable, therefore cannot be modified
                    switch (direction)
                    {
                        case Direction.Stop:
                            break;
                        case Direction.Up:
                            location.Y -= speed;
                            break;
                        case Direction.Down:
                            location.Y += speed;
                            break;
                        case Direction.Left:
                            location.X -= speed;
                            break;
                        case Direction.Right:
                            location.X += speed;
                            break;
                    }

                    if (GameObjectMoved != null && direction != Direction.Stop)
                    {
                        if (controller != null)
                        {
                            controller.BeginInvoke(GameObjectMoved, this, location);
                        }

                        else
                        {
                            GameObjectMoved(this, location); //sinon, classe mère exécute évènement
                        }
                    }
                    Thread.Sleep(10);
                }//end while
            }//end try
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void StartMoving()
        {
            Thread t = new Thread(Move);
            t.Name = "Move_Thread";
            t.IsBackground = true;
            stopped = false;
            t.Start();
        }

        public void SetController(System.Windows.Forms.Control controller)
        {
            this.controller = controller;
        }

    }
}
