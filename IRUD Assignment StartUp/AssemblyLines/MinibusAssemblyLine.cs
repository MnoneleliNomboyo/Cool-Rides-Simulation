using IRUD_Assignment_StartUp.Commands;
using IRUD_Assignment_StartUp.Factories;
using IRUD_Assignment_StartUp.Models;
using IRUD_Assignment_StartUp.Parts;
using IRUD_Assignment_StartUp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.AssemblyLines
{
    public class MinibusAssemblyLine
    {
        private Queue<IOrderCommand> _orders = new Queue<IOrderCommand>();

        public void AddOrder(IOrderCommand command)
        {
            _orders.Enqueue(command);
        }

        public void ProcessOrders()
        {
            while (_orders.Count > 0)
            {
                IOrderCommand command = _orders.Dequeue();
                command.Execute();
            }
        }
        public void BuildMinibus(string color)
        {
            Console.WriteLine("Starting Minibus Build...");

            VehicleFactory vehicleFactory = new MinibusFactory();
            Vehicle minibus = vehicleFactory.CreateVehicle(color);

            IVehiclePartsFactory partsFactory = new MinibusPartsFactory();

            Console.WriteLine("Creating chassis...");
            minibus.Chassis = partsFactory.CreateChassis();

            Console.WriteLine("Creating shell...");
            minibus.Shell = partsFactory.CreateShell();

            Console.WriteLine("Creating wheels...");
            minibus.Wheels = new Wheel[4];

            for (int i = 0; i < 4; i++)
            {
                minibus.Wheels[i] = partsFactory.CreateWheel();
            }

            Console.WriteLine("Creating trim...");
            minibus.Trim = partsFactory.CreateTrim();

            Console.WriteLine("Assembling minibus...");
            Thread.Sleep(3000);

            Spraybooth spraybooth = Spraybooth.GetInstance();
            spraybooth.PaintVehicle(minibus);

            minibus.DisplayInfo();
        }
    }
}
