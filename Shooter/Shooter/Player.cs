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
    public class Player : Character
    {
        private int id;
        private String name;
        private int score = 0;

        public Player()
        {

        }

        public Player(int id, String name)
            : base()
        {
            health = 100;
            shootDelay = 10;
            speed = 3;
            direction = Direction.Stop;

            normalColor = Color.Blue;
            this.id = id;
            this.name = name;
            sprite.BackColor = normalColor;
            sprite.Size = new Size(20, 20);

            characterLabel = new Label();
            characterLabel.AutoSize = true;
            characterLabel.Name = this.name;
            characterLabel.Text = this.health.ToString();
            characterLabel.Size = sprite.Size;
            characterLabel.ForeColor = normalColor;
            characterLabel.BackColor = Color.Transparent;

            Thread t = new Thread(DamageBlink);
            t.Name = "DamageBlink" + name;
            IsDamaged = false;
            t.IsBackground = true;
            t.Start();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        //private Player GetRandomEnemy(Player player)
        //{
        //    Random r = new Random();
        //    int index = r.Next(ennemies.Count - 1);
        //    return ennemies.ElementAt(index);
        //}

    }

}