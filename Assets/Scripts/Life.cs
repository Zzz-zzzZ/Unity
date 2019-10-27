using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Life : MonoBehaviour
{
    public int Lifevalue = 3;

    void Start()
    {

    }


    void Update()
    {
        GameObject.Find("Canvas/life").GetComponent<Text>().text = " " + Lifevalue;
        if (Lifevalue==0)
            {
                SceneManager.LoadScene("defeat");
            }
    }
    public void Minus()
    {
        Lifevalue = Lifevalue - 1;
        
    }
    public void plus()
    {
        Lifevalue = Lifevalue + 1;

    }
    
}
