using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseDrag : MonoBehaviour
{

    Vector3 startp, lastpos;
    public int drag, pressed;
    GameObject pen;

    void Start()
    {
        pen = GameObject.Find("pen");
    }

    void OnMouseDrag()
    {
        DrawLine script = (DrawLine)pen.GetComponent(typeof(DrawLine));
        if (drag == 1 && script.draw == 1 && script.isMousePressed == true)
        {
            if (pressed == 0)
            {
                pressed = 1;
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
                Vector3 objPosition = GameObject.Find("Main Camera2").GetComponent<Camera>().ScreenToWorldPoint(mousePosition);
                objPosition.z = transform.position.z;
                startp = objPosition;
                transform.position = new Vector3(transform.position.x + (startp.x - objPosition.x) * ScreenScale.x, transform.position.y + (startp.y - objPosition.y) * ScreenScale.y, transform.position.z);
                lastpos = objPosition;
            }
            else
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
                Vector3 objPosition = GameObject.Find("Main Camera2").GetComponent<Camera>().ScreenToWorldPoint(mousePosition);
                objPosition.z = transform.position.z;
                transform.position = new Vector3(transform.position.x + (lastpos.x - objPosition.x), transform.position.y + (lastpos.y - objPosition.y), transform.position.z);
                lastpos = objPosition;
            }
        }
    }

    void OnMouseUp()
    {
        pressed = 0;
    }

    CanvasScaler canvasScaler;
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
