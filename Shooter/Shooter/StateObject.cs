using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Shooter
{
    public class StateObject
    {
        private Socket workingSocket = null;
        public byte[] TempBuffer = new byte[1024];

        private List<byte> buffer = new List<byte>();

        public List<byte> Buffer 
        { 
            get { return buffer; } 
        }

        public void AddTempBufferToBuffer(int nbrBytes)
        {
            for (int i = 0; i < nbrBytes; i++)
            {
                Buffer.Add(TempBuffer[i]);
            }
        }

        public Socket WorkingSocket
        {
            get { return workingSocket; }
            set { workingSocket = value; }
        }

    }
}
