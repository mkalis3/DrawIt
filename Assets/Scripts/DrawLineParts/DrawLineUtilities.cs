using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public partial class DrawLine
{
    public static string ColorToHex(Color32 color)
    {
        return ColorHex.FromColor(color);
    }

    private CanvasScaler canvasScaler;
    Vector2 ScreenScale
    {
        get
        {
            if (canvasScaler == null)
            {
                canvasScaler = GetComponentInParent<CanvasScaler>();
            }

            if (canvasScaler)
            {
                return new Vector2(canvasScaler.referenceResolution.x / Screen.width, canvasScaler.referenceResolution.y / Screen.height);
            }
            else
            {
                return Vector2.one;
            }
        }
    }
}
