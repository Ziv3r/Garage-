using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : EnergySource
    {
        public Electric(float i_Amount, float i_Max) : base(i_Max, i_Amount) { }


        public override void FillEnergy(float i_AmountToFillUp, Gas.eFuelType i_Type = Gas.eFuelType.None)
        {
            if (i_AmountToFillUp + m_Amount > r_Capacity)
            {
                throw new ValueOutOfRangeException(0, r_Capacity - m_Amount);
            }

            m_Amount += i_AmountToFillUp;
        }

        public override string ToString()
        {
            return string.Format(@"Max Amount Of Time(minutes): {0}
Current Amount Of Time(minutes): {1}", r_Capacity, m_Amount);
        }
    }
}
