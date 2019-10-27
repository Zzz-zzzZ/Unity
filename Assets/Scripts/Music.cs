using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
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
            //PlayAudio("Firstblood");
            this.gameObject.SetActive(false);
            GameObject.Find("Directional Light").GetComponent<test>().PlayAudio("1");
            Debug.Log("000000000000000");
            //查找  组件 （就是找到这个脚本） 然后调用 播放音效的代码就OK啦  勾傻瓜吧
            // audio.Play();
        }
    }
}
