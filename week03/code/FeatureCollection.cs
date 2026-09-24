public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public EarthquakeFeature[] Features { get; set; } = [];
}

public class EarthquakeFeature
{
    public EarthquakeProperties Properties { get; set; } = new();
}

public class EarthquakeProperties
{
    public string? Place { get; set; }
    public double? Mag { get; set; }
}