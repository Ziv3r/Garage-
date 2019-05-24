using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class UI
    {
        private const string k_goodByeMessage = "Good Bye...";
        private const string k_MainMenuText =
@"Please choose from the following options (1-5):
        1. Add a new vehicle to garage.
        2. Display license plate numbers for all vehicles in the garage.
        3. Display license numbers for vehicles filtered by garage status.
        4. Make an action for specific car by Licence number .
        5. Quit.
        ";
        private const string k_MenuByLicence =
@"Please choose from the following options (1-5):
        1. Modify a vehicle's status.
        2. Inflate a vehicle's wheels to maximum.
        3. Refuel a gasoline-powered vehicle.
        4. Charge an electric vehicle.
        5. Display full details of a vehicle.
";

        public string GoodByeMessage
        {
            get { return k_goodByeMessage; }
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(k_MainMenuText);
        }

        public string GetKeyFromUser()
        {
            int res;
            while (!int.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Please enter number between 1-9");
            }
            res--;
            return res.ToString();
        }

        public void Print(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public List<string> GetVehicleCommonData()
        {
            string engineType;
            string LicenceNumber;
            string modelName;
            string ownerName;
            string ownerPhone;

            List<string> userData = new List<string>();

            string[] vehicleTypes = new string[3] { "car", "Motor-Cycle", "Track" };
            string[] engineTypes = new string[2] { "Gas", "Electric" };

            Console.WriteLine(@"please choose engine type :
            1.gas 
            2.electric");
            
            int energyTypeUserChoice = 0;

            engineType = Console.ReadLine();

            while (!int.TryParse(engineType, out energyTypeUserChoice) && !inRange(energyTypeUserChoice, 1, 2))
            {
                Console.WriteLine("enter 1 or 2");
                engineType = Console.ReadLine();
            }

            Console.WriteLine("please enter Licence Number");
            LicenceNumber = Console.ReadLine();

            Console.WriteLine("please enter Model Name");
            modelName = Console.ReadLine();

            Console.WriteLine("please enter owner name");
            ownerName = Console.ReadLine();

            Console.WriteLine("please enter owner phone");
            ownerPhone = Console.ReadLine();

            Console.WriteLine("Enter current fuel amount:");
            string fuelAmount = Console.ReadLine();

            Console.WriteLine("Enter wheels manufactor:");
            string wheelsManufactor = Console.ReadLine();

            userData.Add(ownerName);
            userData.Add(ownerPhone);
            userData.Add(modelName);
            userData.Add(LicenceNumber);
            userData.Add(engineTypes[--energyTypeUserChoice]);
            userData.Add(fuelAmount);
            userData.Add(wheelsManufactor);

            return userData;
        }

        public void GetRelevantDataFromUser(Vehicle i_Vehicle)
        {
            MethodInfo currMethod;
            foreach (KeyValuePair<string, string> method in i_Vehicle.VehicleParamsSet)
            {
                bool success = false;
                Console.WriteLine(method.Key);
                while (!success)
                {
                    string input = Console.ReadLine();
                    try
                    {
                        currMethod = i_Vehicle.GetType().GetMethod(method.Value);
                        currMethod.Invoke(i_Vehicle, new object[] { input });
                        success = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }
                }
            }
        }
        public void printByLicenceCommands()
        {
            Console.Clear();
            Console.WriteLine(k_MainMenuText);
        }

        private bool inRange(int i_NumToCheck, float i_Min, float i_Max)
        {
            return i_NumToCheck >= i_Min && i_NumToCheck <= i_Max;
        }

        public Type GetVehicleTypeFromUser(List<string> i_SupportedVehicles)
        {
            int i = 1;
            Console.WriteLine("Choose Vehicle To Add:");
            foreach (string vehicle in i_SupportedVehicles)
            {
                Console.WriteLine("{0}. {1}", i++, vehicle);
            }

            string choice;
            choice = Console.ReadLine();
            int vehicleChoice = 0;
            bool success = false;

            while (!success)
            {
                try
                {
                    vehicleChoice = int.Parse(choice);
                    inRange(vehicleChoice, 1, i_SupportedVehicles.Count);
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return Type.GetType(string.Format("Ex03.GarageLogic.{0}, Ex03.GarageLogic", i_SupportedVehicles[vehicleChoice - 1]));
        }
        public string GetState()
        {
            string state;
            Console.WriteLine("Which state would you like to search for?");
            state = Console.ReadLine();
            return state;
        }

        public void getDataForFillEnergy(EnergySource i_EnergySource, out string o_Amount, out string o_FuelType)
        {

            Console.WriteLine("enter amount of energy you want to fill up");
            o_Amount = Console.ReadLine();

            if (i_EnergySource is Gas)
            {
                Console.WriteLine("choose fuel type:");
                o_FuelType = Console.ReadLine();
            }
            else
            {
                o_FuelType = "None";
            }

        }
        public string getLicenceNumber()
        {
            Console.WriteLine("please enter a licence number ?");
            return (Console.ReadLine());
        }

        public void PrintList(List<string> i_ListToPrint)
        {
            foreach (string str in i_ListToPrint)
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }
    }
}
