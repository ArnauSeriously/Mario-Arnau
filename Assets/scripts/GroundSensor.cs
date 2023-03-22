using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerrController controller;
    public bool isGrounded;

    GAMEMANAGER GameManager; 

SFXManager sfxManager;
SoundManager soundManager;
    void Awake ()
    {
        controller = GetComponentInParent<PlayerrController>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
         GameManager = GameObject.Find("GameManager").GetComponent<GAMEMANAGER>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3) 
        {
            isGrounded =true ;
            controller.anim.SetBool("IsJumping", false);
        }
        else if (other.gameObject.layer == 6)
        {
            Debug.Log("goomba muerto");

            sfxManager.GoombaDeath();
            Enemy goomba=other.gameObject.GetComponent<Enemy>();
            goomba.Die(); 
        }

        if(other.gameObject.tag == "DeadZone" )
        {
            Debug.Log("Estoy muerto");
            soundManager.StopBGM();
            sfxManager.MarioDeath();
            GameManager.GameOver();
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            controller.anim.SetBool("IsJumping", false);
        }
        
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
            controller.anim.SetBool("IsJumping", true);
        }
        
    }
}
