using System;
using System.Collections.Generic;

public class MeasurementScore
{
    public int MinExclusive { get; set; }
    public int MaxInclusive { get; set; }
    public int Score { get; set; }
}

public class MeasurementScores : Dictionary<MeasurementType, List<MeasurementScore>>
{
    public MeasurementScores()
    {
        this.Add(MeasurementType.TEMP, new List<MeasurementScore>
            {
                new MeasurementScore { MinExclusive = 31, MaxInclusive = 35, Score = 3 },
                new MeasurementScore { MinExclusive = 35, MaxInclusive = 36, Score = 1 },
                new MeasurementScore { MinExclusive = 36, MaxInclusive = 38, Score = 0 },
                new MeasurementScore { MinExclusive = 38, MaxInclusive = 39, Score = 1 },
                new MeasurementScore { MinExclusive = 39, MaxInclusive = 42, Score = 2 }
            });
        this.Add(MeasurementType.HR, new List<MeasurementScore>
            {
                new MeasurementScore { MinExclusive = 25, MaxInclusive = 40, Score = 3 },
                new MeasurementScore { MinExclusive = 40, MaxInclusive = 50, Score = 1 },
                new MeasurementScore { MinExclusive = 50, MaxInclusive = 90, Score = 0 },
                new MeasurementScore { MinExclusive = 90, MaxInclusive = 110, Score = 1 },
                new MeasurementScore { MinExclusive = 110, MaxInclusive = 130, Score = 2 },
                new MeasurementScore { MinExclusive = 130, MaxInclusive = 220, Score = 3 }
            });
        this.Add(MeasurementType.RR, new List<MeasurementScore>
            {
                new MeasurementScore { MinExclusive = 3, MaxInclusive = 8, Score = 3 },
                new MeasurementScore { MinExclusive = 8, MaxInclusive = 11, Score = 1 },
                new MeasurementScore { MinExclusive = 11, MaxInclusive = 20, Score = 0 },
                new MeasurementScore { MinExclusive = 20, MaxInclusive = 24, Score = 2 },
                new MeasurementScore { MinExclusive = 24, MaxInclusive = 60, Score = 3 }
            });
    }

    public float LookupScore(Measurements measurements)
    {
        var includeMeasurementTypes = new MeasurementType[]{
            MeasurementType.TEMP, MeasurementType.RR, MeasurementType.RR};
        var scores = includeMeasurementTypes.Select(measurementType =>
        {
//            var measurement = measurements.measurements.Find(e => e.type == measurementType);
            return LookupScore(measurementType, 22/*measurement.value*/);
        });
        return scores.Sum();
    }

    public float LookupScore(MeasurementType measurementType, float value)
    {
        var mt = this[measurementType];
        var hit = mt.Find(e => e.MinExclusive < value && e.MaxInclusive >= value);
        if (hit == null) throw new ArgumentOutOfRangeException("Value for " + measurementType + " is outside valid range.");
        return hit.Score;
    }
}
