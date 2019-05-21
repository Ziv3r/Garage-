using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Track : Vehicle
    {
        private const int k_NumOfWheels = 12;
        private const float k_MaxAirPressure = 28f;
        bool m_IsPassingDangerProducts;
        float m_CargoCapacity;

        public Track(string i_modelName, string i_LicenseNumber,
           int i_VehicleType, int i_fuelType, float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy,
           bool i_IsPassingDangerProducts, float i_CargoCapacity)
           : base(i_modelName, i_LicenseNumber, k_NumOfWheels, k_MaxAirPressure, i_VehicleType, i_fuelType, i_CurrentAmountEnergy, i_TotalAmountOfEnergy)
        {
            m_IsPassingDangerProducts = i_IsPassingDangerProducts;
            m_CargoCapacity = i_CargoCapacity;
        }

    }
}
