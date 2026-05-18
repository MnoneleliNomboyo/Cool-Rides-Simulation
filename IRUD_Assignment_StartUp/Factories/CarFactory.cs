using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRUD_Assignment_StartUp.Models;

namespace IRUD_Assignment_StartUp.Factories
{
    public class CarFactory : VehicleFactory
    {
        public override Vehicle CreateVehicle(string color)
        {
            return new Car(color);
        }
    }
}
