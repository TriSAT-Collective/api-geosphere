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
    public class WeatherTimeSeriesModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        public double T2M { get; set; }
        public double UU { get; set; }
        public double VV { get; set; }

        [BsonElement("geometry")]
        public GeoJsonGeometry Geometry { get; set; }

        public static async Task<List<WeatherTimeSeriesModel>> FromGeoJSON(IParsable timeseries_historical)
        {
            var timeseriesJson = await KiotaJsonSerializer.SerializeAsStringAsync(timeseries_historical);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var root = JsonSerializer.Deserialize<Root>(timeseriesJson, options);

            var models = new List<WeatherTimeSeriesModel>();
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
            return models;
        }

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

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public async Task ExportToJsonFile(string filePath)
        {
            var jsonString = ToJson();
            await File.WriteAllTextAsync(filePath, jsonString);
        }
    }

    public class Root
    {
        public List<string> Timestamps { get; set; }
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public GeoJsonGeometry Geometry { get; set; }
        public Properties Properties { get; set; }
        public string Type { get; set; }
    }

    public class Properties
    {
        public Parameters Parameters { get; set; }
    }

    public class Parameters
    {
        public Parameter T2M { get; set; }
        public Parameter UU { get; set; }
        public Parameter VV { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public List<double> Data { get; set; }
    }

    public class GeoJsonGeometry
    {
        [BsonElement("type")]
        public string Type { get; set; } = "Point";

        [BsonElement("coordinates")]
        public List<double> Coordinates { get; set; }
    }
}