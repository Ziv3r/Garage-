using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        public enum eEnergySourceType { Electirc = 1, Gas = 2 }
        protected readonly float r_Capacity;
        protected float m_Amount;

        public EnergySource( float i_TotalAmountOfEnergy)
        {
           // m_Amount = i_CurrentAmountEnergy;
            r_Capacity = i_TotalAmountOfEnergy;
        }

        public abstract void FillEnergy(float i_AmountToFillUp, Gas.eFuelType i_Type);
    }
}
