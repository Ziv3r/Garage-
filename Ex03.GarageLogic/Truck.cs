﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 12;
        private const float k_MaxAirPressure = 26f;
        private const float k_MaxAmountOfFuel = 110f;
        private bool m_IsCarringDangerCargo;
        private float m_CargoVolume;

        static Truck()
        {
            s_VehicleParams = new Dictionary<string, string>();
            s_VehicleParams.Add("Enter Y/N for carryng Hazardous Materials:", "SetCarringHazarous");
            s_VehicleParams.Add("Enter Cargo Volume: ", "SetCargoVolume");
        }

        public Truck(
            string i_ModelName,
            string i_LicenseNumber,
            string i_VehicleType,
            string i_CurrentAmountEnergy,
            string i_WheelManufactor,
            string i_WheelsAirPressure)
            : this(
                i_ModelName,
                i_LicenseNumber,
                i_VehicleType,
                i_VehicleType == "gas" ? Gas.eFuelType.Soler : Gas.eFuelType.None,
                i_CurrentAmountEnergy,
                i_WheelManufactor,
                i_WheelsAirPressure)
        {
        }

        public Truck(
            string i_modelName,
            string i_LicenseNumber,
            string i_VehicleType,
            Gas.eFuelType i_fuelType,
            string i_CurrentAmountEnergy,
            string i_WheelManufactor,
            string i_WheelsAirPressure)
            : base(
                i_modelName,
                i_LicenseNumber,
                k_NumOfWheels,
                k_MaxAirPressure,
                i_VehicleType,
                i_fuelType,
                i_CurrentAmountEnergy,
                k_MaxAmountOfFuel,
                i_WheelManufactor,
                i_WheelsAirPressure)
        {
            if(m_EnergySource is Electric)
            {
                throw new ArgumentException("Error: truck can only have gas engine.");
            }
        }

        public void SetCarringHazarous(string i_IsCarryngHaz)
        {
            m_IsCarringDangerCargo = i_IsCarryngHaz.ToUpper() == "Y";
        }

        public void SetCargoVolume(string i_Volume)
        {
            try
            {
                m_CargoVolume = float.Parse(i_Volume);
            }
            catch
            {
                throw new ArgumentException(string.Format("{0} is not a valid cargo volume", i_Volume));
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0}
Carry hazarous cargo:{1}
Cargo Volume: {2}",
base.ToString(),
m_IsCarringDangerCargo ? "Yes" : "No",
m_CargoVolume);
        }
    }
}
