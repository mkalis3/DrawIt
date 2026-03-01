using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    private LineRenderer line;
    public bool isMousePressed;
    public List<Vector3> pointsList;
    public List<Vector3> pointsList2;
    private Vector3 mousePos, mousePos2;
    GameObject maincamera, pen, play2, shape, itext;
    int bnum, drive, tshape, iu, id, ir, il, tshx = 1, tshy = 1;
    public int draw;
    int[] start, end, shx, shy, shx2, shy2, shx3, shy3, shx4, shy4, shx5, shy5, shx6, shy6, shx7, shy7, shx8, shy8, shx9, shy9, shx10, shy10;
    float maw, may, maz, lpx, lpy, lpz, mpx, mpy, mpz;
    Texture2D snapshot;

    // Structure for line points
    struct myLine
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    };

    void Start()
    {
        maincamera = GameObject.Find("Main Camera2");
        pen = GameObject.Find("pen");
        play2 = GameObject.Find("play2");
        shape = GameObject.Find("shape");
        itext = GameObject.Find("itext");

        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
        line.SetVertexCount(0);
        line.SetWidth(0.1f, 0.1f);
        line.SetColors(new Color32(0, 19, 91, 255), new Color32(0, 19, 91, 255));
        line.useWorldSpace = true;
        line.sortingOrder = 5;
        isMousePressed = false;
        pointsList = new List<Vector3>();
        pointsList2 = new List<Vector3>();

        start = new int[5];
        end = new int[5];

        start[0] = 1;
        end[0] = 4;

        shx = new int[10];
        shy = new int[10];
        shx2 = new int[10];
        shy2 = new int[10];
        shx3 = new int[10];
        shy3 = new int[10];
        shx4 = new int[10];
        shy4 = new int[10];
        shx5 = new int[10];
        shy5 = new int[10];
        shx6 = new int[10];
        shy6 = new int[10];
        shx7 = new int[10];
        shy7 = new int[10];
        shx8 = new int[10];
        shy8 = new int[10];
        shx9 = new int[10];
        shy9 = new int[10];
        shx10 = new int[10];
        shy10 = new int[10];

        shx[0] = 1;
        shy[0] = 1;
        shx2[0] = 1;
        shy2[0] = 1;
        shx3[0] = 1;
        shy3[0] = 1;
        shx4[0] = 1;
        shy4[0] = 1;
        shx5[0] = 1;
        shy5[0] = 1;
        shx6[0] = 1;
        shy6[0] = 1;
        shx7[0] = 1;
        shy7[0] = 1;
        shx8[0] = 1;
        shy8[0] = 1;
        shx9[0] = 1;
        shy9[0] = 1;
        shx10[0] = 1;
        shy10[0] = 1;
    }


    //	-----------------------------------	
    void LateUpdate()
    {
        // If mouse button down, remove old line and set its color to green
        if (draw == 1)
        {
            if (Input.GetMouseButton(0))
            {
                float mox = 0, moy = 0, moz = 0;
                Vector2 worldPoint = maincamera.GetComponent<Camera>().ScreenToWorldPoint(pen.transform.localPosition);
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
                //Debug.DrawLine(new Vector3(maw, may,maz), hit2.point, Color.red);
                if (!hit2)
                {
                    Strike();
                    //itext.GetComponent<Text>().text = "no " + ScreenScale.x + "  " + ScreenScale.y;
                }
                else
                {
                    //itext.GetComponent<Text>().text = "yes " + ScreenScale.x + "  " + ScreenScale.y;
                }
                pen.layer = 0;
                //print ("ok2" + isMousePressed + " " + Time.fixedTime);
                if (isMousePressed == true)
                {// && draw == 1) {
                 //print("ok3" + " " + Time.fixedTime);
                    if (shape == null)  
                    {
                        shape = GameObject.Find("shape");
                    }
                    //pen.transform.localPosition = new Vector3 (pen.transform.localPosition.x + mox, pen.transform.localPosition.y + moy, pen.transform.localPosition.z + moz);
                    //print("ok4 " + mox + " " + moy);
                    float sx = shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2 - (shape.GetComponent<RectTransform>().sizeDelta.x / 2) / 10;
                    float sy = shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2 - (shape.GetComponent<RectTransform>().sizeDelta.y / 2) / 10;

                    float shsx, shsy, shsx2, shsy2;
                    shsx = shape.GetComponent<RectTransform>().sizeDelta.x / 2;
                    shsy = shape.GetComponent<RectTransform>().sizeDelta.y / 2;
                    shsx2 = shape.GetComponent<RectTransform>().sizeDelta.x / 10;
                    shsy2 = shape.GetComponent<RectTransform>().sizeDelta.y / 10;

                    //StartCoroutine(TakeSnapshot(Screen.width,Screen.height));

                    if (snapshot != null)
                    {
                        int count = 0, count2 = 0;
                        Color32[] colors = snapshot.GetPixels32();

                        //print(colors.Length);
                        for (int i = 0; i < colors.Length; i++)
                        {
                            if (colorToHex(colors[i]) == "ABACAC")
                            {
                                //print(i + " true");
                                count++;
                            }
                        }

                        print(count);
                    }

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

                    /*if (tshx >= 9 && tshy >= 9)
                    {
                        draw = 0;
                        isMousePressed = false;
                        pen.transform.localScale = new Vector3(1, 1, 1);
                        line.SetVertexCount(0);
                        pointsList.RemoveRange(0, pointsList.Count);
                        pointsList2.RemoveRange(0, pointsList2.Count);
                        script.GivePoints();
                        tshx = 1;
                        shx = new int[10];
                        shy = new int[10];
                        shx2 = new int[10];
                        shy2 = new int[10];
                        shx3 = new int[10];
                        shy3 = new int[10];
                        shx4 = new int[10];
                        shy4 = new int[10];
                        shx5 = new int[10];
                        shy5 = new int[10];
                        shx6 = new int[10];
                        shy6 = new int[10];
                        shx7 = new int[10];
                        shy7 = new int[10];
                        shx8 = new int[10];
                        shy8 = new int[10];
                        shx9 = new int[10];
                        shy9 = new int[10];
                        shx10 = new int[10];
                        shy10 = new int[10];

                        shx[0] = 1;
                        shy[0] = 1;
                        shx2[0] = 1;
                        shy2[0] = 1;
                        shx3[0] = 1;
                        shy3[0] = 1;
                        shx4[0] = 1;
                        shy4[0] = 1;
                        shx5[0] = 1;
                        shy5[0] = 1;
                        shx6[0] = 1;
                        shy6[0] = 1;
                        shx7[0] = 1;
                        shy7[0] = 1;
                        shx8[0] = 1;
                        shy8[0] = 1;
                        shx9[0] = 1;
                        shy9[0] = 1;
                        shx10[0] = 1;
                        shy10[0] = 1;
                    }*/

                    /*if (end [tshape] == 1) {
                        if (maw <= sx && may >= sy) {
                            draw = 0;
                            pen.transform.localScale = new Vector3 (1, 1, 1);
                            line.SetVertexCount (0);
                            pointsList.RemoveRange (0, pointsList.Count);
                            pointsList2.RemoveRange (0, pointsList2.Count);
                            StartCoroutine (Redraw ());
                            MainScript2 script = (MainScript2)maincamera.GetComponent (typeof(MainScript2));
                            script.GivePoints ();
                        }
                    }
                    else if (end [tshape] == 2) {
                        if (maw >= sx && may >= sy) {
                            draw = 0;
                            pen.transform.localScale = new Vector3(1, 1, 1);
                            line.SetVertexCount (0);
                            pointsList.RemoveRange (0, pointsList.Count);
                            pointsList2.RemoveRange (0, pointsList2.Count);
                            StartCoroutine (Redraw ());
                            MainScript2 script = (MainScript2)maincamera.GetComponent (typeof(MainScript2));
                            script.GivePoints ();
                        }
                    }
                    else if (end [tshape] == 3) {
                        if (maw <= sx && may <= sy) {
                            draw = 0;
                            pen.transform.localScale = new Vector3(1, 1, 1);
                            line.SetVertexCount (0);
                            pointsList.RemoveRange (0, pointsList.Count);
                            pointsList2.RemoveRange (0, pointsList2.Count);
                            StartCoroutine (Redraw ());
                            MainScript2 script = (MainScript2)maincamera.GetComponent (typeof(MainScript2));
                            script.GivePoints ();
                        }
                    }
                    else if (end [tshape] == 4) {
                        if (maw >= sx && may <= sy) {
                            draw = 0;
                            pen.transform.localScale = new Vector3(1, 1, 1);
                            line.SetVertexCount (0);
                            pointsList.RemoveRange (0, pointsList.Count);
                            pointsList2.RemoveRange (0, pointsList2.Count);
                            StartCoroutine (Redraw ());
                            MainScript2 script = (MainScript2)maincamera.GetComponent (typeof(MainScript2));
                            script.GivePoints ();
                        }
                    }*/
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    //text.GetComponent<Text> ().text = "count " + Input.touchCount;
                    if (Input.touchCount > 0)
                    {
                        if (Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                            isMousePressed = true;
                            //line.SetVertexCount (0);
                            //pointsList.RemoveRange (0, pointsList.Count);
                            //pointsList2.RemoveRange (0, pointsList2.Count);
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
                        // Drawing line when mouse is moving(presses)
                        if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        {
                            mousePos2 = new Vector3(maw, may, maz);
                            if (!pointsList.Contains(mousePos2))
                            {
                                pointsList.Add(mousePos2);
                                pointsList2.Add(mousePos2);
                                line.SetVertexCount(pointsList.Count);
                                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
                                //StartCoroutine (BikeMove ());
                                if (isLineCollide())
                                {
                                    //isMousePressed = false;
                                    //line.SetColors (Color.red, Color.red);
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
                        //line.SetVertexCount (0);
                        //	pointsList.RemoveRange (0, pointsList.Count);
                        //pointsList2.RemoveRange (0, pointsList.Count);
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
                    // Drawing line when mouse is moving(presses)
                    if (isMousePressed)
                    {
                        mousePos2 = new Vector3(maw, may, maz);
                        if (!pointsList.Contains(mousePos2))
                        {
                            pointsList.Add(mousePos2);
                            pointsList2.Add(mousePos2);
                            line.SetVertexCount(pointsList.Count);
                            line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
                            //StartCoroutine (BikeMove ());
                            if (isLineCollide())
                            {
                                //isMousePressed = false;
                                //line.SetColors (Color.red, Color.red);
                            }
                        }
                    }
                }
                lpx = mousePos.x;
                lpy = mousePos.y;
                lpz = mousePos.z;
                //print("ok4 " + lpx + " " + lpy);
            }
        }
    }

    public IEnumerator TakeSnapshot(int width, int height)
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, true);
        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        texture.Apply();
        snapshot = texture;
    }

    public void Pass()
    {
        draw = 0;
        isMousePressed = false;
        pen.transform.localScale = new Vector3(1, 1, 1);
        line.SetVertexCount(0);
        pointsList.RemoveRange(0, pointsList.Count);
        pointsList2.RemoveRange(0, pointsList2.Count);
        MainScript2 script = (MainScript2)maincamera.GetComponent(typeof(MainScript2));
        script.GivePoints();
        tshx = 1;
    }

    public void Strike()
    {
        MainScript2 script = (MainScript2)maincamera.GetComponent(typeof(MainScript2));
        if (script.stage == 2)
        {
            draw = 0;
            isMousePressed = false;
            tshx = 1;
            shx = new int[10];
            shy = new int[10];
            shx2 = new int[10];
            shy2 = new int[10];
            shx3 = new int[10];
            shy3 = new int[10];
            shx4 = new int[10];
            shy4 = new int[10];
            shx5 = new int[10];
            shy5 = new int[10];
            shx6 = new int[10];
            shy6 = new int[10];
            shx7 = new int[10];
            shy7 = new int[10];
            shx8 = new int[10];
            shy8 = new int[10];
            shx9 = new int[10];
            shy9 = new int[10];
            shx10 = new int[10];
            shy10 = new int[10];

            shx[0] = 1;
            shy[0] = 1;
            shx2[0] = 1;
            shy2[0] = 1;
            shx3[0] = 1;
            shy3[0] = 1;
            shx4[0] = 1;
            shy4[0] = 1;
            shx5[0] = 1;
            shy5[0] = 1;
            shx6[0] = 1;
            shy6[0] = 1;
            shx7[0] = 1;
            shy7[0] = 1;
            shx8[0] = 1;
            shy8[0] = 1;
            shx9[0] = 1;
            shy9[0] = 1;
            shx10[0] = 1;
            shy10[0] = 1;

            pen.transform.localScale = new Vector3(50, 50, 50);
            line.SetVertexCount(0);
            pointsList.RemoveRange(0, pointsList.Count);
            pointsList2.RemoveRange(0, pointsList2.Count);
            script.Strike();
        }
    }

    public void StopDraw()
    {
        draw = 0;
        isMousePressed = false;
        pen.transform.localScale = new Vector3(0, 0, 0);
    }

    public void Play()
    {
        drive = 1;
        play2.transform.localScale = new Vector3(0, 0, 0);
    }

    public IEnumerator Replay()
    {
        yield return new WaitForSeconds(0.1f);
        drive = 0;
        bnum = 0;
        line.SetVertexCount(0);
        pointsList.RemoveRange(0, pointsList.Count);
        pointsList2.RemoveRange(0, pointsList2.Count);
        lpx = 0;
        lpy = 0;
        isMousePressed = false;
        if (start[tshape] == 1)
        {
            //pen.transform.localPosition = new Vector3 (-shape.GetComponent<RectTransform> ().sizeDelta.x/1.2f, shape.GetComponent<RectTransform> ().sizeDelta.y/1.3f, 0);
        }
        MainScript2 script = (MainScript2)maincamera.GetComponent(typeof(MainScript2));
        script.redraw = 0;
        draw = 1;
    }


    //	-----------------------------------	
    //  Following method checks is currentLine(line drawn by last two points) collided with line 
    //	-----------------------------------	
    private bool isLineCollide()
    {
        if (pointsList.Count < 2)
            return false;
        int TotalLines = pointsList.Count - 1;
        myLine[] lines = new myLine[TotalLines];
        if (TotalLines > 1)
        {
            for (int i = 0; i < TotalLines; i++)
            {
                lines[i].StartPoint = (Vector3)pointsList[i];
                lines[i].EndPoint = (Vector3)pointsList[i + 1];
            }
        }
        for (int i = 0; i < TotalLines - 1; i++)
        {
            myLine currentLine;
            currentLine.StartPoint = (Vector3)pointsList[pointsList.Count - 2];
            currentLine.EndPoint = (Vector3)pointsList[pointsList.Count - 1];
            if (isLinesIntersect(lines[i], currentLine))
                return true;
        }
        return false;
    }
    //	-----------------------------------	
    //	Following method checks whether given two points are same or not
    //	-----------------------------------	
    private bool checkPoints(Vector3 pointA, Vector3 pointB)
    {
        return (pointA.x == pointB.x && pointA.y == pointB.y);
    }
    //	-----------------------------------	
    //	Following method checks whether given two line intersect or not
    //	-----------------------------------	
    private bool isLinesIntersect(myLine L1, myLine L2)
    {
        if (checkPoints(L1.StartPoint, L2.StartPoint) ||
            checkPoints(L1.StartPoint, L2.EndPoint) ||
            checkPoints(L1.EndPoint, L2.StartPoint) ||
            checkPoints(L1.EndPoint, L2.EndPoint))
            return false;

        return ((Mathf.Max(L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min(L2.StartPoint.x, L2.EndPoint.x)) &&
            (Mathf.Max(L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min(L1.StartPoint.x, L1.EndPoint.x)) &&
            (Mathf.Max(L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min(L2.StartPoint.y, L2.EndPoint.y)) &&
            (Mathf.Max(L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min(L1.StartPoint.y, L1.EndPoint.y))
        );
    }

    public static string colorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
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