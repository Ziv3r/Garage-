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
            fuelGasVehicle,
            ChargeElectircCar,
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
                userChoice = m_UI.GetKeyFromUser(1, Enum.GetValues(typeof(eOptionsByLicence)).Length);
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void CommandByLicenceNumber()
        {
            string userChoice;
            bool success = false;
            string licenceNumber = string.Empty;
            ClientCard currentVehicle = null;
            while (!success)
            {
                try
                {
                    licenceNumber = m_UI.getLicenceNumber();
                    currentVehicle = m_Garage.FindByLicenceNum(licenceNumber);
                    success = true;
                }
                catch (Exception ex)
                {
                    m_UI.Print(ex.Message);
                }
            }

            m_UI.printByLicenceCommands();
            userChoice = m_UI.GetKeyFromUser(1, Enum.GetValues(typeof(eOptionsByLicence)).Length);
            eOptionsByLicence choiceAsEnum = (eOptionsByLicence)Enum.Parse(typeof(eOptionsByLicence), userChoice);

            try
            {
                switch (choiceAsEnum)
                {
                    case eOptionsByLicence.modifyState:
                        modifyVehicleState(licenceNumber);
                        break;
                    case eOptionsByLicence.inflateWheels:
                        inflateWheels(licenceNumber);
                        break;
                    case eOptionsByLicence.fuelGasVehicle:
                        fuelVehicle(currentVehicle);
                        break;
                    case eOptionsByLicence.ChargeElectircCar:
                        chargeVehicle(currentVehicle);
                        break;
                    case eOptionsByLicence.showVehicleData:
                        showVehicleData(licenceNumber);
                        break;
                }
            }
            catch (Exception ex)
            {
                m_UI.Print(ex.Message);
                m_UI.ToContinueMessage();
            }
        }


        private void fuelVehicle(ClientCard i_Client)
        {
            if (i_Client.Vehicle.Engine is Electric)
            {
                throw new ArgumentException("Error: can not fuel an electric vehicle.");
            }

            fillEnergy(i_Client);
        }

        private void chargeVehicle(ClientCard i_Client)
        {
            if (i_Client.Vehicle.Engine is Gas)
            {
                throw new ArgumentException("Error: can not charge an fueled vehicle.");
            }

            fillEnergy(i_Client);
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
                    m_UI.Print(ex.Message);
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
            bool succesFillEnergy = false;

            while (!succesFillEnergy)
            {
                try
                {
                    m_UI.getDataForFillEnergy(i_ClientCard.Vehicle.Engine, out amount, out fuelType);
                    i_ClientCard.Vehicle.FillEnergy(amount, fuelType);
                    succesFillEnergy = true;
                }
                catch (Exception ex)
                {
                    m_UI.Print(ex.Message);
                }
            }
        }

        private void showVehicleData(string i_LicenceNumber)
        {
            m_UI.Print(m_Garage.GetVehicleData(i_LicenceNumber));
            m_UI.ToContinueMessage();
        }


    }
}