namespace TrackerPi;

using svelde.nmea.app;
using svelde.nmea.parser;

public sealed class GpsClient : SerialClient
{
  private readonly SerialReader _serial;
  private readonly NmeaParser _parser = new();

  public GpsClient(string port) :
    base(port)
  {
    _serial = new SerialReader(port);
    _serial.NmeaSentenceReceived += NmeaSentenceReceived;

    _parser.NmeaMessageParsed += NmeaMessageParsed;
  }

  public void Run(CancellationToken token)
  {
    _serial.Open();

    while (true)
    {
      if (token.IsCancellationRequested)
      {
        Console.WriteLine($"    [{Environment.CurrentManagedThreadId}] GPS cancellation requested");

        // Perform cleanup if necessary.
        _serial.Close();
        _serial.Dispose();
        // Terminate the operation.

        break;
      }

      // Simulate some work.
      Thread.Sleep(1000);
      Console.WriteLine($"  [{Environment.CurrentManagedThreadId}] GPS...");
    }

    Console.WriteLine($"     [{Environment.CurrentManagedThreadId}] GPS cancelled");
  }

  private GllMessage _data;

  public GllMessage GetCurrentData()
  {
    return _data;
  }

  private void NmeaMessageParsed(object sender, NmeaMessage e)
  {
    var msgActions = new Dictionary<Type, Action>
    {
      {typeof(GnggaMessage), () => { Console.WriteLine($"{e}"); }},
      {typeof(GpggaMessage), () => { Console.WriteLine($"{e}"); }},
      {
        typeof(GngllMessage), () =>
        {
          Console.WriteLine($"{e}");
          _data = (GngllMessage) e;
        }
      },
      {
        typeof(GpgllMessage), () =>
        {
          Console.WriteLine($"{e}");
          _data = (GpgllMessage) e;
        }
      },
      {typeof(GngsaMessage), () => { Console.WriteLine($"{e}"); }},
      {typeof(GpgsaMessage), () => { Console.WriteLine($"{e}"); }},
      {typeof(GnrmcMessage), () => { Console.WriteLine($"{e}"); }},
      {typeof(GprmcMessage), () => { Console.WriteLine($"{e}"); }},
      {typeof(GntxtMessage), () => { Console.WriteLine($"{e}"); }},
      {typeof(GnvtgMessage), () => { Console.WriteLine($"{e}"); }},
      {typeof(GpvtgMessage), () => { Console.WriteLine($"{e}"); }},
      {typeof(GpgsvMessage), () => { Console.WriteLine($"{e}(GPS)"); }},
      {typeof(GlgsvMessage), () => { Console.WriteLine($"{e}(Glosnass)"); }},
      {typeof(GbgsvMessage), () => { Console.WriteLine($"{e}(Baidoo)"); }},
    };

    msgActions[e.GetType()]();
  }

  private void NmeaSentenceReceived(object sender, NmeaSentence e)
  {
    _parser.Parse(e.Sentence);
  }
}
