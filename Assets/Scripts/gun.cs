using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float rate = 0.2f;
    public GameObject bullet;
    // Use this for initialization

    void Start () {
        
	}
	
    public void Fire()
    {
        GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Fire();
            //InvokeRepeating(methodName: "Fire", time: 1, repeatRate: rate);
        }
    }
}
