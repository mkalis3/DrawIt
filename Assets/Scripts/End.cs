using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    GameObject pen;
    private void Start()
    {
        pen = GameObject.Find("pen"); 
    }
    void OnCollisionEnter(Collision coll)
    {
        print("hit " + coll.transform.name);
        if (coll.transform.name.Contains("pen"))
        {
            DrawLine script = (DrawLine)pen.GetComponent(typeof(DrawLine));
            script.Pass();
        }
    }
}
