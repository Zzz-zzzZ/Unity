using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //开始游戏
    public void StartGame()
    {
        //加载场景
        //Application.LoadLevel("MainScene");
        SceneManager.LoadScene("Begin");
    }
}
