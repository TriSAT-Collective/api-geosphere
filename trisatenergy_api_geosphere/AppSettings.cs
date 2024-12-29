namespace trisatenergy_api_geosphere;

public class AppSettings
{
    public GeoSphereApiClientSettings GeoSphereApiClient { get; set; }
    public string JwtToken { get; set; } 

    public class GeoSphereApiClientSettings
    {
        public string BaseUrl { get; set; }
    }
}