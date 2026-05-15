using IRUD_Assignment_StartUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Services
{
    public class Spraybooth
    {
        private static Spraybooth _instance;

        private Spraybooth()
        {
        }

        public static Spraybooth GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Spraybooth();
            }

            return _instance;
        }
        public void PaintVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"Painting {vehicle.Model} in {vehicle.Color}...");

            if (vehicle is Car)
            {
                Thread.Sleep(5000);
            }
            else
            {
                Thread.Sleep(7000);
            }

            Console.WriteLine($"{vehicle.Model} painted successfully.");
        }

    }
}
