using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class RavenReduceInput : RavenInputs
{
    //  This script deal with the reduce speed input

    //      VARIABLES

    public UnityEvent reduceEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Reduce(InputAction.CallbackContext context)
    {
        Debug.Log("Reduced Speed");
        reduceEvent.Invoke();
    }
}
