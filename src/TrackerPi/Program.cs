namespace TrackerPi;

using CommandLine;

public sealed class Program : IDisposable
{
  private readonly CancellationTokenSource _cts = new();

  public static async Task Main(string[] args)
  {
    var prgm = new Program();
    var result = await Parser.Default
      .ParseArguments<Options>(args)
      .WithParsedAsync(prgm.Run);
    await result.WithNotParsedAsync(prgm.HandleParseError);
  }

  private async Task Run(Options opt)
  {
    Console.WriteLine($"GPS port: {opt.GpsPort}");
    Console.WriteLine($"OBD port: {opt.ObdPort}");

    // install ctrl-c handler to shutdown workers
    Console.CancelKeyPress += ConsoleOnCancelKeyPress;

    // create workers
    var gps = new GpsClient(opt.GpsPort);
    var obd = new ObdClient(opt.ObdPort);
    var log = new DataLogger(gps, obd);

    // start workers
    var gpsTask = Task.Factory.StartNew(() => gps.Run(_cts.Token));
    var obdTask = Task.Factory.StartNew(() => obd.Run(_cts.Token));
    var logTask = Task.Factory.StartNew(() => log.Run(_cts.Token));

    // blocks until workers are finished
    Task.WaitAll(gpsTask, obdTask, logTask);

    Console.WriteLine("Finished");
  }

  private void ConsoleOnCancelKeyPress(object? sender, ConsoleCancelEventArgs e)
  {
    e.Cancel = true;
    _cts.Cancel();

    Console.WriteLine("Console cancelled");
  }

  private Task HandleParseError(IEnumerable<Error> errs)
  {
    if (errs.IsVersion())
    {
      Console.WriteLine("Version Request");
      return Task.CompletedTask;
    }

    if (errs.IsHelp())
    {
      Console.WriteLine("Help Request");
      return Task.CompletedTask;
    }

    Console.WriteLine("Parser Fail");
    return Task.CompletedTask;
  }

  public void Dispose()
  {
    _cts.Dispose();

    Console.WriteLine("Disposed");
  }
}
