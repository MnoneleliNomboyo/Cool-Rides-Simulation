using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Factories
{
    public class CarFactory : VehicleFactory
    {
        public overrride Vehicle CreateVehicle(string color)
        {
            return new CarFactory(color);
        }

    }
}
