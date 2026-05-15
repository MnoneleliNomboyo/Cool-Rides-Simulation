using IRUD_Assignment_StartUp.AssemblyLines;
using IRUD_Assignment_StartUp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRUD_Assignment_StartUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                CarAssemblyLine carLine = new CarAssemblyLine();
                MinibusAssemblyLine minibusLine = new MinibusAssemblyLine();

                HQ hq = new HQ(carLine, minibusLine);

                hq.OrderCar("Black");
                hq.OrderCar("White");

                hq.OrderMinibus("White");
                hq.OrderMinibus("Black");

                Task task1 = Task.Run(() =>
                {
                    carLine.ProcessOrders();
                });

                Task task2 = Task.Run(() =>
                {
                    minibusLine.ProcessOrders();
                });

                Task.WaitAll(task1, task2);

                Console.WriteLine("All orders completed.");
            }
        
    }
}
