using ApiSdk; // Include your generated API client namespace
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using trisatenergy_api_geosphere;

namespace trisatenergy_api_geosphere
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("settings.json", false, true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .ConfigureServices((context, services) =>
                {
                    // Register AppSettings as a configuration instance
                    services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                    // Add logging
                    services.AddLogging(builder =>
                    {
                        builder.AddConfiguration(context.Configuration.GetSection("AppSettings:Logging"));
                        builder.AddConsole();
                    });
                    // Register the GeoSphere API client and MongoDB services
                    services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);
                    services.AddSingleton<IAuthenticationProvider, AnonymousAuthenticationProvider>();
                    services.AddSingleton<IRequestAdapter, HttpClientRequestAdapter>();
                    services.AddSingleton<GeoSphereApiClient>();
                })
                .Build();

            using IServiceScope scope = host.Services.CreateScope();
            var appSettings = scope.ServiceProvider.GetRequiredService<AppSettings>();
            var authProvider = scope.ServiceProvider.GetRequiredService<IAuthenticationProvider>();
            var adapter = scope.ServiceProvider.GetRequiredService<IRequestAdapter>();
            var geoSphereClient = scope.ServiceProvider.GetRequiredService<GeoSphereApiClient>();

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

                // Create WeatherTimeSeriesModel from GeoJSON
                var weatherTimeSeriesModel = await WeatherTimeSeriesModel.FromGeoJSON(timeseries_historical);

                // Set up MongoDB connection
                var client = new MongoClient(appSettings.MongoDB.ConnectionString);
                var database = client.GetDatabase(appSettings.MongoDB.DatabaseName);
                var collection = database.GetCollection<WeatherTimeSeriesModel>(appSettings.MongoDB.CollectionName);
                weatherTimeSeriesModel.ToJson();
                // Save to MongoDB using the model's method
                await weatherTimeSeriesModel.SaveToMongoDB(collection);

                
                // Export to JSON file
                await weatherTimeSeriesModel.ExportToJsonFile("weather_timeseries.json");

                Console.WriteLine("Response saved to MongoDB");
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
}