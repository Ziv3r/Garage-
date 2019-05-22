﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : EnergySource
    {
        public Electric(float i_Amount, float i_Max) : base(i_Amount, i_Max) { }


        public override void FillEnergy(float i_AmountToFillUp, Gas.eFuelType i_Type = Gas.eFuelType.Volt)
        {
            if (i_AmountToFillUp + m_Amount > r_Capacity)
            {
                throw new ArgumentException("Error: cannot fill more then tank capacity");
            }

            m_Amount += i_AmountToFillUp;
        }
    }
}
