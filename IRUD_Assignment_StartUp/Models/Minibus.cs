using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Models
{
    public class Minibus : Vehicle
    {
        public Minibus(string color)
        {
            Color = color;
            Model = "MV500";
        }
    }
}
