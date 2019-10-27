using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed = 5000;
    private AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(translation: Vector2 .right * speed*Time .deltaTime );
        Destroy (this.gameObject,1.5f);
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy"&& other.tag == "DoubleKill")
        {
            
            Debug.Log("6561654654665");
            GameObject.Find("Main Camera").GetComponent<test>().PlayAudio("enemydeath");
            
        }
    }
}
