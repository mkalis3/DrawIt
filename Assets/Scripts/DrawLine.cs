using UnityEngine;
using System.Collections.Generic;

public partial class DrawLine : MonoBehaviour
{
    private LineRenderer line;
    public bool isMousePressed;
    private List<Vector3> pointsList;
    private List<Vector3> pointsList2;
    private Vector3 mousePos, mousePos2;
    private GameObject maincamera, pen, play2, shape, itext;
    private int bnum, drive, tshape, iu, id, ir, il, tshx = 1, tshy = 1;
    public int draw;
    private int[] start, end, shx, shy, shx2, shy2, shx3, shy3, shx4, shy4, shx5, shy5, shx6, shy6, shx7, shy7, shx8, shy8, shx9, shy9, shx10, shy10;
    private float maw, may, maz, lpx, lpy, lpz, mpx, mpy, mpz;

    private struct LineSegment
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    }
}
