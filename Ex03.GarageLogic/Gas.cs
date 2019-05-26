using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Gas : EnergySource
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
            None
        }

        public readonly eFuelType r_FuelType;

        public Gas(float i_Amount, float i_Max, eFuelType i_Type)
            : base(i_Max, i_Amount)
        {
            r_FuelType = i_Type;
        }

        public override void FillEnergy(float i_AmountToFillUp, eFuelType i_Type)
        {
            if(i_Type != r_FuelType)
            {
                throw new ArgumentException(string.Format("Error:Fuel type does not much. fuel type must be {0}", r_FuelType));
            }

            if (i_AmountToFillUp + m_Amount > r_Capacity)
            {
                throw new ValueOutOfRangeException(0, r_Capacity - m_Amount);
            }

            m_Amount += i_AmountToFillUp;
        }

        public override string ToString()
        {
            return string.Format(
                @"Max Amount Of Feul(liters): {0}
Current Amount Of Fuel(liters): {1}
Fuel Type: {2}",
                r_Capacity,
                m_Amount,
                r_FuelType);
        }
    }
}
