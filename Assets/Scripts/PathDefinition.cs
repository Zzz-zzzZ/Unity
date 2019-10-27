using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class PathDefinition : MonoBehaviour
{

    public Transform[] points;//路径点集合

    public IEnumerator<Transform> GetPathsEnumerator()
    {//自定义迭代器(用来返回路径点)
        if (points == null || points.Length < 1)
            yield break;
        var direction = 1;//移动方向
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
    {//重写OnDrawGizmos实现在scene视图中画线
        if (points == null || points.Length < 2)
            return;
        var pt = points.Where(t => t != null).ToList();//使用的Linq语言集成查询，找出路径点集合中不为空的点
        if (pt.Count < 2)
            return;
        for (int i = 1; i < pt.Count; i++)
        {
            Gizmos.DrawLine(pt[i - 1].position, pt[i].position);//画线
        }
    }
}


