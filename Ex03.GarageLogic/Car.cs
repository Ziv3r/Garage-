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
        public enum eColor
        {
            red = 0, 
            blue,
            black, 
            grey 
        };

        private eColor m_CarColor ;
        private int m_NumDoors;

        //static Car()
        //{
        //    sr_VehicleParams.Add("Enter Vehicle Color", "Color");
        //    sr_VehicleParams.Add("Enter Number Of Doors", "NumOfDoors");
        //}

        //public Car(string i_VehicleType, string i_LicenceNum, )
        //    : base(i_VehicleType, i_LicenceNum)
        //{}
     


        public Car(string i_modelName,
            string i_LicenseNumber,
            string i_VehicleType,
            float i_CurrentAmountEnergy
            )
            : this(i_modelName,
                  i_LicenseNumber,
                  i_VehicleType,
                  i_VehicleType == "gas" ? Gas.eFuelType.Octan96 : Gas.eFuelType.None,
                  i_CurrentAmountEnergy,
                  k_MaxLitersOfFeul                  
                  )
        { }

        public Car(string i_modelName,
            string i_LicenseNumber,
            string i_VehicleType,
            Gas.eFuelType i_fuelType,
            float i_CurrentAmountEnergy,
            float i_TotalAmountOfEnergy
            )
           : base(i_modelName,
                  i_LicenseNumber,
                  k_NumOfWheels,
                  k_MaxAirPressure,
                  k_NumOfWheels,
                  i_VehicleType,
                  i_fuelType,
                  i_CurrentAmountEnergy,
                  i_TotalAmountOfEnergy
                  )
        {
        }

        public eColor Color
        {
            set { m_CarColor = value; }
        }

        public int NumOfDoors
        {
            set { m_NumDoors = value; }
        }


        public override string ToString()
        {
            return string.Format("{0}\nThe car color is : {1}\nThe car has {2} doors ", base.ToString(), m_CarColor, m_NumDoors);
        }
    }
}
