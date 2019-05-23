using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private readonly float m_AirPressureCapacity; 
        private string m_ManufacturerName = "Good-Year";
        private float m_AirPressure ;
        
        public Wheel(float i_CapacityAirPressure)
        {
            m_AirPressureCapacity = i_CapacityAirPressure;
        }

        public void fill(float i_AmountToFillUp)
        {
            if(m_AirPressure + i_AmountToFillUp > m_AirPressureCapacity)
            {
                throw new ArgumentException("Error: cannot fill more then wheel capacity");
            }
                m_AirPressure += i_AmountToFillUp; 
        }

        public void fillToMax()
        {
            float diffBetweenCurrentToMax = m_AirPressureCapacity - m_AirPressure;
            fill(diffBetweenCurrentToMax);
        }

    }
}
