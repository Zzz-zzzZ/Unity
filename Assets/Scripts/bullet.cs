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
            //PlayAudio("Firstblood");
            Debug.Log("6561654654665");
            GameObject.Find("Main Camera").GetComponent<test>().PlayAudio("enemydeath");
            //查找  组件 （就是找到这个脚本） 然后调用 播放音效的代码就OK啦  勾傻瓜吧

            //this.gameObject.SetActive(false);
            // audio.Play();
        }
    }
}
