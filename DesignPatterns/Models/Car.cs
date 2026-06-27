using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    /// <summary>
    /// Concrete specialization of <see cref="Vehicle"/> representing a four-wheeled automobile.
    /// Inherits all shared behavior from the abstract base class and overrides only the
    /// <see cref="Tires"/> property, adhering to the Liskov Substitution Principle (LSP)
    /// and the Open/Closed Principle (OCP).
    /// </summary>
    public class Car : Vehicle
    {
        public override int Tires { get => 4; }

        public Car(string color, string brand, string model) : base(color, brand, model)
        {

        }
    }
}
