using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this .gameObject.SetActive(false);
            GameObject.Find("Directional Light").GetComponent<test>().PlayAudio("sky");
            Debug.Log("000000000000000");
            
        }
    }
}