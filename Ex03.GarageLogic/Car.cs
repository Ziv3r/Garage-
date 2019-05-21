using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        enum eColoros
        {
            red = 0, 
            blue,
            black, 
            grey 
        };

        eColoros m_CarColor ;
        int m_NumDoors;

        //public override void ShowVehicleData()
        //{
        //    base.ShowVehicleData();
        //    string s = String.Format("The car color is : {0}\nThe car has {1} doors", m_CarColor, m_NumDoors);
        //    Console.WriteLine(s);
        //}

        public Car(string i_modelName, string i_LicenseNumber, float i_MaxAirPreasure,
            int i_VehicleType, int i_fuelType, float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy,
            int i_CarColor, int i_NumDoors)
            : base(i_modelName, i_LicenseNumber, k_NumOfWheels, i_MaxAirPreasure, i_VehicleType, i_fuelType, i_CurrentAmountEnergy, i_TotalAmountOfEnergy)
        {
            m_CarColor = (eColoros)i_CarColor;
            m_NumDoors = i_NumDoors; 
        }
        public override string ToString()
        {
            return string.Format("{0}\nThe car color is : {1}\nThe car has {2} doors ", base.ToString(), m_CarColor, m_NumDoors);
        }

    }
}
