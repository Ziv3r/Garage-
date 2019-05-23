using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_ModelName;
        string m_LicenseNumber;
        List<Wheel> m_VehicleWheels = null;
        EnergySource m_EnergySource;
        public static readonly Dictionary<string, string> sr_VehicleParams;

        //public vehicle(string i_modeltype, string i_licencenumber, energysource.eenergysourcetype i_engine,float i_maxenergy)
        //{
        //    m_modelname = i_modeltype;
        //    m_licensenumber = i_licencenumber;
        //    if (i_engine == energysource.eenergysourcetype.gas)
        //    {
        //        m_energysource = new gas(4, i_totalamountofenergy, i_engine);
        //    }
        //    else
        //    {
        //        m_energysource = new electric(i_currentamountenergy, i_totalamountofenergy);
        //    }
        //}

        public Vehicle(
            string i_modelName,
            string i_LicenseNumber,
            int i_NumberOfWheels,
            float i_MaxAirPreasure,
            int i_NumOfWheels,
            string i_VehicleType,
            Gas.eFuelType i_fuelType,
            float i_CurrentAmountEnergy,
            float i_TotalAmountOfEnergy
            )
        {
            m_ModelName = i_modelName;
            m_LicenseNumber = i_LicenseNumber;
            m_VehicleWheels = new List<Wheel>(i_NumberOfWheels) { new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure) };

            EnergySource.eEnergySourceType type = (EnergySource.eEnergySourceType)Enum.Parse(typeof(EnergySource.eEnergySourceType), i_VehicleType);
            if (type == EnergySource.eEnergySourceType.Gas)
            {
                m_EnergySource = new Gas(i_CurrentAmountEnergy, i_TotalAmountOfEnergy, i_fuelType);
            }
            else
            {
                m_EnergySource = new Electric(i_CurrentAmountEnergy, i_TotalAmountOfEnergy);
            }

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(i_MaxAirPreasure));
            }
        }

        public Dictionary<string, string> VehicleParamsSet
        {
            get { return sr_VehicleParams; }
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
            Gas.eFuelType type = (Gas.eFuelType)Enum.Parse(typeof(Gas.eFuelType), i_FuelType);

            m_EnergySource.FillEnergy(i_Amount, type);
        }
    }
}
