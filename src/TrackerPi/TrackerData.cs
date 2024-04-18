namespace TrackerPi;

using svelde.nmea.parser;

public sealed class TrackerData(GllMessage gpsData, int speed)
{
  public string ToCsv()
  {
    if (gpsData is null)
    {
      return string.Empty;
    }

    var data = new[]
    {
      gpsData.TimestampUtc.ToString("u"),
      gpsData.Latitude.ToString(),
      gpsData.Longitude.ToString(),
      speed.ToString()
    };
    return string.Join(",", data);
  }
}
