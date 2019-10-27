using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FollowPath : MonoBehaviour
{

    public enum FollowType
    {//定义一个移动类型的枚举
        MoveTowards,
        Lerp
    }

    public FollowType type = FollowType.MoveTowards;//默认为直接朝向移动
    public PathDefinition path;
    public float speed = 1;//移动速度
    public float maxDistanceTOGoal = .1f;//判断物体是否到达某个路径点

    private IEnumerator<Transform> _currentPoint;//声明一个迭代器

    void Start()
    {
        if (path == null)
        {
            Debug.Log("Path cannot be null", gameObject);
            return;
        }
        _currentPoint = path.GetPathsEnumerator();//获得迭代器实例
        _currentPoint.MoveNext();//MoveNext ()会执行代码到迭代器中yiled 语句处停止(包括yiled 语句)
        if (_currentPoint.Current == null)//Current代表迭代器当前返回值
            return;
        transform.position = _currentPoint.Current.position;//默认物体初始位置为路径点的第一个位置
    }

    void Update()
    {
        if (_currentPoint == null || _currentPoint.Current == null)
            return;
        if (type == FollowType.MoveTowards)
        {//使用Vector3.MoveTowards移动
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }
        else if (type == FollowType.Lerp)
        {//使用Vector3.Lerp移动
            transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }
        var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
        if (distanceSquared < maxDistanceTOGoal * maxDistanceTOGoal)//如果物体与某个路径点的距离的平方小于规定的最大值，则获取下一个路径点
            _currentPoint.MoveNext();
    }
}

