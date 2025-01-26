using System.ComponentModel;

namespace trisatenergy_api_geosphere
{
    /// <summary>
    /// Represents the application settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets the GeoSphere API client settings.
        /// </summary>
        public GeoSphereApiClientSettings GeoSphereApiClient { get; init; }
        /// <summary>
        /// Gets the MongoDB settings.
        /// </summary>
        public MongoDBSettings MongoDB { get; init; }
        /// <summary>
        /// Gets the miscellaneous settings.
        /// </summary>
        public MiscSettings Misc { get; init; }
    }
    /// <summary>
    /// Represents the GeoSphere API client settings.
    /// </summary>
    public class GeoSphereApiClientSettings
    {
        /// <summary>
        /// Gets or sets the base URL of the GeoSphere API client.
        /// </summary>
        public string BaseUrl { get; set; }
    }
    /// <summary>
    /// Represents the MongoDB settings.
    /// </summary>
    public class MongoDBSettings
    {
        /// <summary>
        /// Gets or sets the connection string for MongoDB.
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Gets or sets the name of the MongoDB database.
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// Gets or sets the MongoDB collections.
        /// </summary>
        public MongoDBCollections Collections { get; set; }
    }
    /// <summary>
    /// Represents the MongoDB collections.
    /// </summary>
    public class MongoDBCollections
    {
        /// <summary>
        /// Gets or sets the name of the historical timeseries collection.
        /// </summary>
        public string TimeseriesHistorical { get; set; }
        /// <summary>
        /// Gets or sets the name of the forecast timeseries collection.
        /// </summary>
        public string TimeseriesForecast { get; set; }
    }
    /// <summary>
    /// Represents miscellaneous settings.
    /// </summary>
    public class MiscSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether continuous pull and store is enabled.
        /// </summary>
        public bool ContinuousPullnStore { get; set; }
        /// <summary>
        /// Gets or sets the interval in milliseconds for continuous pull and store.
        /// </summary>
        [DefaultValue(3000)] public int ContinuousPullnStoreIntervalMs { get; set; }
        /// <summary>
        /// Gets or sets the number of hours for once-off pull and store.
        /// </summary>
        [DefaultValue(24)] public int OnceOffPullnStoreHours { get; set; }
        /// <summary>
        /// Gets or sets the start time for pull and store.
        /// </summary>
        public DateTime? PullnStoreStartTime { get; set; }
    }

}