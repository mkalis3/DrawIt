using UnityEngine;

public static class ColorHex
{
    public static string FromColor(Color32 color)
    {
        return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
    }
}
