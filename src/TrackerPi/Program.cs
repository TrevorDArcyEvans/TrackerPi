namespace TrackerPi;

using CommandLine;

public class Program
{
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
    Console.WriteLine($"GPS port: {opt.GPSPort}");
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
}
