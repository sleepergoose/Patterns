using System;
using System.Threading;
using Patterns.CreationalPatterns;

namespace Patterns
{
    class Program
    {
        static Action<object> Write = (data) => Console.WriteLine(data);
        static void Main(string[] args)
        {


            // Prototype.Test();
            // SingletonWithLazyLoadingTest();
            // ThreadSafeSingletonWithoutLockTest();
            // ThreadSafeSingleton()
            // SingletonTest();

            // Method tests Factory Pattern
            // FactoryTest();
        }

        static void SingletonWithLazyLoadingTest()
        {
            Write("PI = " + SingletonWithLazyLoading.PI + $"Time: {DateTime.Now.TimeOfDay.ToString()}");
            Write(DateTime.Now.TimeOfDay.ToString());
            Thread.Sleep(1000);
            SingletonWithLazyLoading singleton = SingletonWithLazyLoading.GetSingleton(name: "LazySingleton");
            Write(singleton.Name);
        }

        static void ThreadSafeSingletonWithoutLockTest()
        {
            ThreadSafeSingletonWithoutLock singleton = ThreadSafeSingletonWithoutLock.GetSingleton();
            Write(singleton.Date);
        }

        static void ThreadSafeSingleton()
        {
            (new Thread(() => {
                Computer computer = new Computer();
                computer.Launch("Windows 10");
                Write(computer.OS.Name);
            })).Start();

            Computer computer = new Computer();
            computer.Launch("Windows 7");
            Write(computer.OS.Name);

            (new Thread(() => {
                Computer computer = new Computer();
                computer.Launch("Windows 8");
                Write(computer.OS.Name);
            })).Start();
        }
        static void SingletonTest()
        {
            Singleton singleton = Singleton.GetSingleton("Singleton");
            Write("Singleton name: " + singleton.Name);
        }

        /// <summary>
        /// Method tests Factory Pattern
        /// </summary>
        static void FactoryTest()
        {
            VehicleFactory factory = new VehicleFactory();

            IVehicle[] vehicles = new IVehicle[3];

            vehicles[0] = factory.GetVehicle(VehicleType.Car);
            vehicles[1] = factory.GetVehicle(VehicleType.Ship, petName: "Brave");
            vehicles[2] = factory.GetVehicle(VehicleType.Plane, petName: "Boing 737");

            foreach (var item in vehicles)
                item.Move();

            factory.PrintStatistic();
        }
    }
}
