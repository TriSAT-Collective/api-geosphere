using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using trisatenergy_api_geosphere;
namespace ApiSdk
{
    public class GeoSphereApiClientWrapper
    {
        private readonly GeoSphereApiClient _geoSphereApiClient;
        private readonly ILogger<GeoSphereApiClientWrapper> _logger;
        private readonly AppSettings _settings;
        private readonly IMongoCollection<WeatherTimeSeriesModel> _historicalCollection;
        private readonly IMongoCollection<WeatherTimeSeriesModel> _forecastCollection;

        public GeoSphereApiClientWrapper(GeoSphereApiClient geoSphereApiClient, IOptions<AppSettings> settings, ILogger<GeoSphereApiClientWrapper> logger, CollectionResolver collectionResolver)
        {
            _geoSphereApiClient = geoSphereApiClient;
            _logger = logger;
            _settings = settings.Value;
            _historicalCollection = collectionResolver("Historical");
            _forecastCollection = collectionResolver("Forecast");
        }

        public async Task Start()
        {
            DateTime startTime = _settings.Misc.PullnStoreStartTime ?? DateTime.Now;
            if (_settings.Misc.ContinuousPullnStore)
            {
                _logger.LogInformation("Starting continuous Pull'n'Store...");
                await ContinuousPullnStore(startTime);
            }
            else
            {
                _logger.LogInformation("Starting once-off Pull'n'Store... Pulling +- {Hours} hours",
                    _settings.Misc.OnceOffPullnStoreHours);
                await OnceOffPullnStoreHours(startTime, _settings.Misc.OnceOffPullnStoreHours);
            }
        }

        private async Task ContinuousPullnStore(DateTime startTime)
        {
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, 0, 0, startTime.Kind);
            while (true)
            {
                await OnceOffPullnStoreHours(startTime, 1);
                await Task.Delay(_settings.Misc.ContinuousPullnStoreIntervalMs);
                startTime = startTime.AddHours(1);
            }
        }

        private async Task OnceOffPullnStoreHours(DateTime startTime, int hours)
        {
            try
            {
                var end = startTime;
                var start = end.AddHours(-hours);
                var timeseries_historical = await _geoSphereApiClient.Timeseries.Historical["inca-v1-1h-1km"].GetAsync(requestConfig =>
                {
                    requestConfig.QueryParameters.Start = start.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.End = end.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.LatLon = new string[] { "47.0,15.0" };
                    requestConfig.QueryParameters.Parameters = new string[] { "T2M", "UU", "VV" };
                    requestConfig.QueryParameters.OutputFormat = "geojson";
                });

                var weatherTimeSeriesModels = await WeatherTimeSeriesModel.FromGeoJSON(timeseries_historical);

                await WeatherTimeSeriesModel.SaveToMongoDB(_historicalCollection, weatherTimeSeriesModels);

                _logger.LogInformation("Historical response saved to MongoDB. Start: {Start}, End: {EndT}, LatLon: {LatLon}, Dataset: {dataset}", start, end, string.Join(", ", new string[] { "47.0,15.0" }), "inca-v1-1h-1km");

                start = startTime;
                end = start.AddHours(+hours);
                // Forecast timeseries query
                var timeseries_forecast = await _geoSphereApiClient.Timeseries.Forecast["nwp-v1-1h-2500m"].GetAsync(requestConfig =>
                {
                    requestConfig.QueryParameters.Start = start.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.End = end.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.LatLon = new string[] { "47.0,15.0" };;
                    requestConfig.QueryParameters.Parameters = new string[] { "t2m", "ugust", "vgust" };
                    requestConfig.QueryParameters.OutputFormat = "geojson";
                });

                var weatherTimeSeriesModelsForecast = await WeatherTimeSeriesModel.FromGeoJSON(timeseries_forecast, true);
                await WeatherTimeSeriesModel.SaveToMongoDB(_forecastCollection, weatherTimeSeriesModelsForecast);

                _logger.LogInformation("Forecast response saved to MongoDB. Start: {Start}, End: {End}, LatLon: {LatLon}, Dataset: {Dataset}", start, end, string.Join(", ", new string[] { "47.0,15.0" }), "nwp-v1-1h-2500m");
            }
            catch (ApiSdk.Models.HTTPValidationError ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
                _logger.LogError(ex.StackTrace);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
                _logger.LogError(ex.StackTrace);
            }
        }
    }
}