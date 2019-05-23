using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Track : Vehicle
    {
        private const int k_NumOfWheels = 12;
        private const float k_MaxAirPressure = 26f;
        private const float k_MaxAmountOFFuel = 110f;
        private bool v_IsPassingDangerProducts;
        private float m_CargoVolume;

        public Track(
            string i_ModelName,
            string i_LicenseNumber,
            EnergySource.eEnergySourceType i_VehicleType,
            float i_CurrentAmountEnergy,
            bool i_IsPassingDangerProducts,
            float i_CargoVolume
            ) : this(
                i_ModelName,
                i_LicenseNumber,
                i_VehicleType,
                i_VehicleType == EnergySource.eEnergySourceType.Gas ? Gas.eFuelType.Soler : Gas.eFuelType.None,
                i_CurrentAmountEnergy,
                k_MaxAmountOFFuel,
                i_IsPassingDangerProducts,
                i_CargoVolume
                ){ }
        public Track(
            string i_modelName,
            string i_LicenseNumber,
            EnergySource.eEnergySourceType i_VehicleType,
            Gas.eFuelType i_fuelType,
            float i_CurrentAmountEnergy,
            float i_TotalAmountOfEnergy,
            bool i_IsPassingDangerProducts,
            float i_CargoCapacity
            ) : base(
                i_modelName,
                i_LicenseNumber,
                k_NumOfWheels,
                k_MaxAirPressure,
                i_VehicleType,
                i_fuelType,
                i_CurrentAmountEnergy,
                i_TotalAmountOfEnergy
                )
        {
            v_IsPassingDangerProducts = i_IsPassingDangerProducts;
            m_CargoVolume = i_CargoCapacity;
        }

    }
}
