using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Alocator
    {
        public static List<string> s_SupportedVehicles;
        // how should we know which data in each string in the list ? 
        static Alocator()
        {
            s_SupportedVehicles = new List<string> { "Car", "Truck", "Motorcycle" };
        }

        ////  vehicle common data provide the common data in the following order:
        //// ownerName, OwnerPhone, ModelName, LicenceNumber, EngineType, FuelAmount
        public ClientCard CreateNewClientCard(Type i_VehicleType, List<string> i_VehiclesCommonData)
        {
            Vehicle newVehicle = null;

            if (i_VehicleType.Equals(typeof(Car)))
            {
                newVehicle = new Car(
                    i_VehiclesCommonData[2],
                    i_VehiclesCommonData[3],
                    i_VehiclesCommonData[4],
                    i_VehiclesCommonData[5],
                    i_VehiclesCommonData[6],
                    i_VehiclesCommonData[7]
                    );
            }
            else if (i_VehicleType.Equals(typeof(Motorcycle)))
            {
                newVehicle = new Motorcycle(
                    i_VehiclesCommonData[2],
                    i_VehiclesCommonData[3],
                    i_VehiclesCommonData[4],
                    i_VehiclesCommonData[5],
                    i_VehiclesCommonData[6],
                    i_VehiclesCommonData[7]
                    );
            }
            else if (i_VehicleType.Equals(typeof(Truck)))
            {
                newVehicle = new Truck(
                    i_VehiclesCommonData[2],
                    i_VehiclesCommonData[3],
                    i_VehiclesCommonData[4],
                    i_VehiclesCommonData[5],
                    i_VehiclesCommonData[6],
                    i_VehiclesCommonData[7]
                    );
            }

            else
            {
                throw new ArgumentException("Error: invalid type of vehicle");
            }

            return new ClientCard(i_VehiclesCommonData[0], i_VehiclesCommonData[1], newVehicle);
        }


        public List<string> SupportedVehicles
        {
            get { return s_SupportedVehicles; }
        }
    }
}

