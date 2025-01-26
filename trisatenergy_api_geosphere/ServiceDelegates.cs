using MongoDB.Driver;
namespace trisatenergy_api_geosphere
{
    /// <summary>
    /// Delegate to resolve MongoDB collections based on a key.
    /// </summary>
    /// <param name="key">The key to identify the collection.</param>
    /// <returns>The resolved MongoDB collection.</returns>
    public delegate IMongoCollection<WeatherTimeSeriesModel> CollectionResolver(string key);
}