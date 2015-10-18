using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Shooter
{
    partial class GameForm : Form
    {
        public bool isLocal = false;
        public delegate void UpdateScoreEventHandler(String name, int score);
        public event UpdateScoreEventHandler SendScoreEvent;

        private delegate void ManageDisplayItem(GameObject go);
        private delegate void UpdateCharacterLabelDelegate(Character c, String s);
        private delegate void UpdateGameObjectLocationDelegate(GameObject go, Point p);

        private Random rnd = new Random();
        private List<GameObject> gameObjects = new List<GameObject>();
        private List<Label> scoreLabels = new List<Label>();
        private List<Character> characters = new List<Character>();
        private List<String> names;
        private Player player;
        private bool isGameStarted = false;
        private int spawnDelay = 10000; //in milliseconds
        private object locker = new object();

        public GameForm(Player p, List<String> names)
        {
            InitializeComponent();
            this.player = p;
            this.names = names;

            InitializeGame();
        }

        public List<Label> ScoreLabels
        {
            get { return scoreLabels; }
            set { scoreLabels = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public void DisplayScore(String name, int score)
        {
            //Get the position of the name and find the label associted with that position, current player is first in the names list
            scoreLabels.ElementAt(names.IndexOf(name)).Text = name + " : " + score.ToString();
        }

        public void UpdateScore(String name, int score)
        {
            DisplayScore(name, score);

            if (!isLocal) //don't send message on the network if just playing on local
            {
                this.BeginInvoke(SendScoreEvent, name, score); 
            }
        }

        public void InitializeGame()
        {
            this.Text = "Shooter Game";

            //Positions the players on the game panel aligned on a center horizontal line and equidistant with each other
            foreach (String s in names)
            {
                int index = names.IndexOf(s) + 1; //must not be zero !
                int x = (GamePanel.Width / (names.Count + 1)) * index;
                int y = 5;
                Point p = new Point(x, y);

                Label scoreLabel = new Label();
                scoreLabel.AutoSize = true;
                scoreLabel.Name = s + "'s score";
                scoreLabel.Text = s + " : " + 0;
                scoreLabel.Size = new Size(100, 20);
                scoreLabel.ForeColor = Color.Blue;
                scoreLabel.BackColor = Color.Transparent;
                scoreLabel.Location = p;

                scoreLabels.Add(scoreLabel);

                this.GamePanel.Controls.Add(scoreLabel);
                scoreLabel.BringToFront();
            }

            int xPlayer = GamePanel.Width / 2;
            int yPlayer = GamePanel.Height / 2;
            Point pPlayer = new Point(xPlayer, yPlayer);
            player.Location = pPlayer;

            AddGameObject(player);

            isGameStarted = true;

            Thread dropEnemy = new Thread(RdnDropEnemy);
            dropEnemy.Name = "RdnDrop";
            dropEnemy.IsBackground = true;
            dropEnemy.Start();

            Thread gameThread = new Thread(Game_Thread);
            gameThread.Name = "Game_Thread";
            gameThread.IsBackground = true;
            gameThread.Start();
        }

        private void RdnDropEnemy()
        {
            try
            {
                while (isGameStarted)
                {
                    lock (locker)
                    {
                        Enemy e = new Enemy(player);

                        int x = rnd.Next(GamePanel.Size.Width - e.Sprite.Width);
                        int y = rnd.Next(GamePanel.Size.Height - e.Sprite.Height);

                        e.Sprite.Location = new Point(x, y);
                        e.MissileFiredEvent += new Enemy.MissileFiredDelegate(AddMissile);

                        this.BeginInvoke(new ManageDisplayItem(AddGameObject), e);
                    }
                    Thread.Sleep(spawnDelay);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isGameStarted)
            {
                Projectile pr;

                switch (keyData)
                {
                    case Keys.N:
                        try
                        {
                            player.Score += 1;
                            UpdateScoreEventHandler up = new UpdateScoreEventHandler(UpdateScore);
                            this.BeginInvoke(up, player.Name, player.Score);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.ToString());
                        }
                        break;

                    case Keys.X:
                        player.Direction = Direction.Stop;
                        break;

                    case Keys.Up:
                        player.Direction = Direction.Up;
                        break;

                    case Keys.Down:
                        player.Direction = Direction.Down;
                        break;

                    case Keys.Left:
                        player.Direction = Direction.Left;
                        break;

                    case Keys.Right:
                        player.Direction = Direction.Right;
                        break;

                    case Keys.Z:
                        pr = player.Shoot(Projectile.ProjectileType.Bullet, Direction.Up);
                        pr.GameObjectMoved += new GameObject.MovedEventHandler(UpdateGameObjectLocation);
                        this.BeginInvoke(new ManageDisplayItem(AddGameObject), pr);
                        break;

                    case Keys.S:
                        pr = player.Shoot(Projectile.ProjectileType.Bullet, Direction.Down);
                        pr.GameObjectMoved += new GameObject.MovedEventHandler(UpdateGameObjectLocation);
                        this.BeginInvoke(new ManageDisplayItem(AddGameObject), pr);
                        break;

                    case Keys.Q:
                        pr = player.Shoot(Projectile.ProjectileType.Bullet, Direction.Left);
                        pr.GameObjectMoved += new GameObject.MovedEventHandler(UpdateGameObjectLocation);
                        this.BeginInvoke(new ManageDisplayItem(AddGameObject), pr);
                        break;

                    case Keys.D:
                        pr = player.Shoot(Projectile.ProjectileType.Bullet, Direction.Right);
                        pr.GameObjectMoved += new GameObject.MovedEventHandler(UpdateGameObjectLocation);
                        this.BeginInvoke(new ManageDisplayItem(AddGameObject), pr);
                        break;

                    case Keys.O:
                        pr = player.Shoot(Projectile.ProjectileType.Bullet, Direction.Up);
                        pr.GameObjectMoved += new GameObject.MovedEventHandler(UpdateGameObjectLocation);
                        this.BeginInvoke(new ManageDisplayItem(AddGameObject), pr);
                        break;

                    case Keys.A:
                        pr = player.Shoot(Projectile.ProjectileType.Laser, player.Direction);
                        pr.GameObjectMoved += new GameObject.MovedEventHandler(UpdateGameObjectLocation);
                        this.BeginInvoke(new ManageDisplayItem(AddGameObject), pr);
                        break;

                    //case Keys.E:
                    //    pr = player.Shoot(Projectile.ProjectileType.Missile, player.Direction);
                    //    pr.GameObjectMoved += new GameObject.MovedEventHandler(GameObject_Moved);
                    //    AddGameObject(pr);
                    //    break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        void GameOver(String text)
        {
            foreach (GameObject g in gameObjects)
            {
                g.DestroyObject();
            }

            gameObjects.Clear();

            isGameStarted = false;
            this.Text = text;
        }

        private void Game_Thread()
        {
            try
            {
                while (isGameStarted)
                {
                    Thread.Sleep(100); //Allowing faster checks would detect lasers, but is intended to let some lasers pass without collision
                    lock (locker)
                    {
                        foreach (GameObject go in gameObjects)
                        {
                            if (!go.Destroyed)
                            {
                                if (!go.Sprite.Bounds.IntersectsWith(GamePanel.Bounds))
                                {
                                    if (go is Character)
                                    {
                                        Point p = go.Location;
                                        if (p.X > GamePanel.ClientRectangle.Right)
                                            p.X = GamePanel.ClientRectangle.Left - go.Sprite.Size.Width;
                                        if (p.X < GamePanel.ClientRectangle.Left - go.Sprite.Size.Width)
                                            p.X = GamePanel.ClientRectangle.Right;
                                        if (p.Y > GamePanel.ClientRectangle.Bottom)
                                            p.Y = GamePanel.ClientRectangle.Top - go.Sprite.Size.Height;
                                        if (p.Y < GamePanel.ClientRectangle.Top - go.Sprite.Size.Height)
                                            p.Y = GamePanel.ClientRectangle.Bottom;
                                        this.BeginInvoke(new UpdateGameObjectLocationDelegate(UpdateGameObjectLocation), go, p);
                                    }
                                    else
                                    {
                                        go.DestroyObject();
                                        this.BeginInvoke(new ManageDisplayItem(RemoveGameObject), go);
                                    }
                                }

                                if (go is Projectile)
                                {
                                    Projectile pr = (Projectile)go;

                                    if (pr.Lifetime <= 0)
                                    {
                                        this.BeginInvoke(new ManageDisplayItem(RemoveGameObject), go);
                                    }

                                    foreach (Character c in characters)
                                    {
                                        if (pr.Sprite.Bounds.IntersectsWith(c.Sprite.Bounds) && (pr.Host.GetType() != c.GetType()))//avoid frindly fire between characters of same type
                                        {
                                            this.BeginInvoke(new ManageDisplayItem(RemoveGameObject), go);

                                            c.TakeDamage(pr.Damage);
                                            this.BeginInvoke(new UpdateCharacterLabelDelegate(UpdateCharacterLabel), c, c.Health.ToString());
                                        }
                                    }//end foreach character

                                }//end if projectile

                                if (go is Character)
                                {
                                    Character c = (Character)go;
                                    if (c.Health <= 0)//if character is dead
                                    {
                                        if (c is Enemy)
                                        {
                                            this.BeginInvoke(new ManageDisplayItem(RemoveGameObject), go);
                                            player.Score += 10;
                                            this.BeginInvoke(new UpdateScoreEventHandler(UpdateScore), player.Name, player.Score);
                                        }
                                        else
                                        {
                                            player.Score = 0;
                                            this.BeginInvoke(new UpdateScoreEventHandler(UpdateScore), player.Name, player.Score);

                                            int xPlayer = GamePanel.Size.Width / 2;
                                            int yPlayer = GamePanel.Size.Height / 2;
                                            Point pPlayer = new Point(xPlayer, yPlayer);
                                            this.BeginInvoke(new UpdateGameObjectLocationDelegate(UpdateGameObjectLocation), c, pPlayer);

                                            c.Health = 100; //revives player
                                            this.BeginInvoke(new UpdateCharacterLabelDelegate(UpdateCharacterLabel), c, c.Health.ToString());
                                        }
                                    }
                                }//end if character
                            }//end if !destroyed
                        }//end foreach gameobject
                    }//end lock
                }//end while
            }//end try
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private void AddGameObject(GameObject go)
        {
            lock (locker)
            {
                if (go is Character)
                {
                    Character c = (Character)go;
                    GamePanel.Controls.Add(c.CharacterLabel);
                    Point s = new Point(c.Location.X - 5, c.Location.Y - c.CharacterLabel.Height);
                    c.CharacterLabel.Location = s;
                    characters.Add(c);
                }
                go.GameObjectMoved += new GameObject.MovedEventHandler(UpdateGameObjectLocation);
                go.DisposeComponentEvent += new GameObject.DisposeComponentDelegate(DisposeComponent);
                gameObjects.Add(go);
                go.SetController(this);
                GamePanel.Controls.Add(go.Sprite);

                go.StartMoving();
            }
        }

        private void AddMissile(Missile m)
        {
            AddGameObject(m);
            m.GameObjectMoved += new GameObject.MovedEventHandler(UpdateGameObjectLocation);
        }

        private void RemoveGameObject(GameObject go)
        {
            lock (locker)
            {
                //gameObjects.Remove(go); //modifies the gameobjects list ! breaks the foreach statement
                go.Sprite.Bounds = new Rectangle(); //avoid intersecting in location where destroyed object stood
                go.DestroyObject(); //polymorphism
            }
        }

        private void DisposeComponent(Component c)
        {
            c.Dispose();
        }

        private void UpdateCharacterLabel(Character c, String s)
        {
            c.CharacterLabel.Text = s;
        }

        private void UpdateGameObjectLocation(GameObject go, Point location)
        {
            try
            {
                lock (locker)
                {
                    go.Sprite.Location = location;
                    if (go is Character)
                    {
                        Character c = (Character)go;
                        Point point = new Point(location.X - 5, location.Y - c.CharacterLabel.Height);
                        c.CharacterLabel.Location = point;
                    }
                }
            }
            catch { }
        }

    }//end class
}//end namespace
