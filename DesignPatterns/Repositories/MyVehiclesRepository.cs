using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="IVehicleRepository"/> that persists vehicles
    /// in an in-memory collection. When registered as a Singleton in the IoC container,
    /// it guarantees that the same collection instance is shared across all HTTP requests
    /// throughout the entire application lifecycle — effectively applying the Singleton
    /// creational pattern combined with the Repository structural pattern.
    /// </summary>
    public class MyVehiclesRepository : IVehicleRepository
    {
        private readonly ICollection<Vehicle> _memoryCollection;

        public MyVehiclesRepository()
        {
            _memoryCollection = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _memoryCollection.Add(vehicle);
        }

        public Vehicle Find(string id)
        {
           return  _memoryCollection.FirstOrDefault(item => item.ID.Equals(new Guid(id)));
        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _memoryCollection;
        }

        
    }
}
