using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace be_isib_kuka
{
    public class Robot
    {
        XmlDocument XmlToRobot = new XmlDocument();
        XmlDocument XmlFromRobot = new XmlDocument();

        Client cli = new Client();
        Coordinates retourPositionBras = new Coordinates(0, 0, 0, 0, 0, 0); //utilisé par la fonciton PosState()
        bool ready = true; //indique si une opération est en cours et donc si le robot est pret à en effectuer une
        bool stop = false; //permet d'arretter le thread du robot
        List<Motion> motionStack = new List<Motion>(); //gestion FIFO (on stocke tout les mouvement puis on les execute un par un)

        //pour controler l'état de la pince
        bool gripClose = true;

        //temporisation, il est inutile quer l'objet robot travaille plus vite que le client
        //l'objet robot utilisant les résultats traités par ce dernier
        int tempo = 2;

        //pour controler la boucle loop sur le bras (qui générait des problèmes avec la commande CIRC qu'il ne faut pas lancer deux fois sur les même points)
        //principe : il vaudra une fois 0, une fois 1 dans le XML envoyé
        //le programme du bras, fera le mouvement demandé, et simultanément, tant que
        //la valeur de motionOnlyOnce n'aura pas changée (tant que le fichier XML n'est pas renouvelé)
        //ne lancera pas de nouveau mouvement
        bool motionOnlyOnce = false;

        //distance à laquelle on estime que le mouvement est terminé : 
        //(mettre une valeur plus grande pour faire des arrondis avec CDIS)
        double linCDistCart = 5;

        //à cette distance du point, le programme considère le mouvement comme terminé
        double distAckMotion;


        public Robot()
        {
            //XmlToRobot.PreserveWhitespace = true;
            XmlToRobot.Load("RobotRSI.xml");

            //on fait du transfert de contenu XML avec la méthode InnerXml sur le noeud racine
            //on charge donc les noeud racines
            cli.SendXml.LoadXml("<Sen Type=\"ImFree\"></Sen>");
            cli.SendXml.DocumentElement.InnerXml = XmlToRobot.DocumentElement.InnerXml;

            XmlFromRobot.LoadXml("<Rob TYPE=\"KUKA\"></Rob>");

            cli.threadSocket(); //lancement dans un thread d'une fonction du client

            distAckMotion = linCDistCart;

            Thread thirdThread = new Thread(new ThreadStart(motionProcessing));
            thirdThread.Priority = ThreadPriority.Normal;
            thirdThread.Start();

            /*Thread fourthThread = new Thread(new ThreadStart(supervision));
            fourthThread.Priority = ThreadPriority.BelowNormal;
            fourthThread.Start();*/
        }



        //propriétés, getters, setters

        public bool isReady
        {
            get { return ready; }
            set { ready = value; }
        }

        public bool gripStateClose
        {
            get { return gripClose; }
        }


        //Méthodes

        public void killClient()
        {
            ready = false;

            //on détruit tout
            cli.Stop();
            cli = null;
        }

        public void killRobot()
        {
            lock (this)
            {
                emptyMotion();

                lock (cli)
                {
                    killClient();
                }

                //pour finir on tue le thread
                this.stop = true;
            }
        }


        public void addMotion(Motion motion)
        {
            if (cli.clientReady)
            {
                Motion tempMotion;
                //s'il y a beaucoup de mouvements, on ralenti pour 
                //éviter de saturer la mémoire

                lock (motionStack)
                {
                    if (motion is MotionParameters)
                    {
                        tempMotion = new MotionParameters(motion.X, motion.Y, motion.Z, motion.A, motion.B, motion.C, motion.name, ((MotionParameters)motion).C_DIS, ((MotionParameters)motion).gripClose);
                    }
                    else
                    {
                        tempMotion = new Motion(motion.X, motion.Y, motion.Z, motion.A, motion.B, motion.C, motion.name);
                    }
                }


                lock (motionStack)
                {
                    motionStack.Add(tempMotion);
                }

            }

        }

        public Motion getNextMotion()
        {
            lock (motionStack)
            {
                return motionStack.First();
            }
        }

        public void emptyMotion()
        {
            int temp = 0;

            //si un mouvement est en cours on le laisse (il est effacé par le thread du robot, sinon il y aura une erreur)
            if (ready == false) { temp = 1; }

            lock (motionStack)
            {
                while (motionStack.Count() > temp)
                {
                    motionStack.RemoveAt(0);
                }
            }
        }

        public int stackSize()
        {
            lock (motionStack)
            {
                return motionStack.Count();
            }
        }

        private void motionProcessing()
        {
            Motion currentMotion;
            Motion currentMotion2;

            while (!stop)
            {
                if (stackSize() > 0 && cli.clientReady && ready)
                {
                    ready = false;
                    currentMotion = getNextMotion();

                    //si la classe est de type MotionParameters, il y a donc plus de paramètres à traiter
                    if (currentMotion is MotionParameters)
                    {
                        MotionParameters temp = (MotionParameters)currentMotion;

                        //gestion du paramètre CDIS
                        linCDistCart = temp.C_DIS;
                        distAckMotion = linCDistCart;

                        lock (XmlToRobot)
                        {
                            try
                            {
                                XmlNode tempRoot = XmlToRobot.DocumentElement;
                                tempRoot.SelectSingleNode("C_DIS").InnerText = linCDistCart.ToString();
                            }
                            catch (NullReferenceException e) { Console.WriteLine(e); }
                        }

                        //gestion de l'ouverture de la pince
                        if (temp.gripClose)
                        {
                            closeGrip();
                        }
                        else
                        {
                            openGrip();
                        }

                    }

                    switch (currentMotion.name)
                    {
                        case "LIN":
                            moveLIN(currentMotion, false);
                            break;

                        case "LINCDIS":
                            moveLIN(currentMotion, true);
                            break;

                        case "PTP":
                            movePTP(currentMotion);
                            break;

                        case "CIRC":
                            lock (motionStack)
                            {
                                currentMotion2 = motionStack.ElementAt(1);
                            }

                            moveCIRC(currentMotion, currentMotion2);
                            lock (motionStack)
                            {
                                motionStack.RemoveAt(0);
                            }
                            //currentMotion2 = null;
                            break;


                        default:

                            break;
                    }

                    //on supprime l'élément 
                    lock (motionStack)
                    {
                        motionStack.RemoveAt(0);
                    }

                    //on libère l'objet
                    currentMotion = null;
                }
                else
                {
                    //quand le robot n'a plus de mouvements à effectuer
                    System.Threading.Thread.Sleep(tempo);
                }

            }

        }

        private void movePTP(Motion mot)
        {
            lock (XmlToRobot)
            {
                try
                {
                    XmlNode tempRoot = XmlToRobot.DocumentElement;
                    tempRoot.SelectSingleNode("motionType").InnerText = "1";
                    tempRoot.SelectSingleNode("Point1X").InnerText = mot.X.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1Y").InnerText = mot.Y.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1Z").InnerText = mot.Z.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1A").InnerText = mot.A.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1B").InnerText = mot.B.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1C").InnerText = mot.C.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("CONTROL_LOOP").InnerText = motionControl();
                }
                catch (NullReferenceException e) { Console.WriteLine(e); }

                do
                {
                    //solicitation d'un document xml du serveur
                    if (cli.clientReady)
                    {
                        System.Threading.Thread.Sleep(tempo);
                        lock (cli.SendXml)
                        {
                            cli.SendXml.DocumentElement.InnerXml = XmlToRobot.DocumentElement.InnerXml;
                        }
                    }
                } while (!cli.clientReady);
            }


            while (!ready)
            {
                if (((Coordinates)mot).distCartBool(PosState(), 10000, distAckMotion))
                {
                    ready = true;
                }

            }

        }

        private void moveLIN(Motion mot, Boolean CDIS)
        {
            lock (XmlToRobot)
            {
                try
                {
                    XmlNode tempRoot = XmlToRobot.DocumentElement;
                    if (CDIS == true)
                    {
                        tempRoot.SelectSingleNode("motionType").InnerText = "4";
                    }
                    else
                    {
                        tempRoot.SelectSingleNode("motionType").InnerText = "2";
                    }
                    tempRoot.SelectSingleNode("Point1X").InnerText = mot.X.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1Y").InnerText = mot.Y.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1Z").InnerText = mot.Z.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1A").InnerText = mot.A.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1B").InnerText = mot.B.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1C").InnerText = mot.C.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("CONTROL_LOOP").InnerText = motionControl();
                }
                catch (NullReferenceException e) { Console.WriteLine(e); }

                do
                {
                    if (cli.clientReady)
                    {
                        //sollicitation d'un doccument xml du serveur
                        System.Threading.Thread.Sleep(tempo);
                        lock (cli.SendXml)
                        {
                            cli.SendXml.DocumentElement.InnerXml = XmlToRobot.DocumentElement.InnerXml;
                        }
                    }
                } while (!cli.clientReady);

            }
            //System.Windows.Forms.MessageBox.Show("VERIF COORDS LIN"); 
            while (!ready)
            {
                if (((Coordinates)mot).distCartBool(PosState(), 10000, distAckMotion))
                {
                    ready = true;
                    //System.Windows.Forms.MessageBox.Show("FIN LIN"); 
                }

            }

        }


        private void moveCIRC(Motion mot1, Motion mot2)
        {
            lock (XmlToRobot)
            {
                try
                {
                    XmlNode tempRoot = XmlToRobot.DocumentElement;
                    tempRoot.SelectSingleNode("motionType").InnerText = "3";

                    tempRoot.SelectSingleNode("Point1X").InnerText = mot1.X.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1Y").InnerText = mot1.Y.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1Z").InnerText = mot1.Z.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1A").InnerText = mot1.A.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1B").InnerText = mot1.B.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point1C").InnerText = mot1.C.ToString().Replace(',', '.');

                    tempRoot.SelectSingleNode("Point2X").InnerText = mot2.X.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point2Y").InnerText = mot2.Y.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point2Z").InnerText = mot2.Z.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point2A").InnerText = mot2.A.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point2B").InnerText = mot2.B.ToString().Replace(',', '.');
                    tempRoot.SelectSingleNode("Point2C").InnerText = mot2.C.ToString().Replace(',', '.');

                    tempRoot.SelectSingleNode("CONTROL_LOOP").InnerText = motionControl();

                }
                catch (NullReferenceException e) { Console.WriteLine(e); }

                do
                {

                    if (cli.clientReady)
                    {
                        //sollicitation d'un doccument xml du serveur
                        System.Threading.Thread.Sleep(tempo);
                        lock (cli.SendXml)
                        {
                            cli.SendXml.DocumentElement.InnerXml = XmlToRobot.DocumentElement.InnerXml;
                        }
                    }
                } while (!cli.clientReady);
            }

            bool ready2 = false;

            while (!ready && !ready2)
            {
                if (((Coordinates)mot1).distCartBool(PosState(), 10000, distAckMotion))
                {
                    ready2 = true;
                }

                if (((Coordinates)mot2).distCartBool(PosState(), 10000, distAckMotion))
                {
                    ready = true;
                }

            }
        }

        private void refreshReceivedXML()
        {

            //on met en attente pendant que le mouvement est fait pour éviter 
            //de trop bloquer cli.ReceiveXml, le clieur doit assurer des réponses
            //pour que la communication ne soit pas stoppée

            do
            {
                System.Threading.Thread.Sleep(tempo);

                if (cli.clientReady)
                {
                    lock (cli.ReceiveXml)
                    {
                        XmlFromRobot.DocumentElement.InnerXml = cli.ReceiveXml.DocumentElement.InnerXml;
                    }
                }
            } while (!cli.clientReady);
        }


        //fonction qui s'occupe XML retourné
        //permet de vérifier si le mouvement est terminé
        public Coordinates PosState()
        {
            lock (XmlFromRobot)
            {

                refreshReceivedXML();
                XmlNode tempNode = XmlFromRobot.DocumentElement.SelectSingleNode("RIst");

                retourPositionBras.X = double.Parse(tempNode.Attributes["X"].Value);
                retourPositionBras.Y = double.Parse(tempNode.Attributes["Y"].Value);
                retourPositionBras.Z = double.Parse(tempNode.Attributes["Z"].Value);
                retourPositionBras.A = double.Parse(tempNode.Attributes["A"].Value);
                retourPositionBras.B = double.Parse(tempNode.Attributes["B"].Value);
                retourPositionBras.C = double.Parse(tempNode.Attributes["C"].Value);

                return retourPositionBras;


            }



        }



        //Contrôle de la pince
        //fermer la pince
        private void closeGrip()
        {
            lock (XmlToRobot)
            {
                XmlNode tempRoot = XmlToRobot.DocumentElement;
                tempRoot.SelectSingleNode("GRIP_CLOSE").InnerText = "1";
                tempRoot.SelectSingleNode("GRIP_OPEN").InnerText = "0";

                do
                {

                    if (cli.clientReady)
                    {
                        lock (cli.SendXml)
                        {
                            cli.SendXml.InnerXml = XmlToRobot.InnerXml;
                        }
                    }
                } while (!cli.clientReady);
            }

            while (!ready)
            {
                armState();
                if (gripClose == true)
                {
                    ready = true;
                }

            }
        }

        //ouvrir la pince
        private void openGrip()
        {

            lock (XmlToRobot)
            {
                XmlNode tempRoot = XmlToRobot.DocumentElement;
                tempRoot.SelectSingleNode("GRIP_OPEN").InnerText = "1";
                tempRoot.SelectSingleNode("GRIP_CLOSE").InnerText = "0";

                do
                {

                    if (cli.clientReady)
                    {
                        lock (cli.SendXml)
                        {
                            cli.SendXml.InnerXml = XmlToRobot.InnerXml;
                        }
                    }
                } while (!cli.clientReady);
            }

            while (!ready)
            {
                armState();
                if (gripClose == false)
                {
                    ready = true;

                }

            }
        }

        //pour que du coté robot, une commande de mouvement soit lancée une seule fois
        public String motionControl()
        {
            if (motionOnlyOnce == true)
            {
                motionOnlyOnce = false;
                return "0";
            }
            else
            {
                motionOnlyOnce = true;
                return "1";
            }
        }

        //met à jour l'attribut sur l'état du bras du robot
        public void armState()
        {
            lock (XmlFromRobot)
            {
                refreshReceivedXML();

                if (XmlFromRobot.DocumentElement.SelectSingleNode("DigIn9").InnerText == "1")
                {
                    gripClose = true;
                }
                else
                {
                    gripClose = false;
                }
            }
        }


        //fonction lancée dans un thread qui supervise le déroulement du programme
        //il permet entre autre de vérifier si le bras est "bloqué" (car il 
        //ne peut pas faire un mouvement et ce programme attend qu'il l'ai fini) 
        //et de le débloquer
        public void supervision()
        {

            //Coordinates armPos = new Coordinates(0,0,0,0,0,0);
            //armPos.copy(PosState());


            //while(!stop)
            //{
            //    System.Threading.Thread.Sleep(2000);

            //    if (cli.clientReady)
            //    {

            //        if(stackSize() > 10){
            //            //mettre un message pour prévenir le problème et toucher au cdis ?    
            //        }

            //        armPos.copy(PosState());
            //    }

            //}
        }

    }
}
