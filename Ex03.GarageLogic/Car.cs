using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        private const float k_MaxAirPressure = 31f;
        private const float k_MaxLitersOfFeul = 8f;
        enum eColoros
        {
            red = 0, 
            blue,
            black, 
            grey 
        };

        private eColoros m_CarColor ;
        private int m_NumDoors;

        public Car(string i_modelName,
            string i_LicenseNumber,
            EnergySource.eEnergySourceType i_VehicleType,
            //float i_CurrentAmountEnergy,
            int i_CarColor,
            int i_NumDoors
            )
            : this(i_modelName,
                  i_LicenseNumber,
                  i_VehicleType,
                  i_VehicleType Gas.eFuelType.Octan96,
                  50f,//i_CurrentAmountEnergy,
                  k_MaxLitersOfFeul,
                  i_CarColor,
                  i_NumDoors
                  ){}

        public Car(string i_modelName,
            string i_LicenseNumber,
            EnergySource.eEnergySourceType i_VehicleType,
            Gas.eFuelType i_fuelType,
            float i_CurrentAmountEnergy,
            float i_TotalAmountOfEnergy,
            int i_CarColor,
            int i_NumDoors
            )
           : base(i_modelName,
                  i_LicenseNumber,
                  k_NumOfWheels,
                  k_MaxAirPressure,
                  i_VehicleType,
                  i_fuelType,
                  i_CurrentAmountEnergy,
                  i_TotalAmountOfEnergy
                  )
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
