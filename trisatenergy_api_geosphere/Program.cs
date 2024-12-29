using ApiSdk; // Include your generated API client namespace
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System;
using System.Threading.Tasks;
using ApiSdk.Datasets;
using Microsoft.Kiota.Abstractions.Serialization; // Serialization namespace
using Microsoft.Kiota.Serialization.Json; // Correct import for Kiota JSON serialization

class Program
{
    static async Task Main(string[] args)
    {
        // Set up the anonymous authentication provider (since the API doesn't require authentication)
        var authProvider = new AnonymousAuthenticationProvider();

        // Create request adapter using the HttpClient-based implementation
        var adapter = new HttpClientRequestAdapter(authProvider);

        // Create the GeoSphere API client
        var geoSphereClient = new GeoSphereApiClient(adapter);

        try
        {
            // GET /datasets (example)
            var datasets = await geoSphereClient.Datasets.GetAsync();
            Console.WriteLine($"Retrieved {datasets}");
            
            // GET historical timeseries -> error 
            //ERROR: The server returned an unexpected status code and no error factory is registered for this code: 400

            var timeseries_historical = await geoSphereClient.Timeseries.Historical["inca-v1-1h-1km"].GetAsync();
            Console.WriteLine($"Retrieved {timeseries_historical}");

            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }


}
