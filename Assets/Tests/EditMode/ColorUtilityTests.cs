using NUnit.Framework;
using UnityEngine;

public class ColorUtilityTests
{
    [Test]
    public void ColorToHexUsesTwoUppercaseDigitsPerChannel()
    {
        var color = new Color32(10, 27, 44, 255);

        Assert.AreEqual("0A1B2C", ColorHex.FromColor(color));
        Assert.AreEqual("0A1B2C", DrawLine.ColorToHex(color));
        Assert.AreEqual("0A1B2C", MainScript2.ColorToHex(color));
    }
}
