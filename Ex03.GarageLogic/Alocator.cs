using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Alocator
    {
        //how should we know which data in each string in the list ? 
        public void CreateNewVehicle(List<string> i_userData)
        {
            //string[] vehicleTypes = new string[3] { "car", "Motor-Cycle", "Track" };
            //List<string> vehicleTypess = new List<string> { "car", "Motor-Cycle", "Track" };

            string userVehicleChoice = i_userData[0];
            int uservehicleChoice = vehicleTypess.FindIndex(uservehicleChoice);
            //car should know also car color and num of door 

            switch (userVehicleChoice)
            {
                case "car" :
                    //break;
                    //new Car(i_userData[3] , i_userData[2] , i_userData[1] , )
                 
            }
        }
    }
}
