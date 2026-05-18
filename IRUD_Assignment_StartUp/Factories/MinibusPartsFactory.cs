using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRUD_Assignment_StartUp.Parts;
using System.Threading;

namespace IRUD_Assignment_StartUp.Factories
{
    public class MinibusPartsFactory : IVehiclePartsFactory
    {
        public Chassis CreateChassis()
        {
            Thread.Sleep(2000);
            return new Chassis { Type = "Minibus Chassis" };
        }

        public Shell CreateShell()
        {
            Thread.Sleep(3000);
            return new Shell { Type = "Minibus Shell" };
        }

        public Wheel CreateWheel()
        {
            Thread.Sleep(500);
            return new Wheel { Type = "Minibus Wheel" };
        }

        public Trim CreateTrim()
        {
            Thread.Sleep(2000);
            return new Trim { Type = "Minibus Trim" };
        }
    }
}
