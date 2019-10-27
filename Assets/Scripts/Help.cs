using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
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
    public void BeingingGame()
    {
        //加载场景
        //Application.LoadLevel("MainScene");
        SceneManager.LoadScene("Help");
    }
}
