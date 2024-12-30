public class TimeseriesResponse
{
    public string MediaType { get; set; }
    public string Type { get; set; }
    public string Version { get; set; }
    public List<string> Timestamps { get; set; }
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public string Type { get; set; }
    public Geometry Geometry { get; set; }
    public Properties Properties { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public List<double> Coordinates { get; set; }
}

public class Properties
{
    public Dictionary<string, Parameter> Parameters { get; set; }
}

public class Parameter
{
    public string Name { get; set; }
    public string Unit { get; set; }
    public List<double> Data { get; set; }
}