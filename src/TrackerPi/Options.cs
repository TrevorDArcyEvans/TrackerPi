namespace TrackerPi;

using CommandLine;

internal sealed class Options
{
  [Value(index: 0, Required = true, HelpText = "GPS Port eg ttyACM0")]
  public string GPSPort { get; set; }
}
