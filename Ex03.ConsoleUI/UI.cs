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
        private const string k_toContinue = "Please press any key to continue"; 

        public string GoodByeMessage
        {
            get { return k_goodByeMessage; }
        }
        public void ToContinueMessage()
        {
            Console.WriteLine(k_toContinue);
            Console.ReadLine();
        }
        public void VehicleAddedSuccessfully(Type i_VehicleType)
        {
            Console.WriteLine(string.Format("Vehicle from type {0} added succesfully", i_VehicleType.Name));
            ToContinueMessage();
        }

        public void PrintMenu(List<Tuple> i_ToPrint)
        {
            Console.Clear();
            Console.WriteLine("Please choose from the following options");
            foreach(Tuple element in i_ToPrint)
            {
                Console.WriteLine(element.ToString());
            }
        }

        public int GetUserChoice(int i_Range)
        {
            int choice = 0;
            while(!int.TryParse(Console.ReadLine(), out choice) || !inRange(choice, 1, i_Range))
            {
                Console.WriteLine("please provide number between 1 to {0}", i_Range);
            }

            return choice;
        }

        public void Print(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public List<string> GetVehicleCommonData()
        {
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
            
            int energyTypeUserChoice = GetUserChoice(engineTypes.Length);

            Console.WriteLine("please enter Licence Number");
            LicenceNumber = readString();

            Console.WriteLine("please enter Model Name");
            modelName = readString();

            Console.WriteLine("please enter owner name");
            ownerName = readString();

            Console.WriteLine("please enter owner phone");
            ownerPhone = readString();

            Console.WriteLine("Enter current fuel amount:");
            string fuelAmount = readString();

            Console.WriteLine("Enter wheels manufactor:");
            string wheelsManufactor = readString();

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
                        Console.WriteLine(e.Message);
                    }
                }
            }
        } //relevant data for each vehicle

        private bool inRange(int i_NumToCheck, int i_Min, int i_Max)
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

            int vehicleChoice = GetUserChoice(i_SupportedVehicles.Count);

            return Type.GetType(string.Format("Ex03.GarageLogic.{0}, Ex03.GarageLogic", i_SupportedVehicles[vehicleChoice - 1]));
        }
        public string GetState()
        {
            string state;
            Console.WriteLine("Please enter status");
            state = Console.ReadLine();
            return state;
        }

        public void GetDataForFillEnergy(EnergySource i_EnergySource, out string o_Amount, out string o_FuelType)
        {
            o_Amount = string.Empty;
            bool isGasVehicle = i_EnergySource is Gas;
            if (isGasVehicle)
            {
                Console.WriteLine("choose fuel type:");
                o_FuelType = Console.ReadLine();
            }
            else
            {
                o_FuelType = "None";
            }
            while (o_Amount.Equals(string.Empty))
            {
                Console.WriteLine("enter amount of {0} to fill", isGasVehicle ? "fuel" : "minutes");
                o_Amount = Console.ReadLine();
            }

            
            

        }
        public string GetLicenceNumber()
        {
            Console.WriteLine("please enter a licence number");
            return (Console.ReadLine());
        }

        public void PrintList(List<string> i_ListToPrint)
        {
            if (i_ListToPrint.Count == 0)
            {
                Console.WriteLine("--None--");
            }
            else
            {
                foreach (string str in i_ListToPrint)
                {
                    Console.WriteLine(str);
                }
            }
               ToContinueMessage();
        }

        private string readString()
        {
            string toReturn = string.Empty;
            while (isEmptyOrWhiteSpaces(toReturn))
            {
                toReturn = Console.ReadLine();
            }

            return toReturn;
        }

        private bool isEmptyOrWhiteSpaces(string i_ToCheck)
        {
            bool isAllWhiteSpaces = true;
            foreach(char c in i_ToCheck)
            {
                isAllWhiteSpaces = c.Equals(' ') ? isAllWhiteSpaces : false;
            }

            return isAllWhiteSpaces || i_ToCheck.Equals(string.Empty);
        }
    }
}
