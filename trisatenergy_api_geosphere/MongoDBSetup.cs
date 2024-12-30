using MongoDB.Driver;
using System.Threading.Tasks;

namespace trisatenergy_api_geosphere
{
    public static class MongoDBSetup
    {
        public static async Task<IMongoCollection<WeatherTimeSeriesModel>> InitializeMongoDB(AppSettings appSettings)
        {
            var client = new MongoClient(appSettings.MongoDB.ConnectionString);
            var database = client.GetDatabase(appSettings.MongoDB.DatabaseName);
            var collection = database.GetCollection<WeatherTimeSeriesModel>(appSettings.MongoDB.CollectionName);

            // Create a compound unique index on the Timestamp and Geometry fields
            var indexKeysDefinition = Builders<WeatherTimeSeriesModel>.IndexKeys
                .Ascending(model => model.Timestamp)
                .Geo2DSphere(model => model.Geometry);
            var indexOptions = new CreateIndexOptions { Unique = true };
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<WeatherTimeSeriesModel>(indexKeysDefinition, indexOptions));

            return collection;
        }
    }
}