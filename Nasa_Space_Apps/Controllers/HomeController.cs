using Microsoft.AspNetCore.Mvc;
using Nasa_Space_Apps.Models;
using System.Diagnostics;

namespace Nasa_Space_Apps.Controllers
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
            var requestUrl = "https://localhost:7166/#load=&lookat=SSB&interval=3&eclipticgrid=false&";
            return Redirect(requestUrl);
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
       
       
        /*@model List<Planet>

    

<div class="card shadow border-0 mt-4">
	<div class="card-header bg-secondary bg-gradient ml-0 py-3">
		<div class="row">
			<div class="col-12 text-center">
				<h1 class="text-white">Planets</h1>
			</div>
		</div>
	</div>
	<div class="card-body p-4">
		<div class="row pb-3">
			<div class="col-6">
			</div>
			@* <div class="col-6 text-end">
				<a asp-action="CouponCreate" class="btn btn-outline-primary"><i class="bi bi-plus-square"></i> Create New Coupon</a>

			</div> *@
		</div>
		<table class="table">
			<thead>
				<tr>
					<th>
						Name
					</th>
					<th>
						Search
					</th>
					<th>
						Type
					</th>
					<th>
						Custom orppit
					</th>
					<th>
						Texture
					</th>
					<th>
						Radius
					</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				@foreach (var item in Model)
				{
					<tr>
						<td>
							@item.Name
						</td>
						<td>
							@item.Search
						</td>
						<td>
							@item.Type
						</td>
						<td>
							@item.CustomOrbit
</td>
						<td>
							@item.Texture
						</td>
						<td>
							@item.Radius
						</td>
					</tr>
				}
			</tbody>
		</table>

	</div>

</div>*/
    
	}
}
