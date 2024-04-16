using FluentAssertions;

namespace TrackerPi.Tests;

using CircularBuffer;

[TestFixture]
public sealed class WeightedMovingAverageExtension_Tests
{
  private CircularBuffer<int> _data = new(10);

  [SetUp]
  public void Setup()
  {
    _data.Clear();
  }

  [Test]
  public void WeightedMovingAverage_5_returns_expected()
  {
    _data.PushBack(5);
    _data.PushBack(4);
    _data.PushBack(3);
    _data.PushBack(2);
    _data.PushBack(1);

    var res = _data.WeightedMovingAverage(x => x);

    res.Should().BeApproximately(3.6667, 0.001);
  }

  [Test]
  public void WeightedMovingAverage_6_returns_expected()
  {
    _data.PushBack(6);
    _data.PushBack(5);
    _data.PushBack(4);
    _data.PushBack(3);
    _data.PushBack(2);
    _data.PushBack(1);

    var res = _data.WeightedMovingAverage(x => x);

    res.Should().BeApproximately(4.3333, 0.001);
  }

  [Test]
  public void WeightedMovingAverage_9_returns_expected()
  {
    _data.PushBack(10);
    _data.PushBack(9);
    _data.PushBack(8);
    _data.PushBack(7);
    _data.PushBack(6);
    _data.PushBack(5);
    _data.PushBack(4);
    _data.PushBack(3);
    _data.PushBack(2);

    var res = _data.WeightedMovingAverage(x => x);

    res.Should().BeApproximately(7.3333, 0.001);
  }

  [Test]
  public void WeightedMovingAverage_11_returns_expected()
  {
    _data.PushBack(11);
    _data.PushBack(10);
    _data.PushBack(9);
    _data.PushBack(8);
    _data.PushBack(7);
    _data.PushBack(6);
    _data.PushBack(5);
    _data.PushBack(4);
    _data.PushBack(3);
    _data.PushBack(2);  // data full
    _data.PushBack(1);  // pops off 11

    var res = _data.WeightedMovingAverage(x => x);

    res.Should().BeApproximately(7.0000, 0.001);
  }
}
