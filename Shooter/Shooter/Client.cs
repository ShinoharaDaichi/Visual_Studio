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
    public class Client : Networker
    { 
        public delegate void GameStartEventHandler();
        public event GameStartEventHandler GameStartEvent;

        public Client(Player p, String ip, int port) : base(p, ip, port)
        {
        }

        public void Connect()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                socket.BeginConnect(serverEndPoint, ConnectCallback, socket);
            }

            catch (Exception e)
            {
                UpdateStatus(e.ToString());
            }

        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                try
                {
                    //Send client's player name to host                
                    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
                    SerializableObject sobject = new SerializableObject(DataType.Player_Registration, player.Name);
                    Send(sobject);

                    Receive(client);
                }
                catch (SocketException e)
                {
                    UpdateStatus("Problem connecting to server: " + e.ToString());
                }
            }

            catch (Exception e)
            {
                UpdateStatus(e.ToString());
            }
        }        

        protected override void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.WorkingSocket;

                // Read data from the remote device.
                int nbrBytes = client.EndReceive(ar);
                state.AddTempBufferToBuffer(nbrBytes);

                if (client.Available > 0)
                {
                    client.BeginReceive(
                        state.TempBuffer, 0,
                        state.TempBuffer.Length,
                        SocketFlags.None,
                        ReceiveCallback,
                        state);
                }
                else
                {
                    SerializableObject sObject = (SerializableObject)Serialization.Deserialize(state.Buffer.ToArray());

                    switch (sObject.DataType)
                    {
                        case DataType.Player_Registration:
                            String message = "Successfully connected to " + sObject.Name;
                            UpdateStatus(message);

                            AddPlayer(sObject.Name); //client doesn't have the id of other players until host give them
                            break;
                        
                        case DataType.Game_Start:
                            controller.Invoke(GameStartEvent);
                            break;

                        case DataType.Score:                            
                            UpdateScore(sObject.Name, sObject.Score);
                            Debug.WriteLine("Client received score update from " + sObject.Name + " : " + sObject.Score);
                            break;

                        case DataType.Message:
                            Message(sObject.Name, sObject.Message);
                            break;
                    }
                    Receive(state.WorkingSocket); //continue to receive data
                }
            }

            catch (Exception e)
            {
                UpdateStatus(e.ToString());
            }

        }



        

    }//end class
}//end namespace