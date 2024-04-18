namespace TrackerPi;

public sealed class DataLogger(GpsClient gps, ObdClient obd)
{
  public void Run(CancellationToken token)
  {
    while (true)
    {
      if (token.IsCancellationRequested)
      {
        Console.WriteLine($"    [{Environment.CurrentManagedThreadId}] Log cancellation requested");

        // Perform cleanup if necessary.
        //...
        // Terminate the operation.

        break;
      }

      // Simulate some work.
      Thread.Sleep(1000);
      var logData = GetCurrentData();
      Console.WriteLine($"  [{Environment.CurrentManagedThreadId}] Log {logData.ToCsv()}");
    }

    Console.WriteLine($"     [{Environment.CurrentManagedThreadId}] Log cancelled");
  }

  public TrackerData GetCurrentData()
  {
    var gpsData = gps.GetCurrentData();
    var obdData = obd.GetCurrentData();

    return new TrackerData(gpsData, obdData);
  }
}
