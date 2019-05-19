using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        enum eLicenceType
        {
            A, A1, A2, B
        }

        eLicenceType m_LicenceType;
        int m_EngineBlackSmith;

        public MotorCycle(string i_modelName, string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPreasure,
            int i_VehicleType, int i_fuelType, float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy,
            int i_LicenceType, int i_EngineBlackSmith)
             : base(i_modelName, i_LicenseNumber, i_NumberOfWheels, i_MaxAirPreasure, i_VehicleType, i_fuelType, i_CurrentAmountEnergy, i_TotalAmountOfEnergy)
        {
            m_LicenceType = (eLicenceType)i_LicenceType;
            m_EngineBlackSmith = i_EngineBlackSmith;
        }
    }
}