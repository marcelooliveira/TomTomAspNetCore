using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TomTomWeb.Models;

namespace TomTomWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string MyTomTomKey = "9TMyfYUw9qr63VLXIhLeAGdjhNBjLQu3";
        private const string DroughtInfoURL = "https://www1.ncdc.noaa.gov/pub/data/nidis/geojson/us/usdm/USDM_current.geojson";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["MyTomTomKey"] = MyTomTomKey;
            return View();
        }

        public IActionResult HeatMap()
        {
            ViewData["MyTomTomKey"] = MyTomTomKey;
            ViewData["DroughtInfoURL"] = DroughtInfoURL;
            return View();
        }

        public async Task<IActionResult> PolygonAsync()
        {
            ViewData["MyTomTomKey"] = MyTomTomKey;

            var file = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot", "json", "famous-places.json");

            string json = await System.IO.File.ReadAllTextAsync(file);

            return View("Polygon", json);
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
