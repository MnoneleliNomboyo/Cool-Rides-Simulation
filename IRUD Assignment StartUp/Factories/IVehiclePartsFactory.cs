using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Factories
{
    public interface IVehiclePartsFactory
    {
        Chassis CreateChassis();
        Shell CreateShell();
        Wheel CreateWheel();
        Trim CreateTrim();
    }
}
