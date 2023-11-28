public enum MeasurementType
{
    TEMP, HR, RR
}

public class Measurement
{
//    public MeasurementType type { get; set; }
      public string? type { get; set; }
    public float? value { get; set; }
}

public class Measurements
{
    public IEnumerable<Measurement> measurements { get; set; } = new List<Measurement>();
}
