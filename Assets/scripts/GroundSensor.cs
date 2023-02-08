using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerrController controller;
    public bool isGrounded;

    void Awake ()
    {
        controller = GetComponentInParent<PlayerrController>();
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
            Enemy goomba=other.gameObject.GetComponent<Enemy>();
            goomba.Die(); 
        }

        if(other.gameObject.tag == "DeadZone" )
        {
            Debug.Log("Estoy muerto");
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