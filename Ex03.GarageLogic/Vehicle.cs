using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_ModelName;
        string m_LicenseNumber;
        float m_MaxAirPreasure;
        List<Wheel> m_VehicleWheels = null ;
        EnergySource m_EnergySource;

        //-------------------------------------Propertiees-------------------//

        public string LicenceNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        //-------------------------------------Propertiees-------------------//

        public Vehicle(string i_modelName, string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPreasure,
            int i_VehicleType, int i_fuelType, float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy)
        {
            m_ModelName = i_modelName;
            m_LicenseNumber = i_LicenseNumber;
            m_MaxAirPreasure = i_MaxAirPreasure;
            m_VehicleWheels = new List<Wheel>(i_NumberOfWheels);
            for(int i=0; i< m_VehicleWheels.Capacity; i++)
            {
                m_VehicleWheels.Add(new Wheel(i_MaxAirPreasure));
            }
            m_EnergySource = new EnergySource(i_VehicleType, i_fuelType, i_CurrentAmountEnergy, i_TotalAmountOfEnergy);
        }

        // Type is 0 or 1 - gas or electric
        public void FillUpAirPressure(int i_ToFillUp)
        {
            foreach(Wheel curWheel in m_VehicleWheels)
            {
                curWheel.fillUp(i_ToFillUp);
            }
        }
        public void FillUpAirPressure()
        {
            foreach (Wheel curWheel in m_VehicleWheels)
            {
                curWheel.fillUp();
            }
        }
        public void FillUpEnergy()
        {
            m_EnergySource.FillUpEnergy(50);
        }

        public override string ToString()
        {
            string s = String.Format("model name : {0} \nLicenseNumber : {1} \nnumber of wheels :{2} \n" +
               "the MaxAirPreasure of each whell is :{3}\nThe Vehicle is {4} vehice \nThe energy source is :{5}\n"
               + "the car has : {6} max Capacity\nThe current is :{7}", m_ModelName, m_LicenseNumber, m_VehicleWheels.Count, m_MaxAirPreasure, m_EnergySource.SourceType, m_EnergySource.EnergyType,
               m_EnergySource.MaxCapacity, m_EnergySource.CurrentCapacity);
            return s;
        }
        //virtual public void ShowVehicleData()
        //{ 
        //    string s = String.Format("model name : {0} \nLicenseNumber : {1} \nnumber of wheels :{2} \n" + 
        //        "the MaxAirPreasure of each whell is :{3}\nThe car is {4} car\nThe car energy source is :{5}\n"
        //        + "the car has : {6} max Capacity\nThe current is :{7}", m_ModelName, m_LicenseNumber, m_VehicleWheels.Count, m_MaxAirPreasure ,m_EnergySource.SourceType , m_EnergySource.EnergyType,
        //        m_EnergySource.MaxCapacity , m_EnergySource.CurrentCapacity);

        //    Console.WriteLine(s);
        //}
        public float energyPercentage()
        {
            return m_EnergySource.CurrentCapacity / m_EnergySource.MaxCapacity;
        }

        private class EnergySource
        {
            public enum eEnergySourceType {Electirc=1,Gas }
            public enum eEnergyType {Soler ,Octan95 ,Octan96 ,Octan98,Minutes }

            private eEnergySourceType m_EnergyType; //gas or electirc
            private eEnergyType m_SourceType;                      //type of each subject(fuel or volt);
            private float m_MaxCapacity;                    
            private float m_CurrentCapacity;

            //-------------------------------------Propertiees-------------------//
            public eEnergySourceType SourceType
            {
                get { return m_EnergyType; }
                set { m_EnergyType= value; }
            }
            public eEnergyType EnergyType
            {
                get { return m_SourceType ; }
                set { m_SourceType = value; }
            }
            public float MaxCapacity
            {
                get { return m_MaxCapacity; }
                set {  m_MaxCapacity = value ; }
            }
            public float CurrentCapacity
            {
                get { return m_CurrentCapacity; }
                set { m_CurrentCapacity = value; }
            }
            //-------------------------------------Propertiees-------------------//

            public EnergySource(int i_VehicleType,int i_FuelType,float i_CurrentAmountEnergy,float i_TotalAmountOfEnergy)
            {
                m_SourceType = (eEnergyType)i_VehicleType;
                m_EnergyType = (eEnergySourceType)i_FuelType;
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
