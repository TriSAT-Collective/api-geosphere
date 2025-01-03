using MongoDB.Driver;
namespace trisatenergy_api_geosphere
{
    public delegate IMongoCollection<WeatherTimeSeriesModel> CollectionResolver(string key);
}