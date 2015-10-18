using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Shooter
{
    [Serializable]
    public class SerializableObject
    {
        DataType dataType; // type of data
        String message;
        String name;
        int score;

        public SerializableObject(DataType dt)
        {
            this.dataType = dt;
        }

        public SerializableObject(DataType dt, String name)
        {
            this.dataType = dt;
            this.name = name;
        }

        public SerializableObject(DataType dt, String name, int score)
        {
            this.dataType = dt;
            this.name = name;
            this.score = score;
        }

        public SerializableObject(DataType dt, String name, String message)
        {
            this.dataType = dt;
            this.name = name;
            this.message = message;
        }

        public DataType DataType
        {
            get { return dataType; }
        }

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
