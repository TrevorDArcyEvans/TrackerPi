namespace TrackerPi;

using CommandLine;

internal sealed class Options
{
  [Value(index: 0, Required = true, HelpText = "GPS Port eg ttyACM0")]
  public string GpsPort { get; set; }
  
  [Value(index: 1, Required = true, HelpText = "OBD Port eg ttyOBD0")]
  public string ObdPort { get; set; }
}
