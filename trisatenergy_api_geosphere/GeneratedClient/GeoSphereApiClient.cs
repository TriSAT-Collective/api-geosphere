// <auto-generated/>
#pragma warning disable CS0618
using ApiSdk.Datasets;
using ApiSdk.Grid;
using ApiSdk.Station;
using ApiSdk.Timeseries;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using trisatenergy_api_geosphere;
namespace ApiSdk
{
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class GeoSphereApiClient : BaseRequestBuilder
    {
        private readonly ILogger<GeoSphereApiClient> _logger;
        private readonly AppSettings _settings;
        /// <summary>The datasets property</summary>
        public global::ApiSdk.Datasets.DatasetsRequestBuilder Datasets
        {
            get => new global::ApiSdk.Datasets.DatasetsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The grid property</summary>
        public global::ApiSdk.Grid.GridRequestBuilder Grid
        {
            get => new global::ApiSdk.Grid.GridRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The station property</summary>
        public global::ApiSdk.Station.StationRequestBuilder Station
        {
            get => new global::ApiSdk.Station.StationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The timeseries property</summary>
        public global::ApiSdk.Timeseries.TimeseriesRequestBuilder Timeseries
        {
            get => new global::ApiSdk.Timeseries.TimeseriesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.GeoSphereApiClient"/> and sets the default values.
        /// </summary>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GeoSphereApiClient(IRequestAdapter requestAdapter, IOptions<AppSettings> settings, ILogger<GeoSphereApiClient> logger) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>())
        {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
            _logger = logger;
            _settings = settings.Value;
            if (string.IsNullOrEmpty(RequestAdapter.BaseUrl))
            {
                RequestAdapter.BaseUrl = "https://dataset.api.hub.geosphere.at/v1";
            }
            PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);
        }
        
        public async Task Start()
        {   
            DateTime startTime = _settings.Misc.PullnStoreStartTime ?? DateTime.Now;
            _logger.LogError("THE startTime IS: {startTime}", startTime);
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
                var timeseries_historical = await this.Timeseries.Historical["inca-v1-1h-1km"].GetAsync(requestConfig =>
                {
                    requestConfig.QueryParameters.Start = start.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.End = end.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.LatLon = new string[] { "47.0,15.0" };
                    requestConfig.QueryParameters.Parameters = new string[] { "T2M", "UU", "VV" };
                    requestConfig.QueryParameters.OutputFormat = "geojson";
                });

                var weatherTimeSeriesModels = await WeatherTimeSeriesModel.FromGeoJSON(timeseries_historical);

                var historicalCollection = await MongoDBSetup.InitializeMongoDB(_settings, _settings.MongoDB.Collections.TimeseriesHistorical);
                await WeatherTimeSeriesModel.SaveToMongoDB(historicalCollection, weatherTimeSeriesModels);

                _logger.LogInformation("Historical response saved to MongoDB. Start: {Start}, End: {EndT}, LatLon: {LatLon}, Dataset: {dataset}", start, end, string.Join(", ", new string[] { "47.0,15.0" }), "inca-v1-1h-1km");
 
                
                start =  startTime;
                end = start.AddHours(+hours);
                // Forecast timeseries query
                var timeseries_forecast = await this.Timeseries.Forecast["nwp-v1-1h-2500m"].GetAsync(requestConfig =>
                {
                    requestConfig.QueryParameters.Start = start.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.End = end.ToString("yyyy-MM-ddTHH:mm");
                    requestConfig.QueryParameters.LatLon  = new string[] { "47.0,15.0" };;
                    requestConfig.QueryParameters.Parameters = new string[] { "t2m", "ugust", "vgust" };
                    requestConfig.QueryParameters.OutputFormat = "geojson";
                });

                var weatherTimeSeriesModelsForecast = await WeatherTimeSeriesModel.FromGeoJSON(timeseries_forecast, true);
                var forecastCollection = await MongoDBSetup.InitializeMongoDB(_settings, _settings.MongoDB.Collections.TimeseriesForecast);
                await WeatherTimeSeriesModel.SaveToMongoDB(forecastCollection, weatherTimeSeriesModelsForecast);

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
#pragma warning restore CS0618
