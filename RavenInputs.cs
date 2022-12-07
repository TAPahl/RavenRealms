using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RavenInputs : MonoBehaviour
{
    //  This script deal with the InputSystem


    //      VARIABLES



    //  Player Input script
    public PlayerInputActions playerControls;
    //private InputAction move;
    private InputAction fire;
    private InputAction realmSwitch;
    private InputAction glide;
    private InputAction dive;
    private InputAction resetLevel;
    private InputAction esc;
    private InputAction divePress;
    private InputAction reduce;


    //  Used for inputManager
    private void Awake()
    {
        //  Initialize the script
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        //  setting move var to the Player Action Map, and the Move Actions inside
        //move = playerControls.Player.Move;
        //move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();

        realmSwitch = playerControls.Player.RealmSwitch;
        realmSwitch.Enable();

        glide = playerControls.Player.Glide;
        glide.Enable();

        dive = playerControls.Player.Dive;
        dive.Enable();

        divePress = playerControls.Player.DivePress;
        divePress.Enable();

        resetLevel = playerControls.Player.ResetLevel;
        resetLevel.Enable();

        esc = playerControls.Player.ESC;
        esc.Enable();

        reduce = playerControls.Player.Reduce;
        reduce.Enable();

        //  set fire var to the Fire() method. When fire in input actions is preformed, run Fire() method
        fire.performed += Fire;
        realmSwitch.performed += RealmSwitch;
        glide.performed += Glide;
        dive.performed += Dive;
        resetLevel.performed += ResetLevel;
        esc.performed += ESC;
        divePress.performed += DivePress;
        reduce.performed += Reduce;
    }
    private void OnDisable()
    {
        //move.Disable();
        fire.Disable();
        realmSwitch.Disable();
        glide.Disable();
        dive.Disable();
        resetLevel.Disable();
        esc.Disable();
        divePress.Disable();
        reduce.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Fire(InputAction.CallbackContext context)
    {
        
    }

    public virtual void RealmSwitch(InputAction.CallbackContext context)
    {
        
    }
    
    public virtual void Glide(InputAction.CallbackContext context)
    {

    }

    public virtual void Dive(InputAction.CallbackContext context)
    {

    }

    public virtual void DivePress(InputAction.CallbackContext context)
    {

    }

    public virtual void ResetLevel(InputAction.CallbackContext context)
    {

    }

    public virtual void ESC(InputAction.CallbackContext context)
    {

    }

    public virtual void Reduce(InputAction.CallbackContext context)
    {

    }
}
