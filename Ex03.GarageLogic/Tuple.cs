using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    //  class will be used as a data stracture to hold and excecute operations in garageManager
    public class Tuple
    {
        private readonly int r_SerialNumber;
        private readonly string r_Message;
        private readonly string r_Method;

        public Tuple(int i_num, string i_Message, string i_Method)
        {
            r_SerialNumber = i_num;
            r_Method = i_Method;
            r_Message = i_Message;
        }
        //  properties

        public int SerialNumber
        {
            get { return r_SerialNumber; }
        }

        public string Message
        {
            get { return r_Message; }
        }

        public string Method
        {
            get { return r_Method; }
        }

        //  methods
        public override string ToString()
        {
            return string.Format("{0}. {1}", r_SerialNumber, r_Message);
        }
    }
}
