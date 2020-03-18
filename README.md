# Visual Studio C# solution (GeoARIt.Client.sln) contains
- Web client with sample code to access Api (Net Core 2.2)
- Utilises GeoARIt.Api (Net Core 2.2) NuGet Library to access GeoAR.it [Api Endpoints](https://geoar.it/api-docs/index.html) 

<a name="dependencies"></a>
## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.2.0 or later
- [GeoARIt.Api](https://www.nuget.org/packages/GeoARIt.Api/) - 1.0.5 or later

The DLLs included in the package may not be the latest version. Check [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package GeoARIt.Api
```
<a name="getting-started"></a>
## Getting Started

The code contains an api key to access data on the [Demo](https://geoar.it/Venue/Index) account at [https://GeoAr.it](https://geoar.it).

[Get your own ApiKey](https://geoar.it/Help/Details/32/🔑-How-do-I-get-an-APi-KeyGet)

```csharp
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

            var version = "1";
            int rnd = new Random().Next(1, demoVenueGuids.Count + 1);

            // Added here to show example.Api key configuration would normally be called once at startup(Startup.cs)
            // Don't code ApiKeys in production code https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows           
            var authKey = " eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjU1MWEyZTgzLWM0MzgtNDEyNi1hMGY4LWJkOWYxM2VkMWY4NCIsIm5iZiI6MTU2NjI2MjQ4NCwiZXhwIjoxNTk3Nzk4NDgxLCJpYXQiOjE1NjYyNjI0ODR9.jE3HqDaQpd4WGglTz1qYkEWsCXLIux0py0alP0SSGxg";         
            var configuration = new Configuration();
            configuration.ApiKeyPrefix.Add("Authorization", $"Bearer {authKey}");            

            var vm = new VenueHotspotsViewModel()
            {
                VenueGuid = demoVenueGuids[rnd - 1],
                Venue = await new VenueApi(configuration).VenueAsync(demoVenueGuids[rnd - 1], version, ""),
                Hotspots = await new HotspotsForVenueApi(configuration).HotspotsForVenueAsync(demoVenueGuids[rnd - 1], 100, version, "")
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
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://GeoAR.it*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*HotspotApi* | [**HotspotApi**](docs/HotspotApi.md#2) | **GET** /api/hotspot/{guid} | Retrieve details of hotspot
*HotspotsForVenueApi* | [**HotspotHotspotsForVenue**](docs/HotspotsForVenueApi.md#hotspothotspotsforvenue) | **GET** /api/hotspot/venue/{venueGuid}/{maxToLoad} | Retrieve hotspots for the specified venue
*PrefabApi* | [**PrefabApi**](docs/PrefabApi.md#3) | **GET** /api/prefab/{guid} | Retrieve details of prefab (3D model)
*VenueApi* | [**Venue**](docs/VenueApi.md#venue) | **GET** /api/venue/{guid} | Retrieve venue details
*VenuesNearbyApi* | [**VenuesNearby**](docs/VenuesNearbyApi.md#venuesnearby) | **GET** /api/venue/nearby/{lat}/{lng}/{maxToLoad}/{radiusMeters}/{includeDemos} | List of venues within a given radius
*VenuesNearbyICalendarApi* | [**VenuesICalendar**](docs/VenuesNearbyICalendarApi.md#venuesicalendar) | **GET** /api/venue/nearby/{lat}/{lng}/{maxToLoad}/{radiusMeters}/icalendar | List of venues within a given radius in ICalendar format 


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.Hotspot](docs/Hotspot.md)
 - [Model.Prefab](docs/Prefab.md)
 - [Model.Venue](docs/Venue.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="Bearer"></a>
### Bearer

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

