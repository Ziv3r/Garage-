using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageManager
    {
        public enum eMenuChoice : int
        {
            AddVehichle = 0,
            showLicenceNumOfAll,
            showLicenceNumByState,
            inflateWheels,
            fuelGasVehicle,
            chargeElecVehicle,
            showVehicleData,
            exit
        };
        UI m_ui = new UI();
        private bool m_ToExitProgram = false;

        //Garage m_Garage = new Garage();

        public void Run()
        {
            string userChoice;
            eMenuChoice choiceAsEnum;
            while(!m_ToExitProgram)
            {
                m_ui.PrintMenu();
                userChoice = m_ui.GetKeyFromUser();
                choiceAsEnum = (eMenuChoice)Enum.Parse(typeof(eMenuChoice), userChoice);
                switch (choiceAsEnum)
                {
                    case eMenuChoice.AddVehichle:
                        //do something
                        break;
                    case eMenuChoice.chargeElecVehicle:
                        //do something
                        break;
                    case eMenuChoice.fuelGasVehicle:
                        //do something
                        break;
                    case eMenuChoice.inflateWheels:
                        //do something
                        break;
                    case eMenuChoice.showLicenceNumByState:
                        //do something
                        break;
                    case eMenuChoice.showLicenceNumOfAll:
                        //do something
                        break;
                    case eMenuChoice.showVehicleData:
                        //do something
                        break;
                    case eMenuChoice.exit:
                        m_ToExitProgram = true;
                        break;
                }
            }
        }
    }
}
