using ApiSdk;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using trisatenergy_api_geosphere;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
                    services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                    services.AddLogging(builder =>
                    {
                        builder.AddConfiguration(context.Configuration.GetSection("AppSettings:Logging"));
                        builder.AddConsole();
                    });
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
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            try
            {
                var endTime = DateTime.UtcNow;
                var startTime = endTime.AddHours(-48);
                var timeseries_historical = await geoSphereClient.Timeseries.Historical["inca-v1-1h-1km"].GetAsync(requestConfig =>
                {
                    requestConfig.QueryParameters.Start = startTime.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.End = endTime.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.LatLon = new string[] { "47.0,15.0" };
                    requestConfig.QueryParameters.Parameters = new string[] { "T2M", "UU", "VV" };
                    requestConfig.QueryParameters.OutputFormat = "geojson";
                });

                var weatherTimeSeriesModels = await WeatherTimeSeriesModel.FromGeoJSON(timeseries_historical);

                var historicalCollection = await MongoDBSetup.InitializeMongoDB(appSettings, appSettings.MongoDB.Collections.TimeseriesHistorical);
                await WeatherTimeSeriesModel.SaveToMongoDB(historicalCollection, weatherTimeSeriesModels);

                logger.LogInformation("Historical response saved to MongoDB. StartTime: {StartTime}, EndTime: {EndTime}, LatLon: {LatLon}, Dataset: {dataset}", startTime, endTime, string.Join(", ", new string[] { "47.0,15.0" }), "inca-v1-1h-1km");
 
                
                startTime =  DateTime.UtcNow;
                endTime = startTime.AddHours(+48);
                // Forecast timeseries query
                var timeseries_forecast = await geoSphereClient.Timeseries.Forecast["nwp-v1-1h-2500m"].GetAsync(requestConfig =>
                {
                    requestConfig.QueryParameters.Start = startTime.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.End = endTime.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.LatLon  = new string[] { "47.0,15.0" };;
                    requestConfig.QueryParameters.Parameters = new string[] { "t2m", "ugust", "vgust" };
                    requestConfig.QueryParameters.OutputFormat = "geojson";
                });

                var weatherTimeSeriesModelsForecast = await WeatherTimeSeriesModel.FromGeoJSON(timeseries_forecast, true);
                var forecastCollection = await MongoDBSetup.InitializeMongoDB(appSettings, appSettings.MongoDB.Collections.TimeseriesForecast);
                await WeatherTimeSeriesModel.SaveToMongoDB(forecastCollection, weatherTimeSeriesModelsForecast);

                logger.LogInformation("Forecast response saved to MongoDB. StartTime: {StartTime}, EndTime: {EndTime}, LatLon: {LatLon}, Dataset: {Dataset}", startTime, endTime, string.Join(", ", new string[] { "47.0,15.0" }), "nwp-v1-1h-2500m");
            }
            catch (ApiSdk.Models.HTTPValidationError ex)
            {
                logger.LogError($"ERROR: {ex.Message}");
                logger.LogError(ex.StackTrace);
            }
            catch (Exception ex)
            {
                logger.LogError($"ERROR: {ex.Message}");
                logger.LogError(ex.StackTrace);
            }
        }
    }
}