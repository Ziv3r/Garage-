﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException: Exception
    {
        private float m_MaxVal;
        private float m_MinVal;
        public ValueOutOfRangeException(float i_MaxVal, float i_MinVal)
            : base(string.Format("Error:Value must be between {0} to {1}",i_MinVal, i_MaxVal))
        { 
            m_MaxVal = i_MaxVal;
            m_MinVal = i_MinVal;
        }
    }
}