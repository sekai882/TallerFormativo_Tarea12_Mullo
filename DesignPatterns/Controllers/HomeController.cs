using DesignPatterns.Models;
using DesignPatterns.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Controllers
{
    /// <summary>
    /// Primary controller that handles vehicle operations. Applies the Dependency
    /// Inversion Principle (DIP) by receiving the <see cref="IVehicleRepository"/>
    /// abstraction through constructor injection, keeping the controller decoupled
    /// from any specific storage implementation.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVehicleRepository _vehicleRepository;

        public HomeController(IVehicleRepository vehicleRepository,ILogger<HomeController> logger)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult Index()
        {
            // Build the view model populated with the full list of stored vehicles
            var viewModel = new HomeViewModel();
            viewModel.Vehicles = _vehicleRepository.GetVehicles();
            string errorMessage = Request.Query.ContainsKey("error") ? Request.Query["error"].ToString() : null;
            ViewBag.ErrorMessage = errorMessage;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddMustang()
        {
            // Builder pattern: assembles a Car instance step by step via a fluent API,
            // allowing each attribute to be configured through method chaining.
            var vehicleBuilder = new CarBuilder();
            var sportsCar = vehicleBuilder
                            .SetBrand("Ford")
                            .SetModel("Mustang")
                            .SetColor("red")
                            .SetYear(DateTime.Now.Year)
                            .AddExtraProperty("Horsepower", 450)
                            .Build();
            
            _vehicleRepository.AddVehicle(sportsCar);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult AddExplorer()
        {
            // Factory Method pattern: delegates object creation to a specialized
            // concrete factory subclass (FordEscapeFactory), decoupling the controller
            // from direct instantiation logic.
            VehicleFactory concreteFactory = new FordEscapeFactory();
            var suvVehicle = concreteFactory.CreateVehicle();
            
            _vehicleRepository.AddVehicle(suvVehicle);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicleInstance = _vehicleRepository.Find(id);
                vehicleInstance.StartEngine();
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
          
        }

        [HttpGet]
        public IActionResult AddGas(string id)
        {

            try
            {
                var vehicleInstance = _vehicleRepository.Find(id);
                vehicleInstance.AddGas();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicleInstance = _vehicleRepository.Find(id);
                vehicleInstance.StopEngine();
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
           
           
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
