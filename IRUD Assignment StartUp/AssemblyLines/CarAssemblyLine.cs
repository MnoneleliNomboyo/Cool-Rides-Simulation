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
    public class CarAssemblyLine
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
        public void BuildCar(string color)
        {
            Console.WriteLine("Starting Car Build...");

            VehicleFactory vehicleFactory = new CarFactory();
            Vehicle car = vehicleFactory.CreateVehicle(color);

            IVehiclePartsFactory partsFactory = new CarPartsFactory();

            Console.WriteLine("Creating chassis...");
            car.Chassis = partsFactory.CreateChassis();

            Console.WriteLine("Creating shell...");
            car.Shell = partsFactory.CreateShell();

            Console.WriteLine("Creating wheels...");
            car.Wheels = new Wheel[4];

            for (int i = 0; i < 4; i++)
            {
                car.Wheels[i] = partsFactory.CreateWheel();
            }

            Console.WriteLine("Creating trim...");
            car.Trim = partsFactory.CreateTrim();

            Console.WriteLine("Assembling car...");
            Thread.Sleep(2000);

            Spraybooth spraybooth = Spraybooth.GetInstance();
            spraybooth.PaintVehicle(car);

            car.DisplayInfo();
        }
    }
}
