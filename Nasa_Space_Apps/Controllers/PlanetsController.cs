using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Numerics;

namespace Nasa_Space_Apps.Controllers
{
    public class PlanetsController : Controller
    {
        public ActionResult Index()
        {
            return View(DataReader.GetPlanets());
        }
        public ActionResult SearchByName(string name)
        {
            List<Planet> planets = DataReader.GetPlanets();
            var planet = planets.FirstOrDefault(x => x.Name == name);
            return View(planet);
        }
        public ActionResult FilterByType(string type)
        {
            List<Planet> planets = DataReader.GetPlanets();
            var planet = planets.Where(x => x.Type == type);
            return View(planet);
        }
        public ActionResult FilterBySearch(string search)
        {
            List<Planet> planets = DataReader.GetPlanets();
            var planet = planets.Where(x => x.Search == search);
            return View(planet);
        }
        public ActionResult FilterByOrbit(string orbit)
        {
            List<Planet> planets = DataReader.GetPlanets();
            var planet = planets.Where(x => x.CustomOrbit == orbit);
            return View(planet);
        }
        public ActionResult SortByRadius(string orbit)
        {
            List<Planet> planets = DataReader.GetPlanets();
            planets.Sort((p1, p2) => p1.Radius.CompareTo(p2.Radius));
            //var sortedPlanets = planets.OrderBy(p => p.Radius).ToList();
            return View(planets);
        }
    }
}

