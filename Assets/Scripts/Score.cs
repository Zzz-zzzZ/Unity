using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour
{
    public int coinscore = 0;

    void Start()
    {

    }


    void Update()
    {
        GameObject.Find("Canvas/Text").GetComponent<Text>().text = " " + coinscore;

    }
    public void Add()
    {
        coinscore = coinscore + 10;
    }
    public void Addplus()
    {
        coinscore = coinscore + 1000;
    }
}