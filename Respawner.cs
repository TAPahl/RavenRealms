using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    //  New script for managing respawns

    //  VARIABLES

    private Animator animator;

    //  where I store the positions of where the scroll should be
    public GameObject[] checkpointPos;

    //  where I store the last triggered Checkpoint
    public GameObject currentCheckpoint;

    // updated when a new Checkpoint is passed, used for respawn method to get correct gameobject from checkpointPos array
    public int counter;

    private Vector3 playerOffset = new Vector3(7, 0, 0);
    public GameObject obstacleScroll;
    private Rigidbody2D rb;
    private RavenSpeed ravenSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        ravenSpeed = gameObject.GetComponent<RavenSpeed>();
        //  could also do counter - 1 in the respawn function;
        counter = -1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //  When PC enters trigger, check if trigger is tagged "Checkpoint".
    //  True: check if curretCheckpoint var == other.gameobject (if the trigger is the same as the currentCheckpoint I have)
    //  True: do nothing (player has already got this checkpoint)
    //  False: save other.gameobject to currentCheckpoint and add one to counter (player has triggered a new checkpoint)
    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("Checkpoint"))
        {
            if (other.gameObject == currentCheckpoint)
            {
                //do nothing
                Debug.Log("Already passed");
            }
            else
            {
                currentCheckpoint = other.gameObject;
                counter += 1;
                Debug.Log("New Checkpoint");
                //  Play checkpoint SFX
                AudioManager.instance.Play("Checkpoint");
            }
        }
    }

    //  Method for respawning player, called on after Death function's IEneumerator
    public void Respawn()
    {
        //  set lockSpeed to false, to stop the PC movement freeze
        ravenSpeed.lockSpeed = false;

        //  move PC rb to (-7, 0) (the center of PC movement)
        rb.transform.position = playerOffset * -1;

        //  move ObstacleScroll gameObject's pos.X by: Checkpoint pos X + 7 (player offset) * -1 (Obstacle scroll is always
        //      negative) = the pos.X ObstacleScroll should be at
        obstacleScroll.transform.position = (checkpointPos[counter].transform.position + playerOffset) * -1;

        //  Play Sound (could make a ref to AudioManager in this script, or play in with the unity event)
        FindObjectOfType<AudioManager>().Play("Respawn");

        //animator.SetTrigger("Death"); Moved to Death function

        //  SFX
        AudioManager.instance.Play("Respawn");
    }

    //  Add in Screen Freeze feature, ran before position Respawn, make a new function
    //      Death SFX, Death Animation, Set Raven Speed to 0, Lock PC y pos. 

    public void Death()
    {
        //  if timer == true
        ravenSpeed.lockSpeed = true;
        ravenSpeed.currentLockedSpeed = 0;
        ravenSpeed.lockPos = gameObject.transform.position; //This should work since the Respawner is on the PC
        //save PC y pos, set PC y pos to saved pos, use RavenSpeed.lockspeed = true, and set currentLockSpeed = 0
        //  also set lockpos to the current Pos of PC.
        //  lockspeed was for the glide, but I can use the framework to get this freeze feature.
        //set PC speed = 0
        //  Both pseudo above will be reset after X amount of time. (more than 0.5 sec, since that is 
        //      how long the Death anim is. 

        //Death SFX + Anim
        animator.SetTrigger("Death");
        AudioManager.instance.Play("Death");

        //  Start the Coroutine
        StartCoroutine(DeathCoroutine());
    }

    //  Using an IEnumerator coroutine to wait before running respawn.
    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        Respawn();
    }
}
