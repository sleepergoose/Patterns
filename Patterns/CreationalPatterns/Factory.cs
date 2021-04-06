using System;

namespace Patterns.CreationalPatterns
{
    /// <summary>
    /// Common interface for all vehicles
    /// </summary>
    public interface IVehicle
    {
        string PetName { get; set; }
        string Manufacturer { get; set; }
        void Move();
    }

    /// <summary>
    /// Several types of different vehicles which implement IVehicle
    /// </summary>
    public class Car : IVehicle
    {
        public string PetName { get; set; }
        public string Manufacturer { get; set; }

        public void Move() => 
            Console.WriteLine($"Car {PetName} is moving");
    }

    public class Ship : IVehicle
    {
        public string PetName { get; set; }
        public string Manufacturer { get; set; }

        public void Move() =>
            Console.WriteLine($"Ship {PetName} is sailing");
    }

    public class Plane : IVehicle
    {
        public string PetName { get; set; }
        public string Manufacturer { get; set; }

        public void Move() =>
            Console.WriteLine($"Plane {PetName} is flying");
    }

    /// <summary>
    /// Vehicle Factory will be creating of different types of vehicles
    /// </summary>
    public class VehicleFactory
    {
        private int CarCounter = 0;
        private int ShipCounter = 0;
        private int PlaneCounter = 0;

        public IVehicle GetVehicle(VehicleType vehicleType, string petName = null, string manufacturer = null)
        {
            switch (vehicleType)
            {
                case VehicleType.Car:
                    CarCounter++;
                    return new Car() { PetName = petName == null ? "Beauty" : petName, Manufacturer = manufacturer == null ? "BMW" : manufacturer };
                case VehicleType.Plane:
                    PlaneCounter++;
                    return new Plane() { PetName = petName == null ? "Jet" : petName, Manufacturer = manufacturer == null ? "Boing" : manufacturer };
                case VehicleType.Ship:
                    ShipCounter++;
                    return new Ship() { PetName = petName == null ? "Titanic" : petName, Manufacturer = manufacturer == null ? "Cat" : manufacturer };
                default:
                    throw new ApplicationException("There is no such a vehicle type");
            }
        }

        public void PrintStatistic()
        {
            Console.WriteLine($"Cars: {CarCounter}; Planes: {PlaneCounter}; Ship {ShipCounter}");
        }
    }

    /// <summary>
    /// Enum of vehicle types
    /// </summary>
    public enum VehicleType
    {
        Car,
        Plane,
        Ship
    }
}

