using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    /// <summary>
    /// Concrete specialization of <see cref="Vehicle"/> representing a motorcycle.
    /// Overrides <see cref="Vehicle.Tires"/> to 2 and sets a reduced fuel capacity
    /// of 5 units compared to the default value. This demonstrates the Liskov
    /// Substitution Principle (LSP) — a Motocycle can seamlessly replace any
    /// Vehicle reference without breaking client expectations.
    /// </summary>
    public class Motocycle : Vehicle
    {
        public override int Tires { get => 2; }

        public Motocycle(string color, string brand, string model) : base(color,brand,model, 5)
        {

        }
    }
}
