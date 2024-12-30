namespace trisatenergy_api_geosphere
{
    public class AppSettings
    {
        public GeoSphereApiClientSettings GeoSphereApiClient { get; set; }
        public MongoDBSettings MongoDB { get; set; }
    }

    public class GeoSphereApiClientSettings
    {
        public string BaseUrl { get; set; }
    }

    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}