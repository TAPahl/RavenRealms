using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class RavenDiveMovementInput : RavenInputs
{
    //  This script deal with the input for the Raven dive movement

    //      VARIABLES

    public UnityEvent diveEvent;

    public float gravity;
    private float baseGravity;

    private Rigidbody2D rb;

    //bool and timer for limiting the dive
    private bool canDive;
    private float diveTimer;
    public float diveTimerMax;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        canDive = true;
        baseGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        //  Have to reset gravity scale after Dive changes it, have to do it after a second to make the gravity work
        if (canDive == true)
        {
            //Debug.Log("Grav off");
            rb.gravityScale = baseGravity;
        }
        

        //if (canDive == false)
        //{
        //    diveTimer += Time.deltaTime;
        //
        //    if (diveTimer >= diveTimerMax)
        //    {
        //        //  Allow PC to dive and reset gravityscale to normal  CHANGE gravity scale to using a var in game
        //        canDive = true;
        //        rb.gravityScale = 3.5f;
        //    }
        //}
    }

    //  Using Input Press and Release to call it on press AND on release
    public override void Dive(InputAction.CallbackContext context)
    {
        //Debug.Log("Grav On");

        //  Adding force to RB NOT working
        //rb.AddForce(Vector2.down * force);

        //  Changing the gravity while canDive = false
        rb.gravityScale = gravity;
        canDive = !canDive;
        //canDive = false;
        diveEvent.Invoke();

        
    }

    //  Add in a InputAction which is just a on press, so it is called once at start of Dive, to play anim and sfx once
    //      Working
    public override void DivePress(InputAction.CallbackContext context)
    {
        //  Play Animation trigger
        animator.SetTrigger("Dive");

        //  Play SFX
        AudioManager.instance.Play("Dive");
    }

    
}
