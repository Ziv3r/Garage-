//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Ex03.GarageLogic
//{
//    public class MotorCycle : Vehicle
//    {
//        private const int k_NumOfWheels = 2;
//        private const float k_MaxAirPressure = 33f;
//        private const float k_MaxAmountOfFeul = 8f;

//        enum eLicenceType
//        {
//            A, A1, A2, B
//        }
//        // change both to readonly
//        readonly eLicenceType r_LicenceType;
//        readonly int r_EngineBlackSmith;

//        public MotorCycle(
//            string i_ModelName,
//            string i_LicenceNumber,
//            EnergySource.eEnergySourceType i_VehicleType,
//            float i_CurrentAmountEnergy,
//            int i_LicenceType,
//            int i_EngineBlackSmith
//            ) : this(
//                i_ModelName,
//                i_LicenceNumber,
//                i_VehicleType,
//                i_VehicleType == EnergySource.eEnergySourceType.Gas ? Gas.eFuelType.Octan96 : Gas.eFuelType.None,
//                i_CurrentAmountEnergy,
//                k_MaxAmountOfFeul,
//                i_LicenceType,
//                i_EngineBlackSmith
//                )
//        { }
//        public MotorCycle(
//            string i_ModelName,
//            string i_LicenseNumber,
//            EnergySource.eEnergySourceType i_VehicleType,
//            Gas.eFuelType i_FuelType,
//            float i_CurrentAmountEnergy,
//            float i_TotalAmountOfEnergy,
//            int i_LicenceType,
//            int i_EngineBlackSmith
//            ) : base(
//                i_ModelName,
//                i_LicenseNumber,
//                k_NumOfWheels,
//                k_MaxAirPressure,
//                i_VehicleType,
//                i_FuelType,
//                i_CurrentAmountEnergy,
//                i_TotalAmountOfEnergy
//                )
//        {
//            r_LicenceType = (eLicenceType)i_LicenceType;
//            r_EngineBlackSmith = i_EngineBlackSmith;
//        }

//        public override string ToString()
//        {
//            return string.Format("{0}\nThe Motor-Cycle has : {1} Engine Black Smith\nFor driving the Motor-Cycle you should have {2} Licence Type",
//                base.ToString(), r_EngineBlackSmith, r_LicenceType);
//        }
//    }
//}