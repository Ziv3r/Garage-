﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_ManufacturerName = "Good-Year";
        private float m_CurrentAirPressure ;
        private float m_MaximalCapacityAirPressure;
        
        public Wheel(float i_MaximalCapacityAirPresure)
        {
            m_MaximalCapacityAirPressure = i_MaximalCapacityAirPresure;
        }
        public void fillUp(int i_AmountToFillUp)
        {
            if(m_CurrentAirPressure + i_AmountToFillUp <= m_MaximalCapacityAirPressure)
            {
                m_CurrentAirPressure += i_AmountToFillUp; 
            }
        }
        public void fillUp()
        {
            float diffBetweenCurrentToMax = m_MaximalCapacityAirPressure - m_CurrentAirPressure;
            m_CurrentAirPressure += diffBetweenCurrentToMax; 
        }

    }
}
