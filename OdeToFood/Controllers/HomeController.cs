using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRestorantData _restotantData;
        private readonly IGreeter _greeter;

        public HomeController(IRestorantData restotantData,
                                IGreeter greeter)
        {
            _restotantData = restotantData;
            _greeter = greeter;

        }


        public IActionResult Index()
        {
            //ViewResult
            //the name what is inside the action //
            //this.ControllerContext.ActionDescriptor.ActionName
            //this.ControllerContext.ActionDescriptor.ControllerName


            //another example es return a bag request
            //return this.BadRequest();

            //Send a file
            //return this.File(Encoding.UTF8.GetBytes("Lalalala"), "plaint/text");

            //this.HttpContext.Request
            // return Content("Hello from Home Controller!");


            //Here we create a model to response the client
            var model = new HomeIndexViewModel();
            model.Restaurants = _restotantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();
            //return new ObjectResult(model);

            //This indicate rebder the default view and past the model
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restotantData.Get(id);
            if (model == null)
            {
                //return NotFound();
                //We can reach an action whre is in another controller

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public Restaurant GetRestorante()
        {
            return new Restaurant()
            {
                Id = 1,
                Name = "Leo"
            };
        }

        public IActionResult BadRequestResponse()
        {
            return Content("No le vaaaa");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var resto = new Restaurant()
            {
                Name = model.Name,
                Couisine = model.Couisine
            };
            
            resto = _restotantData.Add(resto);
            return RedirectToAction(nameof(Details), new { id = resto.Id});
            
            //return View("Details",resto);
            //This way return a new view in every Http request
        }

    }
}
