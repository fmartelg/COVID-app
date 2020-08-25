using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCovidApp.Models;

namespace MyCovidApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            RiskRequestModel model = new RiskRequestModel();
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Risk([FromForm] RiskRequestModel requestModel)
        {
            CalculateRiskModel model = new CalculateRiskModel();
            CalculateRiskResponseModel responseModel = await model.Calculate(requestModel);
            if (model.httpStatusCode != StatusCodes.Status200OK)
            {
                return RedirectToAction("Error");
            }
            return View(responseModel);
        }

        /*
         * This method is for debugging the Risk.cshtml page and make sure it looks good
        [HttpGet]
        public IActionResult TempRisk()
        {
            CalculateRiskResponseModel responseModel = new CalculateRiskResponseModel
            {
                numberOfPeople = 20,
                positivityRate = 13.4,
                probabilityAtLeastOne = 19.5,
                probabilityZero = 79.57
            };
            return View("Risk", responseModel);
        }
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
