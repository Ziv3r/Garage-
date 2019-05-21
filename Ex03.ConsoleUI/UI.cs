using System;
using System.Collections.Generic;
using System.Text;

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

            return res.ToString();
        }

        public List<string> GetDataFromUser()
        {
            string vehicleType;
            string engineType;
            string LicenceNumber;
            string modelName;
            string ownerName;
            string ownerPhone;

            List<string> userData = new List<string>() ;

            string[] vehicleTypes = new string [3]{ "car", "Motor-Cycle", "Track" };
            string[] engineTypes = new string[2] { "gas", "electric" };
           
          int vehichleTypeUserChoice;
          int energyTypeUserChoice;


            Console.WriteLine(@"please choose vehicle type : 
            1. Car 
            2.Motor-Cycle
            3.Track ");

            vehicleType = Console.ReadLine();

            while(!int.TryParse(vehicleType,out vehichleTypeUserChoice) || !inRange(vehichleTypeUserChoice, 1,3))
            {
                vehicleType = Console.ReadLine();
            }

            Console.WriteLine(@"please choose engine type :
            1.gas 
            2.electric");

            engineType = Console.ReadLine();

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

            userData.Add(vehicleTypes[vehichleTypeUserChoice]);
            userData.Add(engineTypes[energyTypeUserChoice]);
            userData.Add(LicenceNumber);
            userData.Add(modelName);
            userData.Add(ownerName);
            userData.Add(ownerPhone);

            switch (vehichleTypeUserChoice)
            {
                //separte each case to function !!!!!!!
                case 1:
                    //getCarSpecificData();
                    string chooseColorOption;
                    int colorOption;
                    string chooseColor = string.Format(@"enter color to the car :
                    1.red
                    2.blue
                    3.black
                    4.grey");
                    Console.WriteLine(chooseColor);

                    chooseColorOption = Console.ReadLine();
                    while (!int.TryParse(engineType, out colorOption) || !inRange(colorOption, 1, 4))
                    {
                        chooseColorOption= Console.ReadLine();
                    }


                    break;
                case 2:
                    //getMotorCycleSpecificData();
                    break;
                case 3:
                    //getTrackSpecificData();
                    break; 
            }


        }

        private bool inRange(int i_NumToCheck , int min , int max)
        {
            return i_NumToCheck >= min && i_NumToCheck <= max;
        }
        
    }
}
