using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionInteractions : MonoBehaviour
{
    //  This script deal with slowing and respawning Raven when it collides with obstacles

    //      VARIABLES

    //  Unity events 
    public UnityEvent collideLightShadow;
    public UnityEvent collideReal;

    //private Rigidbody2D rb;
    //public bool inObstacle;
    //public Vector3 lockPos;

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //inObstacle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //  check if Raven is in an obstacle, keep Raven in the lockPos until inObstacle false, which in onExit
        //if (inObstacle == true)
        //{
        //    gameObject.transform.position = lockPos; 
        //}

    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        //  Start by saving the current pos (I only want this called if Raven hits a wall perpendicular to floor
        //      this will be ran even it Raven hits a flat surface) 
        //  Solution: Tag flat surfaces differently, and use a square Raven (so circle does not have a small
        //      collision) 
        //lockPos = gameObject.transform.position;
        //inObstacle = true;

        //  Collision result for Light/Shadow obstacles
        if (other.gameObject.CompareTag("Light") || other.gameObject.CompareTag("Shadow"))
        {
            Debug.Log("Crashed!");
            //  Reduce hitpoints by 1
            //  Respawn or Invincibility and slow

            //      \/ this can put Raven into an obstacle, 
            //gameObject.transform.position = new Vector3(-7, 0, 0);

            //  SpeedReduction method in RavenSpeed
            collideLightShadow.Invoke();
        }

        //  Collision results for Real obstacles
        if (other.gameObject.CompareTag("Real"))
        {
            Debug.Log("Slow");
            //  Slow
            //  Bounce off?
            //  SpeedReduction method in RavenSpeed
            collideReal.Invoke();
        }
    }

    //  When Raven leaves the Obstacle, allow player control
    //public void OnCollisionExit2D(Collision2D collision)
    //{
    //    inObstacle = false;
    //}

    //  While Raven is toutching the obstacle, turn off collider, change color (for player to understand 
    //      what is happening). Turn collider back on OnExit
}
