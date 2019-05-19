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
            Car gasCar = new Car("ford", "123", 4, 31, 2, 1, 100, 500, 2, 3);
            Car electircCAr = new Car("Toyota-prius ", "456", 4, 31, 1, 4, 1.2f, 1.8f, 4, 4);
            
            MotorCycle gasMoto = new MotorCycle("Rzr", "777", 2, 33, 1, 4,100,200, 2, 200);
            //MotorCycle electricMoto = new MotorCycle("BMW", "888",33, 2, 31, 1, 4, 1.2f, 1.8f,2, 4);

        }
    }
}
