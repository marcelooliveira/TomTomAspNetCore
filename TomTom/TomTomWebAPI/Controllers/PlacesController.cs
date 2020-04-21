using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TomTomLib;

namespace TomTomWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly ILogger<PlacesController> _logger;

        public PlacesController(ILogger<PlacesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<PlaceCollection> Get()
        {
            return await GetPlaceCollection();
        }

        [HttpGet("{id}")]
        public async Task<Place> Get(int id)
        {
            var collection = await GetPlaceCollection();
            return collection.Places.Where(p => p.Id == id).Single();
        }

        private async Task<PlaceCollection> GetPlaceCollection()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(),
                "Data", "famous-places.json");

            string json = await System.IO.File.ReadAllTextAsync(file);
            return PlaceCollection.FromJson(json);
        }
    }
}
