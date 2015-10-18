using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Net;

namespace be_isib_kuka
{
    public class Client2
    {
        Socket serverSocket;
        int serverport;
        IPAddress serverip;

        bool readyToSend = false;
        bool receivedACK = false;
        byte[] buffer = new Byte[1024];

        public delegate void ReceivedACKHandler();
        public event ReceivedACKHandler ReceivedACKEvent;

        public bool ReadyToSend
        {
            get { return readyToSend; }
            set { readyToSend = value; }
        }

        public bool ReceivedACK
        {
            get { return receivedACK; }
            set { receivedACK = value; }
        }

        public void StartConnecting()
        {
            Thread t = new Thread(Connect);
            t.Name = "Connect_Thread";
            t.Priority = ThreadPriority.Highest;
            t.Start();
        }
        public void Connect()
        {
            serverport = 6008;
            serverip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ServerEndPoint = new IPEndPoint(serverip, serverport);

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.NoDelay = true;
            try
            {
                serverSocket.BeginConnect(ServerEndPoint, ConnectCallback, serverSocket);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                client.EndConnect(ar);
                Debug.WriteLine("Connected to client");
                ReadyToSend = true;
                Receive(client);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        public void SendXML(XmlDocument xml)
        {
            ReceivedACK = false;
            byte[] xmlData = System.Text.Encoding.UTF8.GetBytes(xml.InnerXml);
            serverSocket.BeginSend(xmlData, 0, xmlData.Length, 0,
            new AsyncCallback(SendCallback), serverSocket);
        }


        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                handler.EndSend(ar);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
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
                Debug.WriteLine(e.ToString());
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
                    ReceivedACK = s.IndexOf("ACK") != -1;
                    Debug.WriteLine("ACK received : " + ReceivedACK);
                    if (ReceivedACK)
                    {
                        ReceivedACKEvent();
                    }
                    Receive(clientState.WorkingSocket);
                }

            }
            catch (SocketException e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

    }
}



