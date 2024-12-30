using ApiSdk; // Include your generated API client namespace
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System;
using System.Text.Json; // Import for JSON serialization
using System.Threading.Tasks;
using ApiSdk.Datasets;
using Microsoft.Kiota.Abstractions.Serialization; // Serialization namespace
using Microsoft.Kiota.Serialization.Json; // Correct import for Kiota JSON serialization
using trisatenergy_api_geosphere;

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
            // GET historical timeseries
            var timeseries_historical = await geoSphereClient.Timeseries.Historical["inca-v1-1h-1km"].GetAsync(requestConfig =>
            {
                requestConfig.QueryParameters.Start = "2023-01-01T00:00";
                requestConfig.QueryParameters.End = "2023-01-02T00:00";
                requestConfig.QueryParameters.LatLon = new string[] { "47.0,15.0" };
                requestConfig.QueryParameters.Parameters = new string[] { "T2M", "UU", "VV" };
                requestConfig.QueryParameters.OutputFormat = "geojson";
            });

            // Serialize the response to a JSON string
            var timeseriesJson = JsonSerializer.Serialize(timeseries_historical);

            // Write the JSON string to a file
            await File.WriteAllTextAsync("timeseries_historical.json", timeseriesJson);

            Console.WriteLine("Response written to timeseries_historical.json");
        }
        catch (ApiSdk.Models.HTTPValidationError ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }
}