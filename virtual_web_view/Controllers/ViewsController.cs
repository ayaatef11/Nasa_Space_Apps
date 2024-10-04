using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using virtua_web_view.Models;

namespace virtua_web_view.Controllers
{
    public class ViewsController : Controller
    {
        private readonly ILogger<ViewsController> _logger;

        public ViewsController(ILogger<ViewsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           // return File("/orbit.html", "text/html");
            //return File("C:\\Users\\Aya Atef\\Source\\Repos\\Nasa_Space_Apps\\virtual_web_view\\wwwroot\\orbit.html", "text/html");
            return File("~/orbit.html", "text/html");
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
