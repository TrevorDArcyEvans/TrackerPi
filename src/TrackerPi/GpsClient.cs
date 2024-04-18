namespace TrackerPi;

using svelde.nmea.parser;

public sealed class GpsClient(string port) :
  SerialClient(port)
{
  public void Run(CancellationToken token)
  {
    while (true)
    {
      if (token.IsCancellationRequested)
      {
        Console.WriteLine($"    [{Environment.CurrentManagedThreadId}] GPS cancellation requested");

        // Perform cleanup if necessary.
        //...
        // Terminate the operation.

        break;
      }

      // Simulate some work.
      Thread.Sleep(1000);
      Console.WriteLine($"  [{Environment.CurrentManagedThreadId}] GPS...");
    }

    Console.WriteLine($"     [{Environment.CurrentManagedThreadId}] GPS cancelled");
  }

  public GngllMessage GetCurrentData()
  {
    var gpsData = new GngllMessage();
    gpsData.Parse("$GNGLL,4513.13795,N,01859.19702,E,143717.00,A,A*72");

    return gpsData;
  }
}
