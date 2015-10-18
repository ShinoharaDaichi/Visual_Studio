using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Drawing;
using System.Diagnostics;

namespace be_isib_kuka
{
    public class Server
    {
        XmlDocument ReceivedXml = new XmlDocument();

        public System.Windows.Forms.Control controller;
        public delegate void StringEventHandler(String s);
        public event StringEventHandler UpdateStatusEvent;
        public delegate void MoveEventHandler(Point p, bool isUp);
        public event MoveEventHandler MoveEvent;

        public Server(System.Windows.Forms.Control c)
        {
            controller = c;
        }

        public void StartListening()
        {
            Thread t = new Thread(new ThreadStart(Listen));
            t.Start();
        }

        public void Listen()
        {
            int port = 6008;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint listenerEndPoint = new IPEndPoint(ip, port);
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenerSocket.Bind(listenerEndPoint);
            listenerSocket.Listen(100);
            
            AcceptClients(listenerSocket);
        }

        public void AcceptClients(Socket listener)
        {            
            listener.BeginAccept(AcceptCallback, listener);
            UpdateStatus("Waiting for clients...");
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket client = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.WorkingSocket = client;

            String message = "Client connected";
            UpdateStatus(message);

            SendACK(client);
            Receive(client);
            AcceptClients(listener);
        }

        private void Receive(Socket client)
        {
            try
            {
                StateObject state = new StateObject();
                state.WorkingSocket = client;

                client.BeginReceive(state.TempBuffer, 0, state.TempBuffer.Length,
                    SocketFlags.None, ReceiveCallback, state);
            }
            catch (Exception e)
            {
                controller.Invoke(UpdateStatusEvent, e.ToString());
            }

        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                StateObject clientState = (StateObject)ar.AsyncState;
                int nbrBytes = clientState.WorkingSocket.EndReceive(ar);
                clientState.AddTempBufferToBuffer(nbrBytes);

                if (clientState.WorkingSocket.Available > 0)
                {
                    clientState.WorkingSocket.BeginReceive(clientState.TempBuffer, 0, clientState.TempBuffer.Length,
                       SocketFlags.None, ReceiveCallback, clientState);                    
                }
                else
                {
                    String s = Encoding.UTF8.GetString(clientState.Buffer.ToArray());                                        
                    ReceivedXml.LoadXml(s);
                    UpdateStatus("Received XML : " + s);
                    XmlNode node = ReceivedXml.DocumentElement;
                    try
                    {
                        double xD = Double.Parse(node.SelectSingleNode("Point1X").InnerText);
                        double yD = Double.Parse(node.SelectSingleNode("Point1Y").InnerText);
                        double zD = Double.Parse(node.SelectSingleNode("Point1Z").InnerText);
                        bool isUp = zD > 0 ? true : false;

                        int xI = Convert.ToInt32(xD);
                        int yI = Convert.ToInt32(yD);
                        Point p = new Point(xI,yI);
                        controller.BeginInvoke(MoveEvent, p, isUp);

                        SendACK(clientState.WorkingSocket);
                    }
                    catch(Exception e)
                    {
                        UpdateStatus(e.ToString());
                    }
                    
                    Receive(clientState.WorkingSocket);
                }

            }
            catch (Exception e)
            {
                UpdateStatus(e.ToString());
            }
        }


        public void SendACK(Socket s)
        {
            byte[] byteData = Encoding.UTF8.GetBytes("ACK");

            // Begin sending the data to the remote device.
            s.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), s);
            UpdateStatus("Sent ACK");
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket s = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                s.EndSend(ar);
            }

            catch (Exception e)
            {
                UpdateStatus(e.ToString());
            }
        }


        private void UpdateStatus(String s)
        {
            try
            {
                controller.BeginInvoke(UpdateStatusEvent, s);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
                
        }



    }
}
