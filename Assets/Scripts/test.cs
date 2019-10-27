using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {



    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = gameObject.GetComponent<AudioSource>(); // 傻瓜注释- -   获取组件
	}
    //播放音效   public 修饰为外部调用
  public void PlayAudio(string name)
    {
        AudioClip tempClip = Resources.Load<AudioClip>("Audios/" + name);//获取本地 音效
        //  audio.PlayOneShot(tempClip, 1);
        audio.clip = tempClip;//获取 音效 赋值

        audio.Play();//播放
    }
    // Update is called once per frame
  
}
