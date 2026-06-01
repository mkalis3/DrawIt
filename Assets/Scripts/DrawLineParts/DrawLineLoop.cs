using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public partial class DrawLine
{
    void LateUpdate()
    {

        if (draw == 1)
        {
            if (Input.GetMouseButton(0))
            {
                MainScript2 script = (MainScript2)maincamera.GetComponent(typeof(MainScript2));
                shape = script.shape;
                shape.layer = 2;
                shape.layer = 0;
                mousePos = maincamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
                maw = pen.transform.localPosition.x * ScreenScale.x;
                may = pen.transform.localPosition.y * ScreenScale.y;
                maz = pen.transform.localPosition.z;
                pen.layer = 2;
                RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(maw, may), Vector2.zero);

                if (!hit2)
                {
                    Strike();

                }
                pen.layer = 0;
                if (isMousePressed == true)
                {
                    if (shape == null)
                    {
                        shape = GameObject.Find("shape");
                    }

                    float sx = shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2 - (shape.GetComponent<RectTransform>().sizeDelta.x / 2) / 10;
                    float sy = shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2 - (shape.GetComponent<RectTransform>().sizeDelta.y / 2) / 10;

                    float shsx, shsy, shsx2, shsy2;
                    shsx = shape.GetComponent<RectTransform>().sizeDelta.x / 2;
                    shsy = shape.GetComponent<RectTransform>().sizeDelta.y / 2;
                    shsx2 = shape.GetComponent<RectTransform>().sizeDelta.x / 10;
                    shsy2 = shape.GetComponent<RectTransform>().sizeDelta.y / 10;

                    for (int i = 0; i < 9; i++)
                    {
                        if (i < 8)
                        {
                            if (pen.transform.position.x > (shape.transform.position.x - shsx) + (shsx2 * (i + 1)) && pen.transform.position.x < (shape.transform.position.x - shsx) + (shsx2 * (i + 2)) && shx[i + 1] == 0)
                            {
                                shx[i + 1] = 1;
                                tshx++;
                            }
                            if (pen.transform.position.y > (shape.transform.position.y - shsy) + (shsy2 * (i + 1)) && pen.transform.position.y < (shape.transform.position.y - shsy) + (shsy2 * (i + 2)) && shy[i + 1] == 0)
                            {
                                shy[i + 1] = 1;
                                tshy++;
                            }
                        }
                        else
                        {
                            if (pen.transform.position.x > (shape.transform.position.x - shsx) + (shsx2 * (i + 1)) && shx[i + 1] == 0)
                            {
                                shx[i + 1] = 1;
                                tshx++;
                            }
                            if (pen.transform.position.y > (shape.transform.position.y - shsy) + (shsy2 * (i + 1)) && shy[i + 1] == 0)
                            {
                                shy[i + 1] = 1;
                                tshy++;
                            }
                        }
                    }

                }
                if (Application.platform == RuntimePlatform.Android)
                {

                    if (Input.touchCount > 0)
                    {
                        if (Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                            isMousePressed = true;

                            mpx = pen.transform.localPosition.x;
                            mpy = pen.transform.localPosition.y;
                            lpx = pen.transform.localPosition.x;
                            lpy = pen.transform.localPosition.y;
                            lpz = pen.transform.localPosition.z;
                        }

                        if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        {
                            isMousePressed = false;
                        }

                        if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        {
                            mousePos2 = new Vector3(maw, may, maz);
                            if (!pointsList.Contains(mousePos2))
                            {
                                pointsList.Add(mousePos2);
                                pointsList2.Add(mousePos2);
                                line.SetVertexCount(pointsList.Count);
                                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);

                                if (LineCollides())
                                {
                                    Strike();
                                }
                            }
                        }
                    }
                }
                else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        isMousePressed = true;

                        mpx = pen.transform.localPosition.x;
                        mpy = pen.transform.localPosition.y;
                        lpx = pen.transform.localPosition.x;
                        lpy = pen.transform.localPosition.y;
                        lpz = pen.transform.localPosition.z;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        isMousePressed = false;
                    }

                    if (isMousePressed)
                    {
                        mousePos2 = new Vector3(maw, may, maz);
                        if (!pointsList.Contains(mousePos2))
                        {
                            pointsList.Add(mousePos2);
                            pointsList2.Add(mousePos2);
                            line.SetVertexCount(pointsList.Count);
                            line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);

                            if (LineCollides())
                            {
                                Strike();
                            }
                        }
                    }
                }
                lpx = mousePos.x;
                lpy = mousePos.y;
                lpz = mousePos.z;
            }
        }
    }
}
