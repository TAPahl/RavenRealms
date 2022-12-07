using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    //  This script deals with only looping the foreground and background assets (put speed on obstacle scroll.cs)
    //      Need to have two duplicate assets backtoback covering the screen

    //      VARIABLES

    //  Getting the speed variable from Raven to use to determine how fast to scroll
    //public GameObject ravenRef;
    //private RavenSpeed ravenSpeed;
    //  value to tune the speed of background
    //public float speedTune;

    //  get the starting position of the object and store the length of half of it to know when to repeat
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //ravenSpeed = ravenRef.GetComponent<RavenSpeed>();

        startPos = transform.position;
        //  Have to put a box collider on these assets to get this value
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //  if position is past halfway of start pos, reset to start pos
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
