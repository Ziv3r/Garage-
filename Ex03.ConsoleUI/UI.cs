using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace Ex03.ConsoleUI
{
    class UI
    {
        private const string k_goodByeMessage = "Good Bye...";
        private const string k_MainMenuText =
@"Please choose from the following options (1-9):
        1. Add a new vehicle to garage.
        2. Display license plate numbers for all vehicles in the garage.
        3. Display license numbers for vehicles filtered by garage status.
        4. Modify a vehicle's status.
        5. Inflate a vehicle's wheels to maximum.
        6. Refuel a gasoline-powered vehicle.
        7. Charge an electric vehicle.
        8. Display full details of a vehicle.
        9. Quit.
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

        public List<string> GetVehicleCommonData()
        {
            string engineType;
            string LicenceNumber;
            string modelName;
            string ownerName;
            string ownerPhone;

            List<string> userData = new List<string>() ;

            string[] vehicleTypes = new string [3]{ "car", "Motor-Cycle", "Track" };
            string[] engineTypes = new string[2] { "gas", "electric" };
           

            Console.WriteLine(@"please choose engine type :
            1.gas 
            2.electric");

            engineType = Console.ReadLine();//  parse to eEnergySourceType
            int energyTypeUserChoice;

            while (!int.TryParse(engineType, out energyTypeUserChoice) || !inRange(energyTypeUserChoice, 1,2))
            {
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
            userData.Add(ownerName);
            userData.Add(ownerPhone);
            userData.Add(modelName);
            userData.Add(LicenceNumber);
            userData.Add(engineTypes[--energyTypeUserChoice]);
            userData.Add(fuelAmount);

            return userData;

            //switch (vehichleTypeUserChoice)
            //{
            //    //separte each case to function !!!!!
            //    case 1:
            //        //getCarSpecificData();
            //        string chooseColorOptionAsString;
            //        int colorOption;

            //        string NumberOfDoorsAsString;
            //        int choosenNumberOfDoors;

            //        string chooseColor = string.Format(@"enter color to the car :
            //        1.red
            //        2.blue
            //        3.black
            //        4.grey");

            //        string chooseNumberOfDoors = string.Format(@"enter number of doors to the car :");
            //        //1.two
            //        //2.three
            //        //3.four
            //        //4.five");

            //        Console.WriteLine(chooseColor);

            //        chooseColorOptionAsString = Console.ReadLine();
            //        while (!int.TryParse(engineType, out colorOption) || !inRange(colorOption, 1, 4))
            //        {
            //            chooseColorOptionAsString = Console.ReadLine();
            //        }

            //        Console.WriteLine(chooseNumberOfDoors);

            //        NumberOfDoorsAsString = Console.ReadLine();
            //        while (!int.TryParse(engineType, out choosenNumberOfDoors))// || !inRange(choosenNumberOfDoors, 1, 4))
            //        {
            //            NumberOfDoorsAsString = Console.ReadLine();
            //        }

            //        userData.Add(chooseColorOptionAsString);//color
            //        userData.Add(NumberOfDoorsAsString);  //numOfDoors

            //        break;
            //    case 2:
            //        //getMotorCycleSpecificData();
            //        break;
            //    case 3:
            //        //getTrackSpecificData();
            //        break; 
            //}


        }

        public void GetRelevantDataFromUser(Ex03.GarageLogic.Vehicle i_Vehicle)
        {
            MethodInfo currMethod;
            foreach(KeyValuePair<string, string> method in i_Vehicle.VehicleParamsSet)
            {
                bool success = false;
                Console.WriteLine(method.Key);
                while(!success)
                {
                    string input = Console.ReadLine();
                    try
                    {
                        currMethod = i_Vehicle.GetType().GetMethod(method.Value);
                        currMethod.Invoke(i_Vehicle, new object[] { input});
                        success = true;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }
                }
            }
        }
        private bool inRange(int i_NumToCheck , int min , int max)
        {
            return i_NumToCheck >= min && i_NumToCheck <= max;
        }

        //  last commit:
        public Type GetVehicleTypeFromUser(List<string> i_SupportedVehicles)
        {
            int i = 1;
            Console.WriteLine("Choose Vehicle To Add:");
            foreach(string vehicle in i_SupportedVehicles)
            {
                Console.WriteLine("{0}. {1}", i++, vehicle);
            }

            string choice;
            choice = Console.ReadLine();
            int vehicleChoice;

            while (!int.TryParse(choice, out vehicleChoice) || !inRange(vehicleChoice, 1, i_SupportedVehicles.Count))
            {
                choice = Console.ReadLine();
            }
            return Type.GetType(string.Format("Ex03.GarageLogic.{0}, Ex03.GarageLogic", i_SupportedVehicles[vehicleChoice - 1])); //to check the exception that thrown if faile
        }

    }
}
