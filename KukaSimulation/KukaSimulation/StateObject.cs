using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;

namespace be_isib_kuka
{
     public class StateObject
    {
        public Socket WorkingSocket;
        public byte[] TempBuffer = new byte[1024];
        public List<byte> Buffer = new List<byte>();

        public void AddTempBufferToBuffer(int nbrBytes)
        {
            for (int i = 0; i < nbrBytes; i++)
            {
                Buffer.Add(TempBuffer[i]);
            }
        }

    }
}
