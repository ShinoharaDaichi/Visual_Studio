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

    public class Host : Networker
    {        
        private List<StateObject> clients = new List<StateObject>();
        
        public Host(Player p, String ip, int port) : base(p, ip, port)
        {            
        }        

        public List<StateObject> Clients
        {
            get { return clients; }
            set { clients = value; }
        }

        private void Listen() //Listening thread
        {
            try
            {
                // Create a TCP/IP socket.
                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and listen for incoming connections.
                socket.Bind(localEndPoint);
                socket.Listen(100);

                AcceptClients(socket);

            }
            catch (Exception e)
            {
                UpdateStatus(e.ToString());
            }

        }

        private void AcceptClients(Socket listener)
        {
            // Start an asynchronous socket to listen for connections.
            UpdateStatus("Waiting for a connection...");
            listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;
                // Complete the connection.
                client.EndConnect(ar);
            }
            catch (Exception e)
            {
                UpdateStatus(e.ToString());
            }
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket client = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.WorkingSocket = client;

            lock (locker) //lock to allows multiple access
            {
                //int id = !this.clients.Any() ? 1 : this.clients.Keys.Max() + 1; //(condition) ? (if true) : (if false) => OBSOLETE IN THIS CODE (List was Dictionary<int id,StateObject>
                if (!clients.Contains(state))
                {
                    clients.Add(state);
                    String message = "Client successfully registered, id is " + clients.Count;
                    UpdateStatus(message);
                }              
            }

            Receive(client);
            AcceptClients(listener); //accept other clients

        }

        protected override void ReceiveCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.WorkingSocket;

            try // Read data from the handler socket. 
            {
                int nbrBytes = handler.EndReceive(ar);
                state.AddTempBufferToBuffer(nbrBytes);

                if (handler.Available > 0) //if received data is not complete, then continue receiving
                {
                    handler.BeginReceive(
                        state.TempBuffer, 0,
                        state.TempBuffer.Length,
                        SocketFlags.None,
                        ReceiveCallback,
                        state);
                }
                else //if data has been fully received
                {
                    lock (locker)
                    {
                        SerializableObject sObject = (SerializableObject)Serialization.Deserialize(state.Buffer.ToArray());
                        String s;

                        switch (sObject.DataType)
                        {
                            case DataType.Player_Registration:

                                s = "Player " + sObject.Name + " connected to host";
                                UpdateStatus(s);

                                AddPlayer(sObject.Name);

                                //Send host name to client
                                SerializableObject so = new SerializableObject(DataType.Player_Registration, player.Name);
                                byte[] byteData = Serialization.Serialize(so);

                                // Begin sending the data to the remote device.
                                handler.BeginSend(byteData, 0, byteData.Length, 0,
                                    new AsyncCallback(SendCallback), handler);
                                break;

                            case DataType.Score:
                                UpdateScore(sObject.Name, sObject.Score);
                                Debug.WriteLine("Host received score update for " + sObject.Name + " : " + sObject.Score);
                                Broadcast(sObject);
                                break;

                            case DataType.Message:
                                Message(sObject.Name, sObject.Message);
                                Broadcast(sObject);
                                break;
                        }
                    }//end lock
                    //continue receiving other data
                    Receive(state.WorkingSocket);
                }//end else (->data has been received)
            }//end try
            catch (SocketException e)
            {
                UpdateStatus(e.ToString());
            }
        }
        /*
        public void Send(int id, SerializableObject data)//Overloading send in networker mother class
        {
            byte[] byteData = Serialization.Serialize(data);

            //Get state object associated to the index from list and extract the socket
            Socket clientSocket = clients.ElementAt(id).WorkingSocket;

            // Begin sending the data to the remote device.
            clientSocket.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), clientSocket);
        }        
        */

        public void Send(Socket clientSocket, SerializableObject data)//Overloading send in networker mother class
        {
            byte[] byteData = Serialization.Serialize(data);
               
            // Begin sending the data to the remote device.
            clientSocket.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), clientSocket);
        }        


        public void StartListening()
        {
            Thread t = new Thread(Listen);
            t.Name = "Listening_Thread";
            t.IsBackground = true;
            t.Start();
        }

        public void Broadcast(SerializableObject sObject) //Send game data to all clients
        {
            foreach(StateObject so in clients)
            {
                Send(so.WorkingSocket, sObject);                
            }
        }
        
    }//end class
}//end namespace
