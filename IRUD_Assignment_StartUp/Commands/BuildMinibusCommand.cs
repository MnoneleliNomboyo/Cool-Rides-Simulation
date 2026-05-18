using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRUD_Assignment_StartUp.AssemblyLines;

namespace IRUD_Assignment_StartUp.Commands
{
    public class BuildMinibusCommand : IOrderCommand
    {
        private MinibusAssemblyLine _assemblyLine;
        private string _color;

        public BuildMinibusCommand(MinibusAssemblyLine assemblyLine, string color)
        {
            _assemblyLine = assemblyLine;
            _color = color;
        }

        public void Execute()
        {
            _assemblyLine.BuildMinibus(_color);
        }
    }
}