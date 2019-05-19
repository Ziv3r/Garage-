using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException: Exception
    {
        private float m_MaxVal;
        private float m_MinVal;
        public ValueOutOfRangeException(float i_MaxVal, float i_MinVal)
            : base(string.Format("an error occured while trying to fill more then {0}, or less then {1} liters",i_MaxVal, i_MinVal))
        { 
            m_MaxVal = i_MaxVal;
            m_MinVal = i_MinVal;
        }
    }
}