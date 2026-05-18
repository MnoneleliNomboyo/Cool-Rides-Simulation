using System.Linq;
using System.Text;
using IRUD_Assignment_StartUp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp.Services
{
    public class Spraybooth
    {
        private static Spraybooth _instance;
        private static readonly object _lock = new object();
        private Queue<Vehicle> _paintQueue = new Queue<Vehicle>();
        private bool _isPainting = false;

        public event Action<string> StatusChanged;

        private Spraybooth() { }

        public static Spraybooth GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Spraybooth();
                }
            }
            return _instance;
        }

        public void PaintVehicle(Vehicle vehicle)
        {
            lock (_paintQueue)
            {
                _paintQueue.Enqueue(vehicle);
                StatusChanged?.Invoke($"Queued: {vehicle.Color} {vehicle.Model}");
                if (!_isPainting)
                    ProcessQueue();
            }
        }

        private async void ProcessQueue()
        {
            _isPainting = true;
            while (true)
            {
                Vehicle vehicle = null;
                lock (_paintQueue)
                {
                    if (_paintQueue.Count > 0)
                        vehicle = _paintQueue.Dequeue();
                    else
                        break;
                }
                if (vehicle == null) break;

                StatusChanged?.Invoke($"Painting {vehicle.Color} {vehicle.Model}...");
                int paintTime = (vehicle is Car) ? 5000 : 7000;
                await Task.Delay(paintTime);
                StatusChanged?.Invoke($"Finished painting {vehicle.Color} {vehicle.Model}");
            }
            _isPainting = false;
            StatusChanged?.Invoke("Idle");
        }
    }
}
