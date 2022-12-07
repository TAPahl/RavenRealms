using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class RavenGlideMovementInput : RavenInputs
{
    //  This script deal with the Raven movement Glide, raven will keep speed and hight while button held

    //      VARIABLES

    //  Use a unity event so I do not have to ref ravenspeed in this script
    //private RavenSpeed ravenSpeed;
    //private Rigidbody2D rb;

    public UnityEvent glideEvent;

    //  Have to set current speed var in RavenSpeed to a constant while this input is held
    //      Idea 1: ref RavenSpeed and change currentSpeed directly.
    //      Idea 2: When Glide is called, call a function in RavenSpeed.cs which locks the currentSpeed where it is
    //  Think I found a solution, using the Input System with a Press interaction PressAndRelease I can call preformed
    //      on press and on release, so call a function in RavenSpeed that flipflops a bool which locks currentSpeed

    //  Also have to lock the y vector to 'hold altitude' (have to make it so
    //      other Input actions will not work when one is called, so this should be okay to change on this script)
    //      

    // Start is called before the first frame update
    void Start()
    {
        //ravenSpeed = gameObject.GetComponent<RavenSpeed>();
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Glide(InputAction.CallbackContext context)
    {
        //  run the LockSpeed Method
        //ravenSpeed.LockSpeed();
        glideEvent.Invoke();
        //Debug.Log("Glide: " + ravenSpeed.lockSpeed);
    }
}
