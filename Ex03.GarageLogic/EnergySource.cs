using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        public enum eEnergySourceType { Electric, Gas };
        protected readonly float r_Capacity;
        protected float m_Amount;

        public EnergySource( float i_TotalAmountOfEnergy, float i_Amount)
        {
            if(i_Amount > i_TotalAmountOfEnergy)
            {
                throw new ValueOutOfRangeException(i_TotalAmountOfEnergy, 0);
            }
            m_Amount = i_Amount;
            r_Capacity = i_TotalAmountOfEnergy;
        }

        public abstract void FillEnergy(float i_AmountToFillUp, Gas.eFuelType i_Type);

      
    }


}
