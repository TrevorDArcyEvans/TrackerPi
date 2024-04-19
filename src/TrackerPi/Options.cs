namespace TrackerPi;

using CommandLine;

internal sealed class Options
{
  [Value(index: 0, Required = true, HelpText = "GPS Port eg /dev/ttyACM0")]
  public string GpsPort { get; set; }
  
  [Value(index: 1, Required = true, HelpText = "OBD Port eg /dev/ttyUSB0")]
  public string ObdPort { get; set; }
}
