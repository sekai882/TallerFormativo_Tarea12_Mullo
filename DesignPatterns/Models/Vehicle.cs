using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    /// <summary>
    /// Abstract base class that centralizes shared behavior for all vehicle types.
    /// Implements the <see cref="IVehicle"/> interface, respecting the Interface
    /// Segregation Principle (ISP) and providing a Template Method–style skeleton
    /// for engine lifecycle operations. Subclasses override only the properties
    /// that differentiate them (e.g., tire count), honoring the Open/Closed
    /// Principle (OCP).
    /// </summary>
    public abstract class Vehicle : IVehicle
    {
        #region Internal State

        private bool _isEngineOn { get; set; }

        #endregion

        #region Vehicle Attributes

        public readonly Guid ID;
        public virtual int Tires { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Gas { get; set; }
        public double FuelLimit { get; set; }
        
        /// <summary>
        /// Manufacturing year and a flexible dictionary of extra properties added
        /// via the Builder pattern, supporting up to 20 additional attributes
        /// without modifying the core class structure (OCP compliance).
        /// </summary>
        public int Year { get; set; }
        public Dictionary<string, object> ExtraProperties { get; set; } = new Dictionary<string, object>();

        #endregion

        #region Initialization

        public Vehicle(string color, string brand, string model, double fuelLimit = 10)
        {
            Color = color;
            ID = Guid.NewGuid();
            Brand = brand;
            FuelLimit = fuelLimit;
            Model = model;
        }

        #endregion

        #region Vehicle Operations

        /// <summary>
        /// Increments the fuel level by a fixed unit. Throws if the tank is already full.
        /// </summary>
        public void AddGas()
        {
            if(Gas <= FuelLimit)
            {
                Gas += 0.1;
            }
            else
            {
                throw new Exception("Gas tank is full — cannot add more fuel");
            }
        }

        /// <summary>
        /// Starts the engine if it is not already running and there is sufficient fuel.
        /// Validates preconditions and throws descriptive exceptions on failure.
        /// </summary>
        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("The engine is already running");
            }
            if (NeedsGas())
            {
                throw new Exception("Insufficient fuel — please refuel at a station");
            }
            _isEngineOn = true;
        }

        /// <summary>
        /// Determines whether the vehicle requires fuel before the engine can start.
        /// </summary>
        public bool NeedsGas()
        {
            return !(Gas > 0);
        }

        /// <summary>
        /// Returns the current state of the engine.
        /// </summary>
        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        /// <summary>
        /// Stops the engine. Throws if the engine is already off.
        /// </summary>
        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("The engine is already stopped");
            }

            _isEngineOn = false;
        }

        #endregion

    }
}
