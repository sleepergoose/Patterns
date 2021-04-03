using System;

namespace Patterns
{
    class Program
    {
        static Action<object> Write = (data) => Console.WriteLine(data);
        static void Main(string[] args)
        {
            FactoryTest();
        }

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
