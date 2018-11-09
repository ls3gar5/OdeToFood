using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {

        private IRestorantData _restotantData;

        public HomeController(IRestorantData restotantData)
        {
            _restotantData = restotantData;
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
            var model = _restotantData.GetAll();

            //return new ObjectResult(model);

            //This indicate rebder the default view and past the model
            return View(model);
        }

        public IActionResult Name()
        {
            return Content("Hello from Name");
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
    }
}
