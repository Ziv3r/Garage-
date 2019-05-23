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
        UI m_UI = new UI();
        Garage m_Garage = new Garage();
        Alocator m_Alocator = new Alocator();
        private bool m_ToExitProgram = false;


        public void Run()
        {
            string userChoice;
            eMenuChoice choiceAsEnum;
            while(!m_ToExitProgram)
            {
                //int choiceAsint;
                m_UI.PrintMenu();
                userChoice = m_UI.GetKeyFromUser();
                //int.TryParse(userChoice, out choiceAsint);
                choiceAsEnum = (eMenuChoice)Enum.Parse(typeof(eMenuChoice), userChoice);
                switch (choiceAsEnum)
                {
                    case eMenuChoice.AddVehichle:
                        addNewVehicle();
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
        private void addNewVehicle()
        {
            List<string> supportedVehicles = m_Alocator.SupportedVehicles;
            int vehicleIndexInList = m_UI.GetVehicleTypeFromUser(supportedVehicles);
            List<string> nameAndPhoneFromUser = m_UI.GetClientCardParams();
            List<string> vehiclesCommonData = m_UI.GetVehicleCommonData();
            ClientCard NewClientCard = m_Alocator.CreateNewClientCard(
                supportedVehicles[vehicleIndexInList].GetType(),
                nameAndPhoneFromUser,
                vehiclesCommonData
                );

            m_Garage.Add(NewClientCard);
           
        }
    }
}
