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
            actionByLicenceNumber,
            exit
        };
        public enum eOptionsByLicence : int
        {
            modifyState,
            inflateWheels,
            fillEnergy,
            showVehicleData,
        };

        UI m_UI = new UI();
        Garage m_Garage = new Garage();
        Alocator m_Alocator = new Alocator();
        private bool m_ToExitProgram = false;

        public void Run()
        {
            string userChoice;
            eMenuChoice choiceAsEnum;
            while (!m_ToExitProgram)
            {
                m_UI.PrintMenu();
                userChoice = m_UI.GetKeyFromUser();
                choiceAsEnum = (eMenuChoice)Enum.Parse(typeof(eMenuChoice), userChoice);
                switch (choiceAsEnum)
                {
                    case eMenuChoice.AddVehichle:
                        addNewVehicle();
                        break;
                    case eMenuChoice.showLicenceNumOfAll:
                        showAllLicenceNumbers();
                        break;
                    case eMenuChoice.showLicenceNumByState:
                        showLicenceNumByState();
                        break;
                    case eMenuChoice.actionByLicenceNumber:
                        CommandByLicenceNumber();
                        break;
                    case eMenuChoice.exit:
                        m_ToExitProgram = true;
                        break;
                }
            }
        }

        private void addNewVehicle()
        {
            bool success = false;

            List<string> supportedVehicles = m_Alocator.SupportedVehicles;
            Type vehichleType = m_UI.GetVehicleTypeFromUser(supportedVehicles);
            while (!success)
            {
                try
                {
                    List<string> vehiclesCommonData = m_UI.GetVehicleCommonData();
                    ClientCard NewClientCard = m_Alocator.CreateNewClientCard(vehichleType, vehiclesCommonData);
                    m_UI.GetRelevantDataFromUser(NewClientCard.Vehicle);
                    m_Garage.Add(NewClientCard);
                    m_UI.VehicleAddedSuccessfully(vehichleType);
                    success = true;
                }
                catch (Exception ex)
                {
                    m_UI.Print(ex.Message);
                }
            }
        }
        private void showAllLicenceNumbers()
        {
            List<string> LicenceNumbers = m_Garage.GetAllPlates();
            m_UI.PrintList(LicenceNumbers);
            m_UI.ToContinueMessage();
        }
        private void showLicenceNumByState()
        {
            bool succesFindState = false;
            while (!succesFindState)
            {
                try
                {
                    string state = m_UI.GetState();
                    List<string> LicenceByState = m_Garage.FindByState(state);
                    m_UI.PrintList(LicenceByState);
                    succesFindState = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void CommandByLicenceNumber()
        {
            string userChoice;
            string LicenceNumber = m_UI.getLicenceNumber();
            ClientCard CurrentVehicle = m_Garage.FindByLicenceNum(LicenceNumber);   //try catch 

            m_UI.printByLicenceCommands();
            userChoice = m_UI.GetKeyFromUser();
            eOptionsByLicence choiceAsEnum = (eOptionsByLicence)Enum.Parse(typeof(eOptionsByLicence), userChoice);

            switch (choiceAsEnum)
            {
                case eOptionsByLicence.modifyState:
                    modifyVehicleState(LicenceNumber);
                    break;
                case eOptionsByLicence.inflateWheels:
                    inflateWheels(LicenceNumber);
                    break;
                case eOptionsByLicence.fillEnergy:
                    fillEnergy(CurrentVehicle);
                    break;
                case eOptionsByLicence.showVehicleData:
                    showVehicleData(LicenceNumber);
                    break;
            }
        }

        private void modifyVehicleState(string i_LicenceNumber)
        {
            bool successChangeState = false;
            while (!successChangeState)
            {
                try
                {
                    string newState = m_UI.GetState();
                    m_Garage.ChangeVehicleState(i_LicenceNumber, newState);
                    successChangeState = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void inflateWheels(string i_LicenceNumber)
        {
            m_Garage.inflateWheels(i_LicenceNumber);
        }

        private void fillEnergy(ClientCard i_ClientCard)
        {
            string amount;
            string fuelType;
            m_UI.getDataForFillEnergy(i_ClientCard.Vehicle.Engine, out amount, out fuelType);
            i_ClientCard.Vehicle.FillEnergy(amount, fuelType);
        }

        private void showVehicleData(string i_LicenceNumber)
        {
            m_Garage.printVehicleData(i_LicenceNumber);
        }


    }
}