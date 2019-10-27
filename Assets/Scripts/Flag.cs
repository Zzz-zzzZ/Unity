using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

    private Animator anim = null;
    private AudioSource audio;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {




    }
   
     public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {

              anim.SetTrigger("IsDown");
              audio.Play();
            }
        }
}

