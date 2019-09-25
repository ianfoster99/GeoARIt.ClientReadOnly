# IO.Swagger.Api.VenuesNearbyICalendarApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**VenuesICalendar**](VenuesNearbyICalendarApi.md#venuesicalendar) | **GET** /api/venue/nearby/{lat}/{lng}/{maxToLoad}/{radiusMeters}/icalendar | List of venues within a given radius in ICalendar format 


<a name="venuesicalendar"></a>
# **VenuesICalendar**
> List<Venue> VenuesICalendar (double? lat, double? lng, int? maxToLoad, int? radiusMeters, string authorization)

List of venues within a given radius in ICalendar format 

Radius to search (in meters) has max of 10000. Return format is iCalendar

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class VenuesICalendarExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new VenuesNearbyICalendarApi();
            var lat = 1.2;  // double? | 
            var lng = 1.2;  // double? | 
            var maxToLoad = 56;  // int? | 
            var radiusMeters = 56;  // int? | 
            var authorization = authorization_example;  // string |  (default to Bearer ieyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ijc0MTU0YjcyLTMwOGMtNGNlZC04NzQzLWVkZmFjZjIzMGJhYiIsIm5iZiI6MTU2MTgxMTMxMSwiZXhwIjoxNTkyOTE1MzExLCJpYXQiOjE1NjE4MTEzMTF9.E9cKU4PCvkuKpc_GtyUtwJa221pLxHl8dkhoICiD1h8)

            try
            {
                // List of venues within a given radius in ICalendar format 
                List&lt;Venue&gt; result = apiInstance.VenuesICalendar(lat, lng, maxToLoad, radiusMeters, authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VenuesNearbyICalendarApi.VenuesICalendar: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **lat** | **double?**|  | 
 **lng** | **double?**|  | 
 **maxToLoad** | **int?**|  | 
 **radiusMeters** | **int?**|  | 
 **authorization** | **string**|  | [default to Bearer ieyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ijc0MTU0YjcyLTMwOGMtNGNlZC04NzQzLWVkZmFjZjIzMGJhYiIsIm5iZiI6MTU2MTgxMTMxMSwiZXhwIjoxNTkyOTE1MzExLCJpYXQiOjE1NjE4MTEzMTF9.E9cKU4PCvkuKpc_GtyUtwJa221pLxHl8dkhoICiD1h8]

### Return type

[**List<Venue>**](Venue.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

