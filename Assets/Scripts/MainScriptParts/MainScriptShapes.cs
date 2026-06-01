using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public partial class MainScript2
{
    void NewShape()
    {
        if (clone != null)
        {
            Destroy(clone);
        }
        int random = Random.Range(0, 9);
        if (random + 1 == lastshape)
        {
            NewShape();
            return;
        }
        shape.transform.localScale = new Vector3(0, 0, 0);
        shape.SetActive(false);

        if (gameover == 0)
        {
            if (currentch == 3 || currentch == 5 || currentch == 12 || currentch == 15 || currentch == 18)
            {
                random = lastshape - 1;
            }
            else
            {
                same = 0;
            }
        }

        ShapeActive();

        int dir = 0;
        if (random == 0)
        {
            shape = sn1;

            dir = 1;
            lastshape = 1;
        }
        else if (random == 1)
        {
            shape = sn2;

            dir = 0;
            lastshape = 2;
        }
        else if (random == 2)
        {
            shape = sn3;

            dir = 0;
            lastshape = 3;
        }
        else if (random == 3)
        {
            shape = sn4;

            dir = 2;
            lastshape = 4;
        }
        else if (random == 4)
        {
            shape = sn5;

            dir = 0;
            lastshape = 5;
        }
        else if (random == 5)
        {
            shape = sn6;

            dir = 0;
            lastshape = 6;
        }
        else if (random == 6)
        {
            shape = sn7;

            dir = 0;
            lastshape = 7;
        }
        else if (random == 7)
        {
            shape = sn8;

            dir = 1;
            lastshape = 8;
        }
        else if (random == 8)
        {
            shape = sn9;

            dir = 0;
            lastshape = 9;
        }

        ShapeUnActive();

        shape.SetActive(true);
        shape.transform.localScale = new Vector3(1, 1, 1);

        shape.GetComponent<PolygonCollider2D>().enabled = false;
        shape.GetComponent<PolygonCollider2D>().enabled = true;
        pencil2.GetComponent<Animator>().Play(0, -1, 0);

        nshape = 1;
        pen.transform.localScale = new Vector3(50, 50, 50);

        int checkw = 0;
        if (dir == 0)
        {
            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2.3f) * ScreenScale.x, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
            end.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.localPosition.z);
        }
        else if (dir == 1)
        {
            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
            end.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
        }
        else if (dir == 2)
        {
            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
            end.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.localPosition.z);
        }
        else if (dir == 3)
        {
            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.localPosition.z);
            end.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2.3f) * ScreenScale.x, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
        }
        if (dir < 2)
        {
            for (float i = 0.2f; i < shape.GetComponent<RectTransform>().sizeDelta.x * ScreenScale.x; i += 0.2f)
            {
                if (checkw == 0)
                {
                    if (dir == 0)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x + i, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, shape.transform.localPosition.z), Vector2.zero);
                        if (hit)
                        {
                            checkw = 1;
                            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x + i, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.localPosition.z);

                        }
                    }
                    else if (dir == 1)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x + i, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.2f) * ScreenScale.y, shape.transform.localPosition.z), Vector2.zero);
                        if (hit)
                        {
                            checkw = 1;
                            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x + i, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.2f) * ScreenScale.y, pen.transform.localPosition.z);

                        }
                    }

                }
            }
        }
        else
        {
            for (float i = shape.GetComponent<RectTransform>().sizeDelta.x * ScreenScale.x; i > 0.2f; i -= 0.2f)
            {
                if (checkw == 0)
                {
                    if (dir == 2)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector3((shape.transform.position.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x - i, (shape.transform.position.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, shape.transform.position.z), Vector2.zero);
                        if (hit)
                        {
                            checkw = 1;
                            pen.transform.position = new Vector3((shape.transform.position.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x - i, (shape.transform.position.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.position.z);

                        }
                    }
                    else if (dir == 3)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector3((shape.transform.position.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x - i, (shape.transform.position.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.2f) * ScreenScale.y, shape.transform.position.z), Vector2.zero);
                        if (hit)
                        {
                            checkw = 1;
                            pen.transform.position = new Vector3((shape.transform.position.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x - i, (shape.transform.position.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.2f) * ScreenScale.y, pen.transform.position.z);

                        }
                    }

                }
            }
        }

        penloc = GameObject.Find("penloc");
        pen.transform.position = new Vector3(penloc.transform.position.x, penloc.transform.position.y, pen.transform.position.z);

        penloc2 = GameObject.Find("penloc2");
        penloc2.transform.GetComponent<BoxCollider>().enabled = false;
        penloc2.transform.GetComponent<BoxCollider>().enabled = true;

        MouseDrag script = (MouseDrag)pen.GetComponent(typeof(MouseDrag));
        script.drag = 1;

        if (redraw == 0)
        {
            DrawLine script2 = (DrawLine)pen.GetComponent(typeof(DrawLine));
            script2.StartCoroutine(script2.Replay());
            redraw = 1;
        }

        if (currentch != 2 && currentch != 10 && currentch != 14)
        {
            time = 31;
        }
        else if (currentch == 2 && settime == 1)
        {
            time = 41;
        }
        else if (currentch == 10 && settime == 1)
        {
            time = 501;
        }
        else if (currentch == 14 && settime == 1)
        {
            time = 801;
        }

        settime = 0;
        gameover = 0;
    }

    void ShapeActive()
    {
        sn1.SetActive(true);
        sn2.SetActive(true);
        sn3.SetActive(true);
        sn4.SetActive(true);
        sn5.SetActive(true);
        sn6.SetActive(true);
        sn7.SetActive(true);
        sn8.SetActive(true);
        sn9.SetActive(true);
    }

    void ShapeUnActive()
    {
        if (sn1 != shape)
        {
            sn1.SetActive(false);
        }
        if (sn2 != shape)
        {
            sn2.SetActive(false);
        }
        if (sn3 != shape)
        {
            sn3.SetActive(false);
        }
        if (sn4 != shape)
        {
            sn4.SetActive(false);
        }
        if (sn5 != shape)
        {
            sn5.SetActive(false);
        }
        if (sn6 != shape)
        {
            sn6.SetActive(false);
        }
        if (sn7 != shape)
        {
            sn7.SetActive(false);
        }
        if (sn8 != shape)
        {
            sn8.SetActive(false);
        }
        if (sn9 != shape)
        {
            sn9.SetActive(false);
        }
    }
}
