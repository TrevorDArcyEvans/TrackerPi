namespace TrackerPi;

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
}