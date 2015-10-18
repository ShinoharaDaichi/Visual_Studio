using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Shooter
{
    static public class Serialization
    {
        static public byte[] Serialize(object o) //object must be serializable
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            //write binaries of o in a stream(memory), then serialized
            binFormat.Serialize(memStream, o); 
            return memStream.GetBuffer();
        }

        static public object Deserialize(byte[] buffer)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            //place buffer in memory, then deserialized
            memStream.Write(buffer, 0, buffer.Length);
			memStream.Seek(0, 0); //reset the pointer in the memory 
            return binFormat.Deserialize(memStream);
        }
    }
}
