using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    /// <summary>
    /// Repository abstraction for vehicle data access, following the Dependency
    /// Inversion Principle (DIP). High-level modules (controllers, services) depend
    /// on this interface rather than on concrete storage implementations, allowing
    /// seamless swapping between in-memory, database, or external-API backends
    /// without modifying consumer code.
    /// </summary>
    public interface IVehicleRepository
    {
        ICollection<Vehicle> GetVehicles();

        void AddVehicle(Vehicle vehicle);

        Vehicle Find(string id);

    }
}
