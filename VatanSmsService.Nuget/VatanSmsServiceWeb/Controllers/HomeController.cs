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
            

            var result =  _smsService.SendTextMessageReturnString(createSmsModel);
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