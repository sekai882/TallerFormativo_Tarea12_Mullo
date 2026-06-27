namespace DesignPatterns.Models
{
    /// <summary>
    /// Concrete creator in the Factory Method pattern. Encapsulates the instantiation
    /// logic for a red Ford Escape, decoupling client code from the specific creation
    /// process. Adding new vehicle variants only requires creating a new factory subclass,
    /// preserving the Open/Closed Principle (OCP) without altering existing code.
    /// </summary>
    public class FordEscapeFactory : VehicleFactory
    {
        public override Vehicle CreateVehicle()
        {
            return new Car("red", "Ford", "Escape");
        }
    }
}
