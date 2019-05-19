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
        List<Wheel> m_VehicleWheels = null ;
        EnergySource m_EnergySource; 

        public Vehicle(string i_modelName, string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPreasure,
            int i_VehicleType, int i_fuelType, float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy)
        {
            m_ModelName = i_modelName;
            m_LicenseNumber = i_LicenseNumber;
            m_VehicleWheels = new List<Wheel>(i_NumberOfWheels){ new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure), new Wheel(i_MaxAirPreasure) };
            m_EnergySource = new EnergySource(i_VehicleType, i_fuelType, i_CurrentAmountEnergy, i_TotalAmountOfEnergy);
            //updatePercentage();
        }
        // Type is 0 or 1 - gas or electric
        public void FillUpAirPressure(int i_ToFillUp)
        {
            foreach(Wheel curWheel in m_VehicleWheels)
            {
                curWheel.fillUp(i_ToFillUp);
            }
        }
        public void FillUpEnergy()
        {
            m_EnergySource.FillUpEnergy(50);
        }
        public void ShowVehicleData()
        {
            //Console.WriteLine("")
        }
        
        private class EnergySource
        {
            enum eEnergySourceType {Electirc=1 , Gas=2 }
            enum eEnergyType {Soler ,Octan95 ,Octan96 ,Octan98,Volt }

            eEnergySourceType m_SourceType;         //gas or electirc
            eEnergyType m_EnergyType;               //type of each subject(fuel or volt);
            float m_MaxCapacity;                    
            float m_CurrentCapacity;

            public energySource(int i_VehicleType,int i_FuelType,float i_CurrentAmountEnergy,float i_TotalAmountOfEnergy)
            {
                m_SourceType = (eEnergySourceType)i_VehicleType;
                m_EnergyType = (eEnergyType)i_FuelType;
                m_CurrentCapacity = i_CurrentAmountEnergy;
                m_MaxCapacity = i_TotalAmountOfEnergy; 
            }
            public void FillUpEnergy(float i_AmountToFillUp)
            {
                m_CurrentCapacity += i_AmountToFillUp; 
            } 
        }
    }
}
