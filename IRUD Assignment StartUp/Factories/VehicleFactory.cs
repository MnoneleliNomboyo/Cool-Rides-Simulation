using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Factories
{
    public abstract class VehicleFactory
    {
        public abstract VehicleFactory CreateVehicle(string color);
    }
}
