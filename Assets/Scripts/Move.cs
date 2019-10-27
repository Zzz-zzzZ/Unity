using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject player;
	public GameObject player2;
    public float speed;

    public float minPosx;
    public float maxPosx;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FixCameraPos();
    }

    void FixCameraPos()
    {
		float pPosX = (player.transform.position.x+player2.transform.position.x)/2;
        float cPosX = transform.position.x;
        if (pPosX - cPosX > 3)
        {
			transform.position = new Vector3(cPosX + speed, transform.position.y,transform.position.z);
        }
        if (pPosX - cPosX < -3)
        {
            transform.position = new Vector3(cPosX - speed, transform.position.y, transform.position.z);
        }
        float realPosX = Mathf.Clamp(transform.position.x, minPosx,maxPosx);
        transform.position = new Vector3(realPosX, transform.position.y, transform.position.z);
    }
}

