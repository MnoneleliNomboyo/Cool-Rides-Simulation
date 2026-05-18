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
    public class MinibusAssemblyLine
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

        public void BuildMinibus(string color)
        {
            StatusChanged?.Invoke("Starting Minibus Build...");

            VehicleFactory vehicleFactory = new MinibusFactory();
            Vehicle minibus = vehicleFactory.CreateVehicle(color);

            IVehiclePartsFactory partsFactory = new MinibusPartsFactory();

            StatusChanged?.Invoke("Creating chassis...");
            minibus.Chassis = partsFactory.CreateChassis();

            StatusChanged?.Invoke("Creating shell...");
            minibus.Shell = partsFactory.CreateShell();

            StatusChanged?.Invoke("Creating wheels...");
            minibus.Wheels = new Wheel[4];
            for (int i = 0; i < 4; i++)
            {
                minibus.Wheels[i] = partsFactory.CreateWheel();
            }

            StatusChanged?.Invoke("Creating trim...");
            minibus.Trim = partsFactory.CreateTrim();

            StatusChanged?.Invoke("Assembling minibus...");
            Thread.Sleep(3000);

            Spraybooth spraybooth = Spraybooth.GetInstance();
            spraybooth.PaintVehicle(minibus);

            minibus.DisplayInfo();
            StatusChanged?.Invoke($"Minibus {color} completed!");
        }
    }
}