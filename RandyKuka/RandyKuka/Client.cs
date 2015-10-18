using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace be_isib_kuka
{
    public class Client
    {
        XmlDocument _SendXml = new XmlDocument();
        XmlDocument _ReceiveXml = new XmlDocument();

        bool stop = false;
        bool ready = false;

        Socket handler;


        public Socket handlerSocket
        {
            get { return handler; }
        }

        public XmlDocument SendXml
        {
            get { return _SendXml; }
            set { _SendXml = value; }
        }

        public XmlDocument ReceiveXml
        {
            get { return _ReceiveXml; }
            private set { _ReceiveXml = value; }
        }

        public bool clientReady
        {
            get { return ready; }
        }


        //Méthodes
        public void Stop()
        {
            ready = false;
            stop = true;
        }

        public void threadSocket()
        {
            // starting communication by separate process
            System.Threading.Thread secondThread;
            secondThread = new System.Threading.Thread(new System.Threading.ThreadStart(StartListening));
            secondThread.Priority = System.Threading.ThreadPriority.Highest;
            secondThread.Start();
        }

        // second thread
        public void StartListening()
        {
            handler = getConnexionHandler();

            // string members for incoming and outgoing data
            StringBuilder strReceive = new StringBuilder(""); //pour visualiser le XML
            StringBuilder xml = new StringBuilder("");
            int subIndex;

            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];
            int bytesRec = 0;

            //premier envoi du fichier :                         
            byte[] first = System.Text.Encoding.ASCII.GetBytes(_SendXml.InnerXml);
            try
            {
                handler.Send(first, 0, first.Length, System.Net.Sockets.SocketFlags.None);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Problème avec la socket, vous avez probablement été déconnecté.");
                Console.WriteLine(e);
                Environment.Exit(1);
            }

            while (!this.stop)
            {

                // wait for data and receive bytes
                
                try
                {
                    bytesRec = handler.Receive(bytes);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Problème avec la socket, vous avez probablement été déconnecté." + e);
                    Environment.Exit(1);
                }
                
                if (bytesRec == 0)
                {
                    break; // Client closed Socket
                }
                
                // convert bytes to string
                strReceive.Append(System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRec));

                // take a look to the end of data
                if ((strReceive.ToString().LastIndexOf("</Rob>")) == -1)
                {
                    continue;
                }
                else
                {
                    //on a au moins une balise de fin ici

                    //on prend l'index de la position juste après la balise pour le traitement
                    subIndex = strReceive.ToString().IndexOf("</Rob>") + 6;

                    //on prend ce qui pourrait être le premier contenu xml COMPLET
                    xml.Append(strReceive.ToString().Substring(0, subIndex));

                    //System.Windows.Forms.MessageBox.Show(xml.ToString());

                    //si on trouve une balise de début
                    if (xml.ToString().IndexOf("<Rob") >= 0)
                    {
                        //System.Windows.Forms.MessageBox.Show(xml.ToString());
                        lock (_ReceiveXml)
                        {
                            _ReceiveXml.LoadXml(xml.ToString());
                        }

                        //on passe au contenu xml suivant
                        strReceive.Remove(0, subIndex);
                    }

                    xml.Remove(0, xml.Length);



                    if (ready == false)
                    {
                        ready = true;
                        //System.Windows.Forms.MessageBox.Show("Client prêt");
                    }


                }
                 
                ready = true;
                
                //envoi du xml 
                lock (_SendXml)
                {
                    // send data as requested 
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(_SendXml.InnerXml);
                    try
                    {
                        Debug.WriteLine(_SendXml.InnerXml);
                        handler.Send(msg, 0, msg.Length, System.Net.Sockets.SocketFlags.None);
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine("Problème avec la socket, vous avez probablement été déconnecté. \n" + e);
                        Environment.Exit(1);
                    }
                }
            }

            handler.Close();
            handler.Dispose();

        }


        private static Socket getConnexionHandler()
        {
            int Port = 6008;                     // port number TCP/IP

            Socket sock;         // create system socket
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            System.Net.IPEndPoint ipEnd = new System.Net.IPEndPoint(ip, Port);

            // Create a TCP/IP socket.
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sock.Connect(ipEnd);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Impossible de se connecter, vous devez lancer le serveur sur l'ordinateur distant en premier. " + e);
                Environment.Exit(1);
            }


            return sock;
        }
    }
}



