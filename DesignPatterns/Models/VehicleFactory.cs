namespace DesignPatterns.Models
{
    /// <summary>
    /// Abstract creator class that defines the Factory Method creational pattern.
    /// Declares the <see cref="CreateVehicle"/> contract that every concrete factory
    /// must implement. By depending on this abstraction rather than on concrete
    /// instantiation logic, client code satisfies the Dependency Inversion
    /// Principle (DIP) and remains open for extension but closed for modification (OCP).
    /// </summary>
    public abstract class VehicleFactory
    {
        public abstract Vehicle CreateVehicle();
    }
}
