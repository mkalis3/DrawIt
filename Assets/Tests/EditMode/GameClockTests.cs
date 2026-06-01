using NUnit.Framework;

public class GameClockTests
{
    [TestCase(0, "00:00")]
    [TestCase(9, "00:09")]
    [TestCase(60, "01:00")]
    [TestCase(500, "08:20")]
    public void FormatSecondsReturnsClockText(int seconds, string expected)
    {
        Assert.AreEqual(expected, GameClock.FormatSeconds(seconds));
    }

    [Test]
    public void FormatSecondsClampsNegativeInput()
    {
        Assert.AreEqual("00:00", GameClock.FormatSeconds(-5));
    }
}
