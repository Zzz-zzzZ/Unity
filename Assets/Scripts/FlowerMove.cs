using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMove : MonoBehaviour
{
    public float speed = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector2.right * speed * Time.deltaTime);
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            //PlayAudio("Firstblood");

            GameObject.Find("Gun").GetComponent<test>().PlayAudio("lifeadd");
            //查找  组件 （就是找到这个脚本） 然后调用 播放音效的代码就OK啦  勾傻瓜吧

            this.gameObject.SetActive(false);
            // audio.Play();
        }
    }
}
