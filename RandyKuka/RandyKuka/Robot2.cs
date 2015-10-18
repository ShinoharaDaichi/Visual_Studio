using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Diagnostics;

namespace be_isib_kuka
{
    public class Robot2
    {
        XmlDocument XmlToRobot = new XmlDocument();
        
        Client2 cli = new Client2();
       
        bool stop = false;
        bool readyToSend = true;
        List<Motion> motionStack = new List<Motion>();

        int tempo = 5;
                
        public Robot2()
        {
            cli.StartConnecting();
            cli.ReceivedACKEvent += ReceivedACK;
            Thread t = new Thread(motionProcessing);
            t.Name = "Motion_Processing_Thread";
            t.Priority = ThreadPriority.Normal;
            t.IsBackground = true;
            t.Start();         
        }

        private void ReceivedACK()
        {
            try {
                lock (motionStack)
                {
                    Debug.WriteLine("Removed from stack");
                    motionStack.RemoveAt(0);
                    readyToSend = true;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void addMotion(Motion motion)
        {
                Motion tempMotion;
            
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
                    motionStack.Add(motion);
                Debug.WriteLine("StackSize : " + stackSize());
                }         
        }

        public Motion getNextMotion()
        {
            lock (motionStack)
            {
                if(motionStack.Count > 0)
                {
                    return motionStack.First();
                }
                else
                {
                    return null;
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
            while (!stop)
            {
                if (stackSize() > 0)
                {
                    if (readyToSend && cli.ReadyToSend)
                    {
                        lock (XmlToRobot)
                        {
                            readyToSend = false;
                            XmlToRobot = createXMLFromMotion(getNextMotion());
                            Debug.WriteLine("Created XML is " + XmlToRobot.InnerXml);

                            cli.SendXML(XmlToRobot);
                            XmlToRobot.Save("RobotRSI2.xml");
                        }
                    }else
                    {
                        Thread.Sleep(tempo);
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(tempo);
                }

            }//end while

        }//end motionProcessing
        
        public XmlDocument createXMLFromMotion(Motion m)
        {
            XmlDocument xml = new XmlDocument();
            try {                
                XmlNode rootNode = xml.CreateElement("Sen");
                XmlAttribute attribute = xml.CreateAttribute("Type");
                attribute.Value = "ImFree";
                rootNode.Attributes.Append(attribute);
                xml.AppendChild(rootNode);

                XmlNode elementNode = xml.CreateElement("Point1X");
                elementNode.InnerText = m.X.ToString();
                rootNode.AppendChild(elementNode);

                elementNode = xml.CreateElement("Point1Y");
                elementNode.InnerText = m.Y.ToString();
                rootNode.AppendChild(elementNode);

                elementNode = xml.CreateElement("Point1Z");
                elementNode.InnerText = m.Z.ToString();
                rootNode.AppendChild(elementNode);
            }
            catch (Exception e)
            { Debug.WriteLine(e.ToString()); }
            
            return xml;
        }

    }//end class
}//end namespace
