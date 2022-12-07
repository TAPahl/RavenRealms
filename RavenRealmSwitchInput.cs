using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RavenRealmSwitchInput : RavenInputs
{
    //  This script calls RavenRealmToggle.instance.RealmToggle with the input system

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void RealmSwitch(InputAction.CallbackContext context)
    {
        RavenRealmToggle.instance.RealmToggle();
        //  SFX for RealmSwitch
        AudioManager.instance.Play("Switch");
    }

}
