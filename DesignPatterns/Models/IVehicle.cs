using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    /// <summary>
    /// Contract that defines the essential operations every vehicle must support.
    /// Adheres to the Interface Segregation Principle (ISP) by exposing only the
    /// minimal set of methods required by all vehicle implementations, ensuring
    /// that consumers depend solely on the behavior they actually use.
    /// </summary>
    public interface IVehicle
    {
        void StartEngine();

        void StopEngine();

        void AddGas();

        bool NeedsGas();

        bool IsEngineOn();
    }
}
