using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Shooter
{
    partial class Setup : Form
    {
        private Networker n;
        private List<String> names = new List<String>();
        private GameForm gf;

        Player player;

        public Setup()
        {
            InitializeComponent();

            btnHost.Enabled = true;
            btnStart.Enabled = false;
            btnJoin.Enabled = true;

            Random r = new Random();
            tbName.Text = r.Next(9999).ToString();
        }

        private void LogUpdateText(String status)
        {
            tbLog.AppendText(status + "\n");
            tbLog.SelectionStart = tbLog.Text.Length; //position the caret at the bottom (blinking bar)
            tbLog.ScrollToCaret(); //scroll to the bottom

            Debug.WriteLine(status);
        }

        private void DisplayScore(String name, int score)
        {
            String s = "Received Score update from " + name + " : " + score;
            LogUpdateText(s);
            gf.DisplayScore(name, score);
        }

        private void SendScore(String name, int score)
        {
            SerializableObject so = new SerializableObject(DataType.Score, name, score);
            if (n is Host) //if host
            {
                LogUpdateText("Host is broadcasting...");
                ((Host)n).Broadcast(so);
            }
            else
            {
                LogUpdateText("Client is sending...");
                ((Client)n).Send(so);
            }
        }

        private void MessageEvent(String name, String message)
        {
            String s = name + " says : " + message;
            LogUpdateText(s);
        }

        private void AddPlayer(String name)
        {
              if (!names.Contains(name)) //check if name is not alredy taken
            {
                int id = names.Count();
                names.Add(name);
                tbPlayers.AppendText("Player " + id + " : " + name + "\n");
                tbPlayers.SelectionStart = tbPlayers.Text.Length; //position the caret at the bottom
                tbPlayers.ScrollToCaret(); //scroll to the bottom
            }
        }

        private Player GetPlayer()
        {
            String name = tbName.Text;
            player = new Player(0, name);
            return player;
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            btnHost.Enabled = false;
            btnStart.Enabled = true;

            Player p = GetPlayer();
            AddPlayer(p.Name);

            n = new Host(p, "127.0.0.1", 2000);
            n.Controller = this;
            n.UpdateStatusEvent += new Networker.StringEventHandler(LogUpdateText);
            n.AddPlayerEvent += new Networker.StringEventHandler(AddPlayer);
            n.UpdateScoreEvent += new Networker.UpdateScoreEventHandler(DisplayScore);
            n.MessageEvent += new Networker.MessageEventHandler(MessageEvent);
            ((Host) n).StartListening();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            btnJoin.Enabled = false;

            Player p = GetPlayer();
            AddPlayer(p.Name);

            n = new Client(p, tbIpClient.Text, Int16.Parse(tbPortClient.Text));
            n.Controller = this;
            n.UpdateStatusEvent += new Networker.StringEventHandler(LogUpdateText);
            n.AddPlayerEvent += new Networker.StringEventHandler(AddPlayer);
            n.UpdateScoreEvent += new Networker.UpdateScoreEventHandler(DisplayScore);
            n.MessageEvent += new Networker.MessageEventHandler(MessageEvent);
            ((Client)n).GameStartEvent += new Client.GameStartEventHandler(GameStart);
            ((Client)n).Connect();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (names.Count > 1)
            {
                SerializableObject so = new SerializableObject(DataType.Game_Start);
                ((Host)n).Broadcast(so);
                GameStart();
            }
            else
            {
                LogUpdateText("You need at least 2 players to start a game !");
            }
        }

        private void GameStart()
        {
            LogUpdateText("Game Started !");
            gf = new GameForm(player, names);
            gf.SendScoreEvent += new GameForm.UpdateScoreEventHandler(SendScore);
            gf.Player = player;
            gf.Show();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            player = GetPlayer();
            AddPlayer(player.Name);

            LogUpdateText("Game Started !");
            gf = new GameForm(player, names);
            gf.Player = player;
            gf.Show();
            gf.isLocal = true;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            SerializableObject so = new SerializableObject(DataType.Message, player.Name, chatBox.Text);
            if (n is Host)
            {
                ((Host)n).Broadcast(so);

                MessageEvent(player.Name, chatBox.Text);
            }
            else
            {
                ((Client)n).Send(so);
            }

            chatBox.Text = "";
        }

        private void chatBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSendMessage_Click(sender, null);
            }
        }



    }
}
