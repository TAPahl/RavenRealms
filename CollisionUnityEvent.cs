using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionUnityEvent : MonoBehaviour
{
    //  This script runs a unity event when collided

    //      VARIABLES
    public UnityEvent collisionEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEvent.Invoke();
    }
}
