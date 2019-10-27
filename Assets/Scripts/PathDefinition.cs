using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class PathDefinition : MonoBehaviour
{

    public Transform[] points;//set of path points

    public IEnumerator<Transform> GetPathsEnumerator()
    {//
        if (points == null || points.Length < 1)
            yield break;
        var direction = 1;//direction of moving
        int index = 0;
        while (true)
        {
            yield return points[index];
            if (points.Length == 1)
                continue;
            if (index <= 0)
                direction = 1;
            else if (index >= points.Length - 1)
                direction = -1;
            index = index + direction;
        }
    }

    public void OnDrawGizmos()
    {//overwrite 
        if (points == null || points.Length < 2)
            return;
        var pt = points.Where(t => t != null).ToList();
        if (pt.Count < 2)
            return;
        for (int i = 1; i < pt.Count; i++)
        {
            Gizmos.DrawLine(pt[i - 1].position, pt[i].position);
        }
    }
}


