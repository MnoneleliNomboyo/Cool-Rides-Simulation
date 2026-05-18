using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRUD_Assignment_StartUp.AssemblyLines;

namespace IRUD_Assignment_StartUp.Commands
{
    public class BuildCarCommand : IOrderCommand
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