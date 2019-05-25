using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using System.Reflection;
namespace Ex03.ConsoleUI
{
    class GarageManager
    {
        public static readonly List<Tuple> sr_MainMenuMethods;
        public static readonly List<Tuple> sr_ByLicenceMethodes;

        UI m_UI = new UI();
        Garage m_Garage = new Garage();
        Alocator m_Alocator = new Alocator();
        private bool m_ToExitProgram = false;
        static GarageManager()
        {
            sr_MainMenuMethods = new List<Tuple>();
            sr_ByLicenceMethodes = new List<Tuple>();
            initByLicenceList();
            initMainMenuMethodSet();
        }

        static private void initMainMenuMethodSet()
        {
            sr_MainMenuMethods.Add(new Tuple(1, "Add a new vehicle to garage", "addNewVehicle"));
            sr_MainMenuMethods.Add(new Tuple(2, "Display license plate numbers for all vehicles in the garage.", "showAllLicenceNumbers"));
            sr_MainMenuMethods.Add(new Tuple(3, "Display license numbers for vehicles filtered by garage status.", "showLicenceNumByState"));
            sr_MainMenuMethods.Add(new Tuple(4, "Make an action for specific car by Licence number", "CommandByLicenceNumber"));
            sr_MainMenuMethods.Add(new Tuple(5, "Quit.", "exitProgram"));
        }
        static private void initByLicenceList()
        {
            sr_ByLicenceMethodes.Add(new Tuple(1, "Modify a vehicle's status", "modifyVehicleState"));
            sr_ByLicenceMethodes.Add(new Tuple(2, "Inflate a vehicle's wheels to maximum.", "inflateWheels"));
            sr_ByLicenceMethodes.Add(new Tuple(3, "Refuel a gasoline-powered vehicle.", "fuelVehicle"));
            sr_ByLicenceMethodes.Add(new Tuple(4, "Charge an electric vehicle.", "chargeElectircCar"));
            sr_ByLicenceMethodes.Add(new Tuple(5, "Display full details of a vehicle.", "showVehicleData"));
        }
        public void Run()
        {
            while (!m_ToExitProgram)
            {
                m_UI.PrintMenu(sr_MainMenuMethods);
                int serialNumOfMethod = m_UI.GetUserChoice(sr_MainMenuMethods.Count);
                foreach(Tuple method in sr_MainMenuMethods)
                {
                    if(serialNumOfMethod == method.SerialNumber)
                    {
                        try
                        {
                            execute(method.Method);
                        }
                        catch(Exception ex)
                        {
                            m_UI.Print(ex.Message);
                        }
                        break;
                    }
                }
            }
        }

        private void exitProgram()
        {
            m_ToExitProgram = true;
        }
        private void execute(string i_MethodStr, ClientCard i_InputForMethod = null)
        {
            MethodInfo methodToExecute = this.GetType().GetMethod(i_MethodStr, BindingFlags.Instance | BindingFlags.NonPublic);
            if(i_InputForMethod != null)
            {
             methodToExecute.Invoke(this, new object[] {i_InputForMethod });
            }
            else
            {
                methodToExecute.Invoke(this, new object[] {});
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
            ClientCard currentVehicle = getVehicleFromUser();

            m_UI.PrintMenu(sr_ByLicenceMethodes);
            int serialNumOfMethod = m_UI.GetUserChoice(sr_ByLicenceMethodes.Count);
            foreach(Tuple method in sr_ByLicenceMethodes)
            {
                if(serialNumOfMethod == method.SerialNumber)
                {
                    execute(method.Method, currentVehicle);
                    break;
                }
            }
        }

        private ClientCard getVehicleFromUser()
        {
            bool success = false;
            string licenceNumber = string.Empty;
            ClientCard currentVehicle = null;
            while (!success)
            {
                try
                {
                    licenceNumber = m_UI.GetLicenceNumber();
                    currentVehicle = m_Garage.FindByLicenceNum(licenceNumber);
                    success = true;
                }
                catch (Exception ex)
                {
                    m_UI.Print(ex.Message);
                }
            }

            return currentVehicle;
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
        private void modifyVehicleState(ClientCard i_Client)
        {
            bool successChangeState = false;
            while (!successChangeState)
            {
                try
                {
                    string newState = m_UI.GetState();
                    m_Garage.ChangeVehicleState(i_Client.Vehicle.LicenceNumber, newState);
                    successChangeState = true;
                }
                catch (Exception ex)
                {
                    m_UI.Print(ex.Message);
                }
            }
        }
        private void inflateWheels(ClientCard i_Client)
        {
            m_Garage.inflateWheels(i_Client.Vehicle.LicenceNumber);
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
                    m_UI.GetDataForFillEnergy(i_ClientCard.Vehicle.Engine, out amount, out fuelType);
                    i_ClientCard.Vehicle.FillEnergy(amount, fuelType);
                    succesFillEnergy = true;
                }
                catch (Exception ex)
                {
                    m_UI.Print(ex.Message);
                }
            }
        }

        private void showVehicleData(ClientCard i_Client)
        {
            m_UI.Print(m_Garage.GetVehicleData(i_Client.Vehicle.LicenceNumber));
            m_UI.ToContinueMessage();
        }
    }
}