using System;
using System.Collections.Generic;

namespace DesignPatterns.Models
{
    /// <summary>
    /// Implementation of the Builder creational pattern for <see cref="Car"/> instances.
    /// Provides a fluent API that allows step-by-step construction of a vehicle by
    /// chaining setter calls for each attribute. This approach decouples the assembly
    /// logic from the domain model, enabling the addition of new attributes (up to 20
    /// extra properties) without modifying the target class — in full compliance with
    /// the Open/Closed Principle (OCP).
    /// </summary>
    public class CarBuilder
    {
        private string _color = "Black";
        private string _brand = "Generic";
        private string _model = "Base";
        private int _year = DateTime.Now.Year;
        private Dictionary<string, object> _extraProperties = new Dictionary<string, object>();

        public CarBuilder SetColor(string color)
        {
            _color = color;
            return this;
        }

        public CarBuilder SetBrand(string brand)
        {
            _brand = brand;
            return this;
        }

        public CarBuilder SetModel(string model)
        {
            _model = model;
            return this;
        }

        public CarBuilder SetYear(int year)
        {
            _year = year;
            return this;
        }

        public CarBuilder AddExtraProperty(string key, object value)
        {
            _extraProperties[key] = value;
            return this;
        }

        /// <summary>
        /// Assembles the final <see cref="Car"/> instance with all previously configured
        /// values, producing an immutable snapshot of the builder's accumulated state.
        /// </summary>
        public Car Build()
        {
            var vehicleInstance = new Car(_color, _brand, _model)
            {
                ExtraProperties = _extraProperties,
                Year = _year
            };
            return vehicleInstance;
        }
    }
}
