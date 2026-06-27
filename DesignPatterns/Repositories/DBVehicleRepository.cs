using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    /// <summary>
    /// Alternative repository implementation intended for database-backed persistence.
    /// Currently unimplemented; it will be activated once a storage engine is integrated.
    /// Satisfies the Open/Closed Principle (OCP) by allowing new storage strategies
    /// to be introduced without modifying the existing in-memory implementation.
    /// </summary>
    public class DBVehicleRepository : IVehicleRepository
    {
        public void AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle Find(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Vehicle> GetVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
