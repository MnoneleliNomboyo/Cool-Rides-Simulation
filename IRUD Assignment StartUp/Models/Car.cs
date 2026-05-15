using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Models
{
    public class Car : Vehicle
    {
        public Car(String color)
        {
            Color = color;
            Model = "Nissan100";
        }
    }
}
