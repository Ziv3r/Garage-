﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private List<Wheel> m_VehicleWheels = null;
        protected EnergySource m_EnergySource;
        public static Dictionary<string, string> s_VehicleParams;

        public Vehicle(
            string i_modelName,
            string i_LicenseNumber,
            int i_NumberOfWheels,
            float i_MaxAirPreasure,
            string i_VehicleType,
            Gas.eFuelType i_fuelType,
            string i_CurrentAmountEnergy,
            float i_TotalAmountOfEnergy,
            string i_WheelManufactor,
            string i_WheelAirPressure)
        {
            r_ModelName = i_modelName;
            r_LicenseNumber = i_LicenseNumber;
            float currAmountOfEnergy = -1f;
            float currAirPressure;
            EnergySource.eEnergySourceType type;
            try
            {
                currAmountOfEnergy = float.Parse(i_CurrentAmountEnergy);
                type = (EnergySource.eEnergySourceType)Enum.Parse(typeof(EnergySource.eEnergySourceType), i_VehicleType);
            }
            catch (Exception ex)
            {
                throw new FormatException(
                    string.Format(
                    "Error: The field \"{0}\" was not in the right format",
                    currAmountOfEnergy == -1 ? "Fuel Amount" : "Engine Type"),
                    ex);
            }

            if(!float.TryParse(i_WheelAirPressure, out currAirPressure) || currAirPressure > i_MaxAirPreasure)
            {
                throw new FormatException(string.Format("Error: could not assign {0} as current air pressure", i_WheelAirPressure));
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
                m_VehicleWheels.Add(new Wheel(i_MaxAirPreasure, i_WheelManufactor, currAirPressure));
            }
        }

        public EnergySource Engine
        {
            get { return m_EnergySource; }
        }

        public string LicenceNumber
        {
            get { return r_LicenseNumber; }
        }

        public Dictionary<string, string> VehicleParamsSet
        {
            get { return s_VehicleParams; }
        }

        // Type is 0 or 1 - gas or electric
        public void FillToMax()
        {
            foreach (Wheel curWheel in m_VehicleWheels)
            {
                curWheel.FillToMax();
            }
        }

        public void FillEnergy(string i_Amount, string i_FuelType = "None")
        {
            try
            {
                string formatedFuelType = char.ToUpper(i_FuelType[0]) + i_FuelType.Substring(1);
                float amount = float.Parse(i_Amount);
                Gas.eFuelType type = (Gas.eFuelType)Enum.Parse(typeof(Gas.eFuelType), formatedFuelType);
                amount = type == Gas.eFuelType.None ? amount / 60 : amount; // user provide amount in minutes. amount saved in hours
                m_EnergySource.FillEnergy(amount, type);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Error: \"{0}\" is not a valid type of feul, " +
                    "or \"{1}\" is not a valid amount",
                        i_FuelType),
                    ex);
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"Model Name: {0}
Licence Plate Number: {1}
Number Of Wheels: {2}
Wheels Data:
{3}
Engine Data:
{4}",
                r_ModelName,
                r_LicenseNumber,
                m_VehicleWheels.Count,
                m_VehicleWheels[0].ToString(),
                m_EnergySource.ToString());
        }
    }
}
