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
        private readonly ISmsServiceAsync _smsServiceAsync;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
             ISmsService smsService,
            ILogger<HomeController> logger
,
            ISmsServiceAsync smsServiceAsync)
        {
            _logger = logger;
            _smsService = smsService;
            _smsServiceAsync = smsServiceAsync;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateSmsModel createSmsModel)
        {
           

            var result = await _smsServiceAsync.SendTextMessageReturnStringAsync(createSmsModel);
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