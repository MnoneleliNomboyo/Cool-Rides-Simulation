using IRUD_Assignment_StartUp.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Factories
{
    public class CarPartsFactory : IVehiclePartsFactory
    {
        public Chassis CreateChassis()
        {
            Thread.Sleep(2000);
            return new Chassis { Type = "Car Chassis" };
        }

        public Shell CreateShell()
        {
            Thread.Sleep(2000);
            return new Shell { Type = "Car Shell" };
        }

        public Wheel CreateWheel()
        {
            Thread.Sleep(500);
            return new Wheel { Type = "Car Wheel" };
        }

        public Trim CreateTrim()
        {
            Thread.Sleep(1000);
            return new Trim { Type = "Car Trim" };
        }

    }
}
