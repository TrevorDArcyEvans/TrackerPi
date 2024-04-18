namespace TrackerPi;

using svelde.nmea.parser;

public sealed class TrackerData(GngllMessage gpsData, int speed)
{
  public string ToCsv()
  {
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
