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
        private const float k_MaxAmountOfElectricJuice = 1.8f;
        public enum eColor
        {
            red = 0, 
            blue,
            black, 
            grey 
        };

        private eColor m_CarColor ;
        private int m_NumDoors;

        static Car()
        {
            s_VehicleParams = new Dictionary<string, string>();
            s_VehicleParams.Add("Enter Number Of Doors", "SetNumOfDoors");
            s_VehicleParams.Add("Enter Vehicle Color", "SetColor");
         
        }

        public Car(string i_modelName,
            string i_LicenseNumber,
            string i_VehicleType,
            string i_CurrentAmountEnergy
            )
            : this(i_modelName,
                  i_LicenseNumber,
                  i_VehicleType,
                  i_VehicleType == "gas" ? Gas.eFuelType.Octan96 : Gas.eFuelType.None,
                  i_CurrentAmountEnergy,
                  i_VehicleType == "gas" ? k_MaxLitersOfFeul : k_MaxAmountOfElectricJuice                 
                  )
        { }

        public Car(string i_modelName,
            string i_LicenseNumber,
            string i_VehicleType,
            Gas.eFuelType i_fuelType,
            string i_CurrentAmountEnergy,
            float i_TotalAmountOfEnergy
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
        {}

        public eColor Color
        {
            set { m_CarColor = value; }
        }

        public int NumOfDoors
        {
            set { m_NumDoors = value; }
        }

        public void SetColor(string i_Color)
        {
            m_CarColor = (eColor)Enum.Parse(typeof(eColor), i_Color.ToLower());
        }

        public void SetNumOfDoors(string i_NumOfDoors)
        {
            m_NumDoors = int.Parse(i_NumOfDoors);
        }

        public override string ToString()
        {
            return string.Format("{0}\nThe car color is : {1}\nThe car has {2} doors ", base.ToString(), m_CarColor, m_NumDoors);
        }
    }
}
