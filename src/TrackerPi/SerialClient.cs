namespace TrackerPi;

public abstract class SerialClient
{
  private readonly string _port;

  protected SerialClient(string port)
  {
    _port = port;
  }
}
