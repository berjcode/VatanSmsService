using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VatanSmsService.Nuget.Abstract;
using VatanSmsService.Nuget.Models;
using VatanSmsServiceWeb.Models;

namespace VatanSmsServiceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmsService _smsService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
             ISmsService smsService,
            ILogger<HomeController> logger
           )
        {
            _logger = logger;
            _smsService = smsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateSmsModel createSmsModel)
        {
            createSmsModel.api_url = "https://api.vatansms.net/api/v1/1toN";
            createSmsModel.api_id = "22276b28072392b4d7767b21";
            createSmsModel.api_key = "8f91c6038a85325c2bc9eb8d";
            createSmsModel.message_type = "normal";
            createSmsModel.sender = "MIS SOFT D.";

           var result =  _smsService.SendTextMessage(createSmsModel);
            return View(result);
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