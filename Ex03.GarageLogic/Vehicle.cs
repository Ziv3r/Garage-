using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_ModelName;
        string m_LicenseNumber;
        //        float m_PercantageEnergyLeft ;
        List<Wheel> m_VehicleWheels = null;
        EnergySource m_EnergySource;

        public Vehicle(string i_modelName, string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPreasure,
            EnergySource.eEnergySourceType i_VehicleType, Vehicle.Gas.eEnergyType i_fuelType, float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy)
        {
            m_ModelName = i_modelName;
            m_LicenseNumber = i_LicenseNumber;
            m_VehicleWheels = new List<Wheel>(i_NumberOfWheels) { new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure) };

            if (i_VehicleType == EnergySource.eEnergySourceType.Gas)
            {
                m_EnergySource = new Gas(i_CurrentAmountEnergy, i_TotalAmountOfEnergy, i_fuelType);
            }
            else
            {
                m_EnergySource = new Electric(i_CurrentAmountEnergy, i_TotalAmountOfEnergy);
            }
        }
        // Type is 0 or 1 - gas or electric
        public void FillAirPressure(float i_ToFillUp)
        {
            foreach (Wheel curWheel in m_VehicleWheels)
            {
                curWheel.fill(i_ToFillUp);
            }
        }
        public void FillEnergy(float i_Amount, string i_FuelType)
        {
            // to check if parse throw exception or needed here
            Gas.eEnergyType type = (Gas.eEnergyType)Enum.Parse(typeof(Gas.eEnergyType), i_FuelType);

            m_EnergySource.FillEnergy(i_Amount, type);
        }

        public abstract class EnergySource
        {
            public enum eEnergySourceType { Electirc = 1, Gas = 2 }
            protected readonly float r_Capacity;
            protected float m_Amount;

            public EnergySource(float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy)
            {
                m_Amount = i_CurrentAmountEnergy;
                r_Capacity = i_TotalAmountOfEnergy;
            }

            public abstract void FillEnergy(float i_AmountToFillUp, Gas.eEnergyType i_Type);
        }
        //  end of EnergySource

        public class Gas : EnergySource
        {
            public enum eEnergyType { Soler, Octan95, Octan96, Octan98, Volt }
            public readonly eEnergyType r_EnergyType;

            public Gas(float i_Amount, float i_Max, eEnergyType i_Type)
                : base(i_Amount, i_Max)
            {
                r_EnergyType = i_Type;
            }

            public override void FillEnergy(float i_AmountToFillUp, eEnergyType i_Type)
            {
                if (i_AmountToFillUp + m_Amount > r_Capacity)
                {
                    throw new ArgumentException("Error: cannot fill more then tank capacity");
                }

                m_Amount += i_AmountToFillUp;
            }

        }
        //  end of Gas class

        public class Electric : EnergySource
        {

            public Electric(float i_Amount, float i_Max) : base(i_Amount, i_Max) { }


            public override void FillEnergy(float i_AmountToFillUp, Gas.eEnergyType i_Type = Gas.eEnergyType.Volt)
            {
                if (i_AmountToFillUp + m_Amount > r_Capacity)
                {
                    throw new ArgumentException("Error: cannot fill more then tank capacity");
                }

                m_Amount += i_AmountToFillUp;
            }
        }

    }
}
