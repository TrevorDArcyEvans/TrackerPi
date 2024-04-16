namespace TrackerPi;

using CircularBuffer;

public static class WeightedMovingAverageExtension
{
  public static double WeightedMovingAverage<T>(this CircularBuffer<T> current, Func<T, double> valFunc)
  {
    var wvals = 0d;
    var count = current.Count();
    for (var i = 0; i < count; i++)
    {
      wvals += valFunc(current[i]) * (count - i);
    }

    var wweights = (count + 1) * count / 2;

    return wvals / wweights;
  }
}
