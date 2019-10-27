using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeingingGame()
    {

        //Application.LoadLevel("MainScene");
        SceneManager.LoadScene("MainScene");
    }
}


