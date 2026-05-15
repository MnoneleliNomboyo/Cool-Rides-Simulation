using IRUD_Assignment_StartUp.AssemblyLines;
using IRUD_Assignment_StartUp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Services
{
    public class HQ
    {
        private CarAssemblyLine _carAssemblyLine;
        private MinibusAssemblyLine _minibusAssemblyLine;

        public HQ(CarAssemblyLine carAssemblyLine,
                  MinibusAssemblyLine minibusAssemblyLine)
        {
            _carAssemblyLine = carAssemblyLine;
            _minibusAssemblyLine = minibusAssemblyLine;
        }

        public void OrderCar(string color)
        {
            BuildCarCommand command =
                new BuildCarCommand(_carAssemblyLine, color);

            _carAssemblyLine.AddOrder(command);
        }
        public void OrderMinibus(string color)
        {
            BuildMinibusCommand command =
                new BuildMinibusCommand(_minibusAssemblyLine, color);

            _minibusAssemblyLine.AddOrder(command);
        }



    }
}
