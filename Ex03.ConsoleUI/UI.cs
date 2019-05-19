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
        bool k_ToExitProgram = false;
       
        public string GoodByeMessage
        {
            get { return k_goodByeMessage; }
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(k_MainMenuText);
        }

        public int GetKeyFromUser()
        {
            int res;
            while(!int.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Please enter number between 1-9");
            }

            return res;
        }


    }
}
