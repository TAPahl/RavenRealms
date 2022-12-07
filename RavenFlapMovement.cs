using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class RavenFlapMovement : RavenInputs
{
    //  This script deals with advanced raven movement, tap flap

    //      VARIABLES

    private Animator animator;

    //  UnityEvents, use this to keep code decoupled and easier to move
    //      making a UnityEvent for when TapFlap gets activated (In Fire() when canFlap = true) 
    public UnityEvent TapFlapEvent;


    //  how much up force is applied to raven 
    public float force;

    private Rigidbody2D rb;

    //  Testing for a timer between tap flaps?
    private bool canFlap;
    private float flapTimer;
    //  Time between tap flap actions
    public float flapCooldown = 1f;
    // could have flapSpeedBoost in this, run a method in RavenSpeed which takes in a float as the boost speed,
    //  otherwise have all the speed stuff on the RavenSpeed.

    //  time until ravenspeed is slowed                 NOT
    //private float actionSlowTimer;                    NEEDED
    //public float actionSlowTimerMax;                  MOVE TO RavenSpeed.cs

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        canFlap = true;
        flapTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        //  cooldown between tap flap (so player cannot spam)
        if (canFlap == false)
        {
            flapTimer += Time.deltaTime;

            if (flapTimer >= flapCooldown)
            {
                canFlap = true;
                flapTimer = 0;
                
            }
        }

        //  use canFlap bool to set the animator Flap bool, the raven is 'Flapping' when canFlap = false,
        //  so on false play animation
        //animator.SetBool("Flap", !canFlap);

    }

    public override void Fire(InputAction.CallbackContext context)
    {
        if (canFlap == true)
        {
            //  Tap Flap, increase velocity in up direction
            rb.velocity = Vector2.up * force;

            //  Increase raven speed by a certian amount
            //ravenSpeed += tapFlapSpeedBoost;
            //  Instead of adding to speed directly in script, Invoke the UnityEvent and hook it up in editor
            TapFlapEvent.Invoke();

            //  Play animation trigger
            animator.SetTrigger("Flap");

            //  SFX
            AudioManager.instance.Play("Flap");
        }
        //  Turn canFlap to false
        canFlap = false;
    }

}
