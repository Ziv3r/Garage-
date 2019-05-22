using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Gas : EnergySource
    {
        public enum eFuelType { Soler, Octan95, Octan96, Octan98, Volt }

        public readonly eFuelType r_EnergyType;

        public Gas(float i_Amount, float i_Max, eFuelType i_Type)
            : base(i_Amount, i_Max)
        {
            r_EnergyType = i_Type;
        }

        public override void FillEnergy(float i_AmountToFillUp, eFuelType i_Type)
        {
            if (i_AmountToFillUp + m_Amount > r_Capacity)
            {
                throw new ArgumentException("Error: cannot fill more then tank capacity");
            }

            m_Amount += i_AmountToFillUp;
        }

    }
}
