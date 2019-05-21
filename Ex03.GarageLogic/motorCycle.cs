using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        enum eLicenceType
        {
            A, A1, A2, B
        }

        eLicenceType m_LicenceType;
        int m_EngineBlackSmith;

        public MotorCycle(string i_modelName, string i_LicenseNumber, float i_MaxAirPreasure,
            int i_VehicleType, int i_fuelType, float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy,
            int i_LicenceType, int i_EngineBlackSmith)
             : base(i_modelName, i_LicenseNumber, k_NumOfWheels, i_MaxAirPreasure, i_VehicleType, i_fuelType, i_CurrentAmountEnergy, i_TotalAmountOfEnergy)
        {
            m_LicenceType = (eLicenceType)i_LicenceType;
            m_EngineBlackSmith = i_EngineBlackSmith;
        }

        public override string ToString()
        {
            return string.Format("{0}\nThe Motor-Cycle has : {1} Engine Black Smith\nFor driving the Motor-Cycle you should have {2} Licence Type",
                base.ToString(), m_EngineBlackSmith ,m_LicenceType);
        }
    }
}