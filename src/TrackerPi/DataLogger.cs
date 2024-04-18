namespace TrackerPi;

public sealed class DataLogger(GpsClient gps, ObdClient obd)
{
  private readonly GpsClient _gps = gps;
  private readonly ObdClient _obd = obd;

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
      Console.WriteLine($"  [{Environment.CurrentManagedThreadId}] Log...");
    }

    Console.WriteLine($"     [{Environment.CurrentManagedThreadId}] Log cancelled");
  }
}
