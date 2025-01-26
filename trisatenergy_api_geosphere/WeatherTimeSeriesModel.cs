using System;
using System.Collections.Generic;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace trisatenergy_api_geosphere
{
    /// <summary>
    /// Represents a weather time series model.
    /// </summary>
    public class WeatherTimeSeriesModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the model.
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }
        /// <summary>
        /// Gets or sets the timestamp of the weather data.
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Gets or sets the temperature at 2 meters above ground level.
        /// </summary>
        public double T2M { get; set; }
        /// <summary>
        /// Gets or sets the eastward wind component.
        /// </summary>
        public double UU { get; set; }
        /// <summary>
        /// Gets or sets the northward wind component.
        /// </summary>
        public double VV { get; set; }
        /// <summary>
        /// Gets or sets the geometry of the weather data point.
        /// </summary>
        [BsonElement("geometry")]
        public GeoJsonGeometry Geometry { get; set; }
        /// <summary>
        /// Saves a list of WeatherTimeSeriesModel instances to a MongoDB collection.
        /// </summary>
        /// <param name="collection">The MongoDB collection to save to.</param>
        /// <param name="models">The list of models to save.</param>
        public static async Task<List<WeatherTimeSeriesModel>> FromGeoJSON(IParsable timeseries, bool isForecast = false)
        {
            List<WeatherTimeSeriesModel> models = null;
            if (timeseries == null)
            {
                throw new ArgumentNullException(nameof(timeseries), "The timeseries object cannot be null.");
            }  
            
            if (isForecast == false)
            {
                var timeseriesJson = await KiotaJsonSerializer.SerializeAsStringAsync(timeseries);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var root = JsonSerializer.Deserialize<Root>(timeseriesJson, options);

                models = new List<WeatherTimeSeriesModel>();
                if (root != null)
                    for (int i = 0; i < root.Timestamps.Count; i++)
                    {
                        models.Add(new WeatherTimeSeriesModel
                        {
                            Timestamp = DateTime.Parse(root.Timestamps[i]),
                            T2M = root.Features[0].Properties.Parameters.T2M.Data[i],
                            UU = root.Features[0].Properties.Parameters.UU.Data[i],
                            VV = root.Features[0].Properties.Parameters.VV.Data[i],
                            Geometry = root.Features[0].Geometry
                        });
                    }
            }
            else
            {
                var timeseriesJson = await KiotaJsonSerializer.SerializeAsStringAsync(timeseries);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var root = JsonSerializer.Deserialize<Root>(timeseriesJson, options);

                models = new List<WeatherTimeSeriesModel>();
                if (root != null)
                    for (int i = 0; i < root.Timestamps.Count; i++)
                    {
                        models.Add(new WeatherTimeSeriesModel
                        {
                            Timestamp = DateTime.Parse(root.Timestamps[i]),
                            T2M = root.Features[0].Properties.Parameters.T2M.Data[i],
                            UU = root.Features[0].Properties.Parameters.UGUST.Data[i],
                            VV = root.Features[0].Properties.Parameters.VGUST.Data[i],
                            Geometry = root.Features[0].Geometry
                        });
                    }
            }

            return models;
        }
        /// <summary>
        /// Saves a list of WeatherTimeSeriesModel instances to a MongoDB collection.
        /// </summary>
        /// <param name="collection">The MongoDB collection to save to.</param>
        /// <param name="models">The list of models to save.</param>
        public static async Task SaveToMongoDB(IMongoCollection<WeatherTimeSeriesModel> collection, IEnumerable<WeatherTimeSeriesModel> models)
        {
            foreach (var model in models)
            {
                try
                {
                    await collection.InsertOneAsync(model);
                }
                catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
                {
                    Console.WriteLine($"Duplicate key error: {ex.WriteError.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Write error: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// Converts the model to a JSON string.
        /// </summary>
        /// <returns>A JSON string representation of the model.</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        /// <summary>
        /// Exports the model to a JSON file.
        /// </summary>
        /// <param name="filePath">The file path to save the JSON file to.</param>
        public async Task ExportToJsonFile(string filePath)
        {
            var jsonString = ToJson();
            await File.WriteAllTextAsync(filePath, jsonString);
        }
    }
    /// <summary>
    /// Represents the root of the GeoJSON data.
    /// </summary>
    public class Root
    {
        /// <summary>
        /// Gets or sets the list of timestamps.
        /// </summary>
        public List<string> Timestamps { get; set; }
        /// <summary>
        /// Gets or sets the list of features.
        /// </summary>
        public List<Feature> Features { get; set; }
    }
    /// <summary>
    /// Represents a feature in the GeoJSON data.
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Gets or sets the geometry of the feature.
        /// </summary>
        public GeoJsonGeometry Geometry { get; set; }
        /// <summary>
        /// Gets or sets the properties of the feature.
        /// </summary>
        public Properties Properties { get; set; }
        /// <summary>
        /// Gets or sets the type of the feature.
        /// </summary>
        public string Type { get; set; }
    }
    /// <summary>
    /// Represents the properties of a feature.
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// Gets or sets the parameters of the feature.
        /// </summary>
        public Parameters Parameters { get; set; }
    }
    /// <summary>
    /// Represents the parameters of a feature.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Gets or sets the temperature parameter.
        /// </summary>
        public Parameter T2M { get; set; }
        /// <summary>
        /// Gets or sets the eastward wind component parameter.
        /// </summary>
        public Parameter UU { get; set; }
        /// <summary>
        /// Gets or sets the eastward wind gust component parameter.
        /// </summary>
        public Parameter UGUST { get; set; }
        /// <summary>
        /// Gets or sets the northward wind component parameter.
        /// </summary>
        public Parameter VV { get; set; }
        /// <summary>
        /// Gets or sets the northward wind gust component parameter.
        /// </summary>
        public Parameter VGUST { get; set; }
    }
    /// <summary>
    /// Represents a parameter in the GeoJSON data.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the unit of the parameter.
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Gets or sets the data values of the parameter.
        /// </summary>
        public List<double> Data { get; set; }
    }
    /// <summary>
    /// Represents the geometry of a feature in GeoJSON format.
    /// </summary>
    public class GeoJsonGeometry
    {
        /// <summary>
        /// Gets or sets the type of the geometry.
        /// </summary>
        [BsonElement("type")]
        public string Type { get; set; } = "Point";
        /// <summary>
        /// Gets or sets the coordinates of the geometry.
        /// </summary>
        [BsonElement("coordinates")]
        public List<double> Coordinates { get; set; }
    }
}