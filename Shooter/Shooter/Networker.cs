using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace Shooter
{
    public class Networker
    {
        protected System.Windows.Forms.Control controller;
        protected object locker = new Object();

        public delegate void StringEventHandler(String s);
        public event StringEventHandler AddPlayerEvent;
        public event StringEventHandler UpdateStatusEvent;

        public delegate void UpdateScoreEventHandler(String name, int score);
        public event UpdateScoreEventHandler UpdateScoreEvent;

        public delegate void MessageEventHandler(String name, String message);
        public event MessageEventHandler MessageEvent;

        protected Player player;
        protected String ip;
        protected IPAddress ipAddress;
        protected int port;
        protected Socket socket;
        protected IPEndPoint localEndPoint;

        public System.Windows.Forms.Control Controller
        {
            set { controller = value; }
        }

        public Networker(Player p, String ip, int port)
        {
            this.player = p;
            this.ip = ip;
            this.port = port;
            ipAddress = IPAddress.Parse(ip);
            localEndPoint = new IPEndPoint(ipAddress, port);
        }

        public void Send(SerializableObject data)
        {
            byte[] byteData = Serialization.Serialize(data);

            // Begin sending the data to the remote device.
            socket.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), socket);
        }

        protected void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                handler.EndSend(ar);
            }

            catch (Exception e)
            {
                controller.Invoke(UpdateStatusEvent, e.ToString());
            }
        }

        protected void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.WorkingSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.TempBuffer, 0, state.TempBuffer.Length,
                    SocketFlags.None, ReceiveCallback, state);
            }
            catch (Exception e)
            {
                controller.Invoke(UpdateStatusEvent, e.ToString());
            }

        }

        protected virtual void ReceiveCallback(IAsyncResult ar)
        {

        }

        protected void AddPlayer(String s)
        {
            controller.BeginInvoke(AddPlayerEvent, s);
        }

        protected void UpdateStatus(String s)
        {
            controller.BeginInvoke(UpdateStatusEvent, s);
        }

        protected void UpdateScore(String s, int i)
        {
            controller.BeginInvoke(UpdateScoreEvent, s, i);
        }

        protected void Message(String name, String message)
        {
            controller.BeginInvoke(MessageEvent, name, message);
        }

    }
}
