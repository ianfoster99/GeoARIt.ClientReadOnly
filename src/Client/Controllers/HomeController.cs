using GeoARIt.Api;
using GeoARIt.Api.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Randomly picks one of the two demo venues
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            // https://geoar.it/Help/Details/📑~32~🔑-How-do-I-get-an-APi-Key

            if (Configuration.ApiKey.Count == 0)
            {
                // Added here to show example. Api key configuration would normally be called once at startup (Startup.cs)
                // Don't code ApiKeys in production code https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows
                Configuration.ApiKey.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjU1MWEyZTgzLWM0MzgtNDEyNi1hMGY4LWJkOWYxM2VkMWY4NCIsIm5iZiI6MTU2NjI2MjQ4NCwiZXhwIjoxNTk3Nzk4NDgxLCJpYXQiOjE1NjYyNjI0ODR9.jE3HqDaQpd4WGglTz1qYkEWsCXLIux0py0alP0SSGxg");
                Configuration.ApiKeyPrefix.Add("Authorization", "Bearer");
            }

            int rnd = new Random().Next(1, demoVenueGuids.Count + 1);

            var vm = new VenueHotspotsViewModel()
            {
                VenueGuid = demoVenueGuids[rnd - 1],
                Venue = new VenueApi().Venue(demoVenueGuids[rnd - 1]),
                Hotspots = new HotspotsForVenueApi().HotspotsForVenue(demoVenueGuids[rnd - 1], 100)
            };

            return View(vm);
        }

        private readonly List<Guid> demoVenueGuids = new List<Guid>
        {
            Guid.Parse("11111111-1111-1111-1111-05ECB3F6EA4C"), // Main 3D objects demo
            Guid.Parse("33333333-3333-3333-3333-05ECB3F6EA4A"), // Festival demo
        };

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}