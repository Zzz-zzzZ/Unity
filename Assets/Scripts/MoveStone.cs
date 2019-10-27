﻿
using UnityEngine;
using System.Collections;
using System;

public class MoveStone: MonoBehaviour
{
    public enum State
    {
        Idle,
        Walk,
        Death,


    }
    public Transform[] _MovePoints = new Transform[2];

    public float _WalkSpeed;
    public float _RunSpeed;
    [HideInInspector]
    public bool _Dead;

    private State _state;
    private State _Laststate = State.Idle;
    private Vector3 _TargetPosition;
    private Animator _animator;
    private float _Speed = 2;
    private bool _playerDead = false;
   


    void Start()
    {
        _TargetPosition = _MovePoints[0].position;
        _animator = GetComponent<Animator>();
        
    }
    void FixedUpdate()
    {
        if (_state != State.Death)
        {
            if (_Dead)
            {
                // Debug.Log("111111");
                _state = State.Death;
            }
            else
            {
                MoveAround();
            }
        }

    }
    void MoveAround()
    {


        float _Distance = Vector3.Distance(_TargetPosition, this.transform.position);
        if (_Distance > 1.0f)
        {
            _state = State.Walk;
            //  this.transform.LookAt(_TargetPosition);
            this.transform.Translate(Vector3.right * (-1) * _Speed * Time.deltaTime);

        }
        else
        {

            _state = State.Idle;
            //    _WaitTime -= Time.deltaTime;
            //    if (_WaitTime <= 0.0f)
            //   {
            if (_TargetPosition.x <= _MovePoints[0].position.x)
            {
                _TargetPosition = _MovePoints[1].position;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (_TargetPosition.x >= _MovePoints[1].position.x)
            {
                _TargetPosition = _MovePoints[0].position;
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            //   _WaitTime = _WaitTimer;
            // }
        }

    }


    
    }
