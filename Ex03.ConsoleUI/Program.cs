using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            Ex03.GarageLogic.Car c = new Car("nos", "12", "ew", 5f);
            GarageManager GarageManager = new GarageManager();
            GarageManager.Run();
           
        }
    }
}

/*
 TODO:
 change Vehicle constructor 
 add consts to capacities of wheels and fuel
     */



//Car gasCar = new Car("ford", "123", 4, 31, 4, 1, 100, 500, 2, 3);   //gas octan 95 
//Car electircCar = new Car("Toyota-prius ", "456", 4, 31, 2, 2, 1.2f, 1.8f, 3, 4);   //eletirc

//Console.WriteLine(gasCar.ToString());
//Console.WriteLine();
//Console.WriteLine(electircCar.ToString());

//MotorCycle motorCycleEle = new MotorCycle("Rzr", "111", 2, 33, 1, 4, 1.2f, 1.8f, 1700, 2);   //eletirc
//MotorCycle motorCycleGas = new MotorCycle("Rzr", "111", 2, 33, 2, 2, 80, 150, 1500, 1);   //eletirc

//Console.WriteLine();
//Console.WriteLine(motorCycleEle.ToString());
//Console.WriteLine();
//Console.WriteLine(motorCycleGas.ToString());


// public Car(string i_modelName, string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPreasure,
//int i_VehicleType, int i_fuelType, float i_CurrentAmountEnergy, float i_TotalAmountOfEnergy,
//int i_CarColor, int i_NumDoors)
//fuelType before 

//MotorCycle gasMoto = new MotorCycle("Rzr", "777", 2, 33, 1, 4,100,200, 2, 200);
//MotorCycle electricMoto = new MotorCycle("BMW", "888",33, 2, 31, 1, 4, 1.2f, 1.8f,2, 4);
