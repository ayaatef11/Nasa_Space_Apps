using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Nasa_Space_Apps.Services;
using Newtonsoft.Json;
using System.Numerics;

namespace Nasa_Space_Apps.Controllers
{
    // //display the number of planets depend on distance and diameter
    public class PlanetsController(ReaderProvider reader) : Controller
    {
        public ActionResult Index()
        {
            return View(reader.GetAllPlanets());
        }
        public ActionResult SearchByName(string name)
        {
            return View(reader.SearchByName(name));
        }
        public ActionResult FilterByType(string type)
        {
            return View(reader.FilterByType(type));
        }
    }
}

