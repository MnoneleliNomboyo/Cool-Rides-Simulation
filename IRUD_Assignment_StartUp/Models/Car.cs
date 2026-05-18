using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Models
{
    public class Car : Vehicle
    {
        public Car(string color)
        {
            Color = color;
            Model = "LUX1000";
        }
    }
}
