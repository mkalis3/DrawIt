using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public partial class DrawLine
{
    void Start()
    {
        maincamera = GameObject.Find("Main Camera2");
        pen = GameObject.Find("pen");
        play2 = GameObject.Find("play2");
        shape = GameObject.Find("shape");
        itext = GameObject.Find("itext");

        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
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

}
