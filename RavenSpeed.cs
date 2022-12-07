using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenSpeed : MonoBehaviour
{
    //  This script deals with the speed of the obstacles scrolling, and how the Raven movement is changing that speed

    //      VARIABLES

    //  general raven speed var 
    public float currentSpeed = 0f;
    public float StartSpeed;
    public float minSpeed;
    public float maxSpeed;

    //  time until ravenspeed is slowed 
    private float actionSlowTimer;
    public float actionSlowTimerMax;
    public float actionSlowReduction;

    //  bool for when glide is input
    public bool lockSpeed;
    public float currentLockedSpeed;
    public Vector3 lockPos;

    // Start is called before the first frame update
    void Start()
    {
        //  set currentspeed to the startspeed
        currentSpeed = StartSpeed;
        lockSpeed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  Check if speed should be locked (locked from glide action)
        if (lockSpeed == false)
        {
            //  Speed limit check
            if (currentSpeed >= maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

            if (currentSpeed <= minSpeed)
            {
                currentSpeed = minSpeed;
            }

            //  Slow speed if player has not input an action (decelerate)
            if (currentSpeed > minSpeed)
            {
                actionSlowTimer += Time.deltaTime;

                if (actionSlowTimer >= actionSlowTimerMax)
                {
                    //  This can be a deceleration over time, This will run until ravenSpeed reaches min
                    currentSpeed -= actionSlowReduction * Time.deltaTime;
                }
            }
        }
        else
        {
            //  lock current speed
            currentSpeed = currentLockedSpeed;
            //  lock current position
            transform.position = lockPos;
        }

        
    }

    //  will have to change a bit to change what float gets passed (or create individual boost floats on this script) 
    public void SpeedBoost(float boostAmount)
    {
        Debug.Log("Added Speed" + boostAmount);
        //  Add the boost to the current speed
        currentSpeed += boostAmount;
        //  reset actionSlowTimer since an action was called
        actionSlowTimer = 0f;
    }

    //  reduce speed, used for collisions
    public void SpeedReduction(float reductionAmount)
    {
        currentSpeed -= reductionAmount;
    }

    public void LockSpeed()
    {
        //  get the currentSpeed and save it in currentLockSpeed to use in update
        currentLockedSpeed = currentSpeed;
        //  THIS COULD BE PUT ON GLIDE SCRIPT, TESTING HERE
        //      getting current pos and saving it
        //  BUG: Holding Glide for longer will result in raven dropping faster on release IDK why
        //  BUG 2: Raven can go through walls since I am changing the transform.position, instead of adding a rb force
        //  (this SHOULD be fixed when I add in collision events)
        lockPos = transform.position;
        //  flipflop the bool (on press, true, on release, false)
        lockSpeed = !lockSpeed;
    }

    
}
