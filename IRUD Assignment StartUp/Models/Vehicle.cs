using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Models
{
    public abstract class Vehicle
    {
        public string Color { get; set; }
        public string Model { get; set; }

        public Chassis Chassis { get; set; }
        public Shell Shell { get; set; }
        public Wheel[] Wheels { get; set; }
        public Trim Trim { get; set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Model} ({Color}) completed.");
        }
    }
}
