using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{
    public float rate = 0.2f; 
    public GameObject bullet;
    private Transform parent;
    // Use this for initialization

    void Start()
    {
        parent = this.transform.GetComponentInParent<Transform>();
    }

    public void Fire()
    {
        if (parent.localScale.x > 0)
        {
            GameObject bullteMove = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(5, 0, 0))) as GameObject;
            bullteMove.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
            Destroy(bullteMove, 0.5f);
        }
        if (parent.localScale.x < 0)
        {
            GameObject bullteMove = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(-5, 180, 0))) as GameObject;
            bullteMove.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 500);
            Destroy(bullteMove, 0.5f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Fire();
            //InvokeRepeating(methodName: "Fire", time: 1, repeatRate: rate);
        }
    }
}
