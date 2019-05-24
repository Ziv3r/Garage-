using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private const float k_MaxAirPressure = 33f;
        private const float k_MaxAmountOfFeul = 8f;
        private const float k_MaxAmountOfElectricJuice = 1.4f;
        public enum eLicenceType
        {
            A, A1, A2, B
        }
        // change both to readonly
        private eLicenceType m_LicenceType;
        private int m_EngineBlackSmith;

        static Motorcycle()
        {
            s_VehicleParams = new Dictionary<string, string>();
            s_VehicleParams.Add("Enter Engine Volume:", "SetEngineVolume");
            s_VehicleParams.Add("Enter Licence Type ", "SetLicenceType");

        }
        public Motorcycle(
            string i_ModelName,
            string i_LicenceNumber,
            string i_VehicleType,
            string i_CurrentAmountEnergy
            ) : this(
                i_ModelName,
                i_LicenceNumber,
                i_VehicleType,
                i_VehicleType == "gas" ? Gas.eFuelType.Octan95 : Gas.eFuelType.None,
                i_CurrentAmountEnergy,
                i_VehicleType == "gas" ? k_MaxAmountOfFeul : k_MaxAmountOfElectricJuice
                )
        { }

        public Motorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            string i_VehicleType,
            Gas.eFuelType i_FuelType,
            string i_CurrentAmountEnergy,
            float i_TotalAmountOfEnergy
            ) : base(
                i_ModelName,
                i_LicenseNumber,
                k_NumOfWheels,
                k_MaxAirPressure,
                i_VehicleType,
                i_FuelType,
                i_CurrentAmountEnergy,
                i_TotalAmountOfEnergy
                )
        {}


        public void SetEngineVolume(string i_Volume)
        {
            int volumeAsInt = 0;
            try
            {
                volumeAsInt = int.Parse(i_Volume);
            }
            catch
            {
                throw new ArgumentException("Error: Engine volume must be an round number.");
            }

            m_EngineBlackSmith = volumeAsInt;
        }

        public void SetLicenceType(string i_LicenceType)
        {
            eLicenceType licenceTypeAsEnum;
            string licenceTypeFormatted = char.ToUpper(i_LicenceType[0]) + i_LicenceType.Substring(1);
            try
            {
                licenceTypeAsEnum = (eLicenceType)Enum.Parse(typeof(eLicenceType), licenceTypeFormatted);
            }
            catch
            {
                throw new ArgumentException("Error: licence type must be A, A1, A2 or B}");
            }
            m_LicenceType = licenceTypeAsEnum;
        }

        public override string ToString()
        {
            return string.Format(@"{0}
Engine Volume: {1}
Licence: {2}", base.ToString(), m_EngineBlackSmith, m_LicenceType);
        }
    }
}