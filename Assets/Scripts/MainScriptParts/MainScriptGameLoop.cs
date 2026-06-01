using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public partial class MainScript2
{
    void LateUpdate()
    {
        if (maincamera.transform.eulerAngles.x == 0)
        {
            if (maincamera.GetComponent<Camera>().fieldOfView > 6)
            {
                maincamera.GetComponent<Camera>().fieldOfView = maincamera.GetComponent<Camera>().fieldOfView - 0.6f;
            }
            else
            {
                if (opened == 0 && cover.transform.localEulerAngles.z < 250 && cover.transform.localEulerAngles.z != 0)
                {
                    opened = 1;
                    game.transform.localScale = new Vector3(0, 0, 0);
                    ostrikes.transform.localScale = new Vector3(1, 1, 1);
                    stage = 1;
                    fshape = 0;
                    NewShape();
                    pencil2.transform.localScale = new Vector3(6, 6, 6);
                    pencil2.GetComponent<Animator>().enabled = true;
                    DrawLine script2 = (DrawLine)pen.GetComponent(typeof(DrawLine));
                    script2.draw = 0;
                }
                else if (opened == 1 && play == 4 && cover.transform.localEulerAngles.z < 8)
                {

                    opened = 0;
                    game.transform.localScale = new Vector3(1, 1, 1);
                    ostrikes.transform.localScale = new Vector3(0, 0, 0);
                    stage = 0;
                    pencil2.transform.localScale = new Vector3(0, 0, 0);
                    pencil2.GetComponent<Animator>().enabled = false;
                    showed = 0;

                    play = 0;
                    fail.transform.localScale = new Vector3(0, 0, 0);
                    strikes = 0;
                    strike.GetComponent<Text>().color = new Color(strike.GetComponent<Text>().color.r, strike.GetComponent<Text>().color.g, strike.GetComponent<Text>().color.b, 0.2f);
                    strike2.GetComponent<Text>().color = new Color(strike2.GetComponent<Text>().color.r, strike2.GetComponent<Text>().color.g, strike2.GetComponent<Text>().color.b, 0.2f);
                    strike3.GetComponent<Text>().color = new Color(strike3.GetComponent<Text>().color.r, strike3.GetComponent<Text>().color.g, strike3.GetComponent<Text>().color.b, 0.2f);
                }
                if ((int)cover.transform.localEulerAngles.z == 156 && showed == 0)
                {

                    showed = 1;
                }
                if (play == 1)
                {
                    if (stage == 1)
                    {
                        if (fshape < 1)
                        {
                            fshape += 0.02f;
                            shape.GetComponent<SpriteRenderer>().color = new Color(shape.GetComponent<SpriteRenderer>().color.r, shape.GetComponent<SpriteRenderer>().color.g, shape.GetComponent<SpriteRenderer>().color.b, fshape);
                        }
                        else
                        {
                            stage = 2;
                            pen.transform.localScale = new Vector3(50, 50, 50);
                            cacircle.transform.localScale = new Vector3(2, 0.000000001f, 2);
                            DrawLine script = (DrawLine)pen.GetComponent(typeof(DrawLine));
                            script.StartCoroutine(script.Replay());
                            MouseDrag script2 = (MouseDrag)pen.GetComponent(typeof(MouseDrag));
                            script2.drag = 1;
                        }
                    }
                    else if (stage == 2)
                    {
                        if (time > 0)
                        {
                            ctext.GetComponent<Text>().text = FormatTimer((int)time);
                            time -= Time.deltaTime;
                        }
                        else
                        {
                            Strike();
                        }
                        if (TouchRelease())
                        {
                            if (currentch == 7 || currentch == 11 || currentch == 17 || currentch == 20)
                            {
                                strikes = 2;
                                Strike();
                            }
                        }
                    }
                    else if (stage == 3)
                    {
                        Color fc = fail.GetComponent<Text>().color;
                        float aa = fc.a;
                        if (aa > 0)
                        {
                            fail.GetComponent<Text>().color = new Color(fc.r, fc.g, fc.b, aa - 0.1f);
                        }
                        else
                        {
                            fail.transform.localScale = new Vector3(0, 0, 0);
                            fc = fail.GetComponent<Text>().color;
                            fail.GetComponent<Text>().color = new Color(fc.r, fc.g, fc.b, 1);
                            fshape = 0;
                            stage = 1;
                        }
                    }
                    else if (stage == 4)
                    {

                    }
                    else if (stage == 5)
                    {
                        Color fc = pass.GetComponent<RawImage>().color;
                        float aa = fc.a;
                        if (aa > 0)
                        {
                            pass.GetComponent<RawImage>().color = new Color(fc.r, fc.g, fc.b, aa - 0.1f);
                        }
                        else
                        {
                            pass.transform.localScale = new Vector3(0, 0, 0);
                            fc = pass.GetComponent<RawImage>().color;
                            pass.GetComponent<RawImage>().color = new Color(fc.r, fc.g, fc.b, 1);
                            fshape = 0;
                            stage = 1;
                        }
                    }
                }
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray;
                    ray = maincamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.name == "play2")
                        {
                            Play();
                        }
                        else if (hit.transform.name == "settings2")
                        {
                            Settings();
                        }
                        else if (hit.transform.name == "quit2")
                        {
                            Quit();
                        }
                    }
                }
            }
        }
    }
}
