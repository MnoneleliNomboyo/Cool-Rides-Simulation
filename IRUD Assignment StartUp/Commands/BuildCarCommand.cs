using IRUD_Assignment_StartUp.AssemblyLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Commands
{
    public class BuildCarCommand
    {
        private CarAssemblyLine _assemblyLine;
        private string _color;

        public BuildCarCommand(CarAssemblyLine assemblyLine, string color)
        {
            _assemblyLine = assemblyLine;
            _color = color;
        }

        public void Execute()
        {
            _assemblyLine.BuildCar(_color);
        }
    }
}
