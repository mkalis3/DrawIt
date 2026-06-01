using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public partial class DrawLine
{
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

        }
        MainScript2 script = (MainScript2)maincamera.GetComponent(typeof(MainScript2));
        script.redraw = 0;
        draw = 1;
    }

}
