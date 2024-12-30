namespace trisatenergy_api_geosphere;

using System.Collections.Generic;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Microsoft.Kiota.Abstractions.Serialization; // Serialization namespace

public class WeatherTimeSeriesModel
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string MediaType { get; set; }
    public string Type { get; set; }
    public string Version { get; set; }
    public List<string> Timestamps { get; set; }
    public List<Feature> Features { get; set; }

    public static async Task<WeatherTimeSeriesModel> FromGeoJSON(IParsable timeseries_historical)
    {
        var timeseriesJson = await KiotaJsonSerializer.SerializeAsStringAsync(timeseries_historical);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return JsonSerializer.Deserialize<WeatherTimeSeriesModel>(timeseriesJson, options);
    }

    public async Task SaveToMongoDB(IMongoCollection<WeatherTimeSeriesModel> collection)
    {
        await collection.InsertOneAsync(this);
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

public class Feature
{
    public Geometry Geometry { get; set; }
    public Properties Properties { get; set; }
    public string Type { get; set; }
}

public class Geometry
{
    public List<double> Coordinates { get; set; }
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