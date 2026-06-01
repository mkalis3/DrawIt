using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public partial class MainScript2
{
    string FormatTimer(int sec)
    {
        return GameClock.FormatSeconds(sec);
    }

    void ApplyCameraAspect()
    {

        float targetaspect = 16.0f / 9.0f;

        float windowaspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = windowaspect / targetaspect;

        Camera camera = maincamera.GetComponent<Camera>();

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    public static bool TouchRelease()
    {
        bool b = false;
        for (int i = 0; i < Input.touches.Length; i++)
        {
            b = Input.touches[i].phase == TouchPhase.Ended;
            if (b)
                break;
        }
        if(Input.GetMouseButtonUp(0))
        {
            b = true;
        }
        return b;
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

    public static string ColorToHex(Color32 color)
    {
        return ColorHex.FromColor(color);
    }
}
