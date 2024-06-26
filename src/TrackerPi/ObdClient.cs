namespace TrackerPi;

public sealed class ObdClient(string port) :
  SerialClient(port)
{
  public void Run(CancellationToken token)
  {
    while (true)
    {
      if (token.IsCancellationRequested)
      {
        Console.WriteLine($"    [{Environment.CurrentManagedThreadId}] OBD cancellation requested");

        // Perform cleanup if necessary.
        //...
        // Terminate the operation.

        break;
      }

      // Simulate some work.
      Thread.Sleep(TimeSpan.FromSeconds(1));
      Console.WriteLine($"  [{Environment.CurrentManagedThreadId}] OBD work...");
    }

    Console.WriteLine($"     [{Environment.CurrentManagedThreadId}] OBD cancelled");
  }

  public int GetCurrentData()
  {
    return Random.Shared.Next();
  }
}
