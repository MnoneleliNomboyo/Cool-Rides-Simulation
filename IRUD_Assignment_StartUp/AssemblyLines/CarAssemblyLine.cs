using IRUD_Assignment_StartUp.Commands;
using IRUD_Assignment_StartUp.Factories;
using IRUD_Assignment_StartUp.Models;
using IRUD_Assignment_StartUp.Parts;
using IRUD_Assignment_StartUp.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.AssemblyLines
{
    public class CarAssemblyLine
    {
        public int OrderCount => _orders.Count;
        private Queue<IOrderCommand> _orders = new Queue<IOrderCommand>();
        private bool _isProcessing = false;

        public event Action<string> StatusChanged;

        public void AddOrder(IOrderCommand command)
        {
            _orders.Enqueue(command);
            StatusChanged?.Invoke($"Order received. Queue: {_orders.Count}");
            if (!_isProcessing)
                _ = ProcessOrders();
        }

        public async Task ProcessOrders()
        {
            _isProcessing = true;
            while (_orders.Count > 0)
            {
                IOrderCommand command = _orders.Dequeue();
                await Task.Run(() => command.Execute());
                StatusChanged?.Invoke($"Order completed. Queue: {_orders.Count}");
            }
            _isProcessing = false;
            StatusChanged?.Invoke("Idle");
        }

        public void BuildCar(string color)
        {
            StatusChanged?.Invoke("Starting Car Build...");

            VehicleFactory vehicleFactory = new CarFactory();
            Vehicle car = vehicleFactory.CreateVehicle(color);

            IVehiclePartsFactory partsFactory = new CarPartsFactory();

            StatusChanged?.Invoke("Creating chassis...");
            car.Chassis = partsFactory.CreateChassis();

            StatusChanged?.Invoke("Creating shell...");
            car.Shell = partsFactory.CreateShell();

            StatusChanged?.Invoke("Creating wheels...");
            car.Wheels = new Wheel[4];
            for (int i = 0; i < 4; i++)
            {
                car.Wheels[i] = partsFactory.CreateWheel();
            }

            StatusChanged?.Invoke("Creating trim...");
            car.Trim = partsFactory.CreateTrim();

            StatusChanged?.Invoke("Assembling car...");
            Thread.Sleep(2000);

            Spraybooth spraybooth = Spraybooth.GetInstance();
            spraybooth.PaintVehicle(car);

            car.DisplayInfo();
            StatusChanged?.Invoke($"Car {color} completed!");
        }
    }
}