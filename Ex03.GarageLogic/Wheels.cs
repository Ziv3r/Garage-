using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private readonly float r_AirPressureCapacity; 
        private readonly string r_ManufacturerName = "Good-Year";
        private float m_AirPressure ;
        
        public Wheel(float i_Capacity)
        {
            r_AirPressureCapacity = i_Capacity;
        }

        public void fill(float i_AmountToFillUp)
        {
            if(m_AirPressure + i_AmountToFillUp > r_AirPressureCapacity)
            {
                throw new ArgumentException("Error: cannot fill more then wheel capacity");
            }
                m_AirPressure += i_AmountToFillUp; 
        }

        public void fillToMax()
        {
            float diffBetweenCurrentToMax = r_AirPressureCapacity - m_AirPressure;
            fill(diffBetweenCurrentToMax);
        }

        public override string ToString()
        {
            return string.Format(@"Max air pressure: {0}
Current air pressure: {1}
Manufacture: {2}", r_AirPressureCapacity, m_AirPressure, r_ManufacturerName);
        }

    }
}
