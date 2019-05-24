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
        public static Dictionary<string, string> s_VehicleParams;

        public Vehicle(
            string i_modelName,
            string i_LicenseNumber,
            int i_NumberOfWheels,
            float i_MaxAirPreasure,
            int i_NumOfWheels,
            string i_VehicleType,
            Gas.eFuelType i_fuelType,
            string i_CurrentAmountEnergy,
            float i_TotalAmountOfEnergy
            )
        {
            m_ModelName = i_modelName;
            m_LicenseNumber = i_LicenseNumber;
            float currAmountOfEnergy = -1f;
            EnergySource.eEnergySourceType type;
            try
            {
                 currAmountOfEnergy = float.Parse(i_CurrentAmountEnergy);
                 type = (EnergySource.eEnergySourceType)Enum.Parse(typeof(EnergySource.eEnergySourceType), i_VehicleType);
            }
            catch(Exception ex)
            {
                throw new FormatException(string.Format("Error: The field \"{0}\" was not in the right format",
                    currAmountOfEnergy == -1 ? "Fuel Amount" : "Energy Type"), ex);
            }

            if (type == EnergySource.eEnergySourceType.Gas)
            {
                m_EnergySource = new Gas(currAmountOfEnergy, i_TotalAmountOfEnergy, i_fuelType);
            }
            else
            {
                m_EnergySource = new Electric(currAmountOfEnergy, i_TotalAmountOfEnergy);
            }

            m_VehicleWheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(i_MaxAirPreasure));
            }
        }

        public string LicenceNumber
        {
            get { return m_LicenseNumber; }
        }

        public Dictionary<string, string> VehicleParamsSet
        {
            get { return s_VehicleParams; }
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
