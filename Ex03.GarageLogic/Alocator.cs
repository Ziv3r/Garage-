using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Alocator
    {
        public  List<string> m_SupportedVehicles;
        ClientCard newClientCard;
        // how should we know which data in each string in the list ? 
        public ClientCard CreateNewClientCard(List<string> i_userData)
        {
            string userVehicleChoice = i_userData[0];
            string engineType = i_userData[1];          // need to send enum 
            string licenceNumber = i_userData[2];
            string modelName = i_userData[3];
            string ownerName = i_userData[4];
            string ownerPhone = i_userData[5]; 

            switch (userVehicleChoice)
            {
                case "car" :
                    string carColor = i_userData[6];
                    string numOfDoors = i_userData[7];

                    int carColorInt;
                    int.TryParse(carColor, out carColorInt);

                    int numOfDoorsInt;
                    int.TryParse(carColor, out numOfDoorsInt);

                    newClientCard = new ClientCard(ownerName, ownerPhone, new Car(modelName, licenceNumber, engineType,carColorInt, numOfDoorsInt));
                    break;
                case "Motor-Cycle":
                    newClientCard = new ClientCard(ownerName, ownerPhone, new MotorCycle(modelName, licenceNumber, engineType));
                    break;
                case "Track":
                    newClientCard = new ClientCard(ownerName, ownerPhone, new Track(modelName, licenceNumber, engineType));
                    break;
            }

            return newClientCard; 
        }

        public void InitSupportedVehicle()
        {
            m_SupportedVehicles = new List<string> { "Car", "Track", "MotorCycle" };
        }

        public List<string> SupportedVehicles
        {
            get { return m_SupportedVehicles; }
        }
    }
}


//              userData.Add(vehicleTypes[vehichleTypeUserChoice]);
//            userData.Add(engineTypes[energyTypeUserChoice]);
//            userData.Add(LicenceNumber);
//            userData.Add(modelName);
//            userData.Add(ownerName);
//            userData.Add(ownerPhone);