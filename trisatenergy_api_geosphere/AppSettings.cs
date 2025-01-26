using System.ComponentModel;

namespace trisatenergy_api_geosphere
{
    public class AppSettings
    {
        public GeoSphereApiClientSettings GeoSphereApiClient { get; init; }
        public MongoDBSettings MongoDB { get; init; }
        public MiscSettings Misc { get; init; }
    }

    public class GeoSphereApiClientSettings
    {
        public string BaseUrl { get; set; }
    }

    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        
        public MongoDBCollections Collections { get; set; }
    }
    
    public class MongoDBCollections
    {
        public string TimeseriesHistorical { get; set; }
        public string TimeseriesForecast { get; set; }
    }
    
    public class MiscSettings
    {
        public bool ContinuousPullnStore { get; set; }

        [DefaultValue(3000)] public int ContinuousPullnStoreIntervalMs { get; set; }

        [DefaultValue(24)] public int OnceOffPullnStoreHours { get; set; }

        public DateTime? PullnStoreStartTime { get; set; }
    }

}