using MongoDB.Driver;
using System.Threading.Tasks;

namespace trisatenergy_api_geosphere
{
    /// <summary>
    /// Provides methods to initialize MongoDB collections.
    /// </summary>
    public static class MongoDBSetup
    {
        /// <summary>
        /// Initializes the MongoDB collection with the specified name.
        /// </summary>
        /// <param name="appSettings">The application settings containing MongoDB configuration.</param>
        /// <param name="collectionName">The name of the collection to initialize.</param>
        /// <returns>The initialized MongoDB collection.</returns>
        public static async Task<IMongoCollection<WeatherTimeSeriesModel>> InitializeMongoDB(AppSettings appSettings, string CollectionName)
        {
            var client = new MongoClient(appSettings.MongoDB.ConnectionString);
            var database = client.GetDatabase(appSettings.MongoDB.DatabaseName);
            var collection = database.GetCollection<WeatherTimeSeriesModel>(CollectionName);

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