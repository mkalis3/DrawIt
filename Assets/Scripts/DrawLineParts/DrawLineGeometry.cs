using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public partial class DrawLine
{
    private bool LineCollides()
    {
        if (pointsList.Count < 2)
            return false;
        int TotalLines = pointsList.Count - 1;
        LineSegment[] lines = new LineSegment[TotalLines];
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
            LineSegment currentLine;
            currentLine.StartPoint = (Vector3)pointsList[pointsList.Count - 2];
            currentLine.EndPoint = (Vector3)pointsList[pointsList.Count - 1];
            if (LinesIntersect(lines[i], currentLine))
                return true;
        }
        return false;
    }

    private bool SamePoint(Vector3 pointA, Vector3 pointB)
    {
        return (pointA.x == pointB.x && pointA.y == pointB.y);
    }

    private bool LinesIntersect(LineSegment first, LineSegment second)
    {
        if (SamePoint(first.StartPoint, second.StartPoint) ||
            SamePoint(first.StartPoint, second.EndPoint) ||
            SamePoint(first.EndPoint, second.StartPoint) ||
            SamePoint(first.EndPoint, second.EndPoint))
            return false;

        return ((Mathf.Max(first.StartPoint.x, first.EndPoint.x) >= Mathf.Min(second.StartPoint.x, second.EndPoint.x)) &&
            (Mathf.Max(second.StartPoint.x, second.EndPoint.x) >= Mathf.Min(first.StartPoint.x, first.EndPoint.x)) &&
            (Mathf.Max(first.StartPoint.y, first.EndPoint.y) >= Mathf.Min(second.StartPoint.y, second.EndPoint.y)) &&
            (Mathf.Max(second.StartPoint.y, second.EndPoint.y) >= Mathf.Min(first.StartPoint.y, first.EndPoint.y))
        );
    }
}
