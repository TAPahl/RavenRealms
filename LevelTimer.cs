using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    //  This script deals with timing and recording the PC time to complete the level
    //      Could have had a problem with the timer being reset on respawn, but since I just move things in scene
    //      and do not reload the scene then the variables should be fine

    //      VARIABLES

    //  timer for the level, made static to be refed in other scripts
    public static float levelTimer;

    public static float finalTime;

    //  bool used to check if leveltimer should be counting, made it a Auto Property to change it with unity events, WORKS!
    public bool TimeOn { get; set; }

    //  static
    //public static LevelTimer Instance; I can just make a single var static instead of the whole script. 

    // Start is called before the first frame update
    void Start()
    {
        levelTimer = 0;
        //  Start timing on sceneLoad 
        finalTime = 0;
        TimeOn = true;
        //  when in ESC menu or collide with Win trigger, turn time bool off since I do not want to record time there
    }

    // Update is called once per frame
    void Update()
    {
        
        //  When time is true, add real time to levelTimer
        //      The timer will stop when timeScale is 0, so in esc menu there is no need to change TimeOn since it is
        //      not counting because timeScale is 0. (But probaly should change it?)
        if (TimeOn)
        {
            levelTimer += Time.deltaTime;
        }
        else
        {
            //do nothing 
        }

        
    }

    //  Run this when PC triggers the Win trigger, so I know they have completed the level and should save their time.
    public void FinalTime()
    {
        finalTime = Mathf.Round(levelTimer * 100) * 0.01f;
        //  send over to GamePreferencesManager to check if this finaltime is faster than the current fastest for this level.
        GamePreferencesManager.Instance.CheckTime(finalTime);

        //finalTime = levelTimer;
        Debug.Log(finalTime);
        //Need to put this final time to the level that was just completed.
        //  get sceneint, if sceneint = 1, save finaltime to level1fastest time.
        
    }
}
