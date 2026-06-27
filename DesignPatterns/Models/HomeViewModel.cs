using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    /// <summary>
    /// View model responsible for transporting the vehicle collection to the
    /// main user interface. Adheres to the Single Responsibility Principle (SRP)
    /// by serving exclusively as a data-transfer object between the controller
    /// and the view layer.
    /// </summary>
    public class HomeViewModel
    {
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
