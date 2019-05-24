﻿using System;
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
                    case eMenuChoice.chargeElecVehicle:
                        //
                        break;
                    case eMenuChoice.fuelGasVehicle:
                        //do something
                        break;
                    case eMenuChoice.inflateWheels:
                        //
                        break;
                    case eMenuChoice.showLicenceNumByState:
                        //do something
                        break;
                    case eMenuChoice.showLicenceNumOfAll:
                        m_Garage.GetAllPlates();///to box eith printing
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
            bool success = false;

            List<string> supportedVehicles = m_Alocator.SupportedVehicles;
            Type vehichleType = m_UI.GetVehicleTypeFromUser(supportedVehicles);
            while(!success)
            {
                try
                {
                    List<string> vehiclesCommonData = m_UI.GetVehicleCommonData();  
                    ClientCard NewClientCard = m_Alocator.CreateNewClientCard(vehichleType, vehiclesCommonData);
                    m_UI.GetRelevantDataFromUser(NewClientCard.Vehicle);
                    m_Garage.Add(NewClientCard);
                    success = true;
                }
                catch (Exception ex)
                {
                   m_UI.Print(ex.Message);
                }
            }
        }
    }
}
