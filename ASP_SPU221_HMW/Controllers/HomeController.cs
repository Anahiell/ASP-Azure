using ASP_SPU221_HMW.Models;
using ASP_SPU221_HMW.Models.UserM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_SPU221_HMW.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult UserPage(UserPageFormModel? formUserPage)
        {
            UserPage_PageModel model = new()
            {
                PageTitle = "User Page",
                Model = formUserPage
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
