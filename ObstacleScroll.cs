using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScroll : MonoBehaviour
{
    //  This script deals with moving the obstacles towards the raven, and the scroll speed is determined by a speed
    //      var on the raven

    //      VARIABLES

    //public float speed;   Not used

    public GameObject ravenRef;
    //private RavenAdvancedMovement ravenAdvancedMovement;
    private RavenSpeed ravenSpeed;

    //  use this to change the speed of background, do not change for anything else
    public bool background;
    private float backgroundSpeed = 0.5f;
    private float speedTune = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //ravenAdvancedMovement = ravenRef.GetComponent<RavenAdvancedMovement>();
        ravenSpeed = ravenRef.GetComponent<RavenSpeed>();

        if (background)
        {
            speedTune = backgroundSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  Move what ever this script is attatched to to the left at speed var
        //      transform.pos my not be the best later, velocity may be better 
        //  Adding in using the RavenAdvacnedMovementSpeed
        //transform.position += Vector3.left * ravenAdvancedMovement.ravenSpeed * Time.deltaTime;
        transform.position += Vector3.left * ravenSpeed.currentSpeed * speedTune * Time.deltaTime;
    }
}
