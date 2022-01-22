using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakanPlayer : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;

    public float runSpeed;
    public float blockSpeed = 5f;

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {

       if (Input.GetButton ("Fire2")) 
       {
           horizontalMove = Input.GetAxisRaw("Horizontal") * 0;
          
       }
       else 
       {
           horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
           animator.SetFloat ("Speed", Mathf.Abs(horizontalMove));

           if (Input.GetButton ("Jump"))
           {
               jump = true;
               animator.SetBool("Jumping",true);
            }
       }

    }
    /*
    public void knockbackmove (){
        if (knockbackFromRight)
           rb.velocity = new Vector2 (-knockback, 1);

           if (!knockbackFromRight)
           rb.velocity = new Vector2 (knockback, 1);

           knockbackCount -= Time.deltaTime;
    }
    */
    public void OnLand ()
    {
        animator.SetBool ("Jumping",false);
    }
    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;

    }
}
