using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AnimationControllerTest : MonoBehaviour
{
    #region Store player's Animator 
    private Animator anim = null;
    private  AudioSource audio;
    Rigidbody2D rigidbody2D;
    private bool isGround = false;
    
    
    public GameObject player;
    public GameObject Money;
    public GameObject Cavans;
    public GameObject Maincamera;
	public float force_move = 3000;
    #endregion

    #region Start 
    void Start()
    {
        anim = this.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Update 
    void Update()
    {
        PlayerConroller();
    }
    #endregion

    #region -PlayerConroller the implementation of Animation & Displacement
    private void PlayerConroller()
    {
       
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("IsWalk", true);
            this.transform.localScale = new Vector3(-1, 1, 1);//Animation of LEFT
            this.transform.Translate(Vector3.left * Time.deltaTime * 5);
            rigidbody2D.AddForce(-Vector2.right * force_move);//Displacement
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsWalk", true);
			this.transform.localScale = new Vector3(1, 1, 1);//Animation of Right
            this.transform.Translate(Vector3.right * Time.deltaTime * 5);
               rigidbody2D.AddForce(Vector2.right * force_move);////Displacement
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("IsWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("IsAttack");//Animation of Attack
            PlayAudio("shoot");

        }

        if (isGround && Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("IsJump");//Animation of Jump
            isGround = false;
            Vector2 temPosition = rigidbody2D.transform.position;
            //rigidbody2D.transform.position = new Vector2(temPosition.x, temPosition.y + 2f);
			rigidbody2D.AddForce(new Vector2(0,4000));//Displacement
            PlayAudio("Jump Small");
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {   //if(collider .col="Ground")
        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("Groune");
            isGround = true;
        }
        if (col.gameObject.tag == "Enemy")
        {
            
            //GameObject.Find("Canvas").GetComponent<Score>().Add();
            GameObject.Find("life").GetComponent<Life>().Minus();
            PlayAudio("Aced");
            transform.position = new Vector3(-14.55f, -2.44f, 0);
            Maincamera.transform.position = new Vector3(-1.8f, 1, -1);
            
        }
        if (col.gameObject.tag == "JianWu")
        {
            GameObject.Find("life").GetComponent<Life>().Minus();
            transform.position = new Vector3(-14.55f, -2.44f, 0);
            Maincamera.transform.position = new Vector3(-1.8f, 1, -1);
            PlayAudio("Aced");
           
        }


        if (col.gameObject.tag == "Flower")
        {
            GameObject.Find("life").GetComponent<Life>().plus();
            col.gameObject.SetActive(false);
            PlayAudio("flower");
        }
        if (col.gameObject.tag == "Zhuan")
        {
            
            
            PlayAudio("Zhuan");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Money")
        {
            PlayAudio("Coin");
            other.gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<Score>().Add();
        }
        if (other.tag == "pumpkin")
        {
            PlayAudio("Coin");
            other.gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<Score>().Addplus();
            PlayAudio("flower");
        }
    }
   
    void PlayAudio(string name)
    {
        AudioClip tempClip = Resources.Load<AudioClip>("Audios/" + name);
        audio.PlayOneShot(tempClip, 1);
    }
    


    #endregion
}
