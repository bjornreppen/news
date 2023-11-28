using NUnit.Framework;

public class MeasurementScoresTests
{
    MeasurementScores scores;
    public MeasurementScoresTests() {
        scores = new MeasurementScores();
    }

    [Test]
    public void Temp_39()
    {
        Assert.AreEqual(1, scores.LookupScore(MeasurementType.TEMP, 39));
    }

    [Test]
    public void Heartrate_43()
    {
        Assert.AreEqual(1, scores.LookupScore(MeasurementType.HR, 43));
    }

    [Test]
    public void RespiratoryRate_19()
    {
        Assert.AreEqual(0, scores.LookupScore(MeasurementType.RR, 19));
    }
}
