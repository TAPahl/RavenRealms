using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenRealmToggle : MonoBehaviour
{
    //  This script toggles the selected Realm, which will toggle tagged Light and Shadow box colliders on or off
    //      and change their visuals. 


    //      VARIABLES
    public static RavenRealmToggle instance;

    public bool shadowOn;

    private SpriteRenderer render;
    private float offAlpha = 0.2f;
    private float onAlpha = 1f;

    //public string currentTag;
    //private string shadowTag = "Shadow";
    //private string lightTag = "Light";
    public GameObject[] shadowObstacles;
    public GameObject[] lightObstacles;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        shadowOn = true;

        shadowObstacles = GameObject.FindGameObjectsWithTag("Shadow");
        lightObstacles = GameObject.FindGameObjectsWithTag("Light");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RealmToggle()
    {
        //  switch shadowOn to its opposite (flip the switch)
        shadowOn = !shadowOn;


        //  Change what tag is being searched for (I have no clue how to change a string to a different string)
        //      tried to use shadowOn = true ? ... but was not working
        
        //  If shadowOn is toggled on, set all lightobstacles to active false and all shadow to active true (turn 
        //      collider on/off and change alpha)
        if (shadowOn == true)
        {
            foreach (GameObject obstacle in lightObstacles)
            {
                //obstacle.SetActive(false);

                //  Turn off the boxcollider
                obstacle.GetComponent<BoxCollider2D>().enabled = false;
                //  Get sprite renderer
                render = obstacle.GetComponent<SpriteRenderer>();
                //  get color
                Color tmp = render.color;
                //  change alpha of tmp
                tmp.a = offAlpha;
                //  feedback the changed alpha in tmp 
                render.color = tmp;
            }
            foreach (GameObject obstacle in shadowObstacles)
            {
                //obstacle.SetActive(true);
                //  Turn on the boxcollider
                obstacle.GetComponent<BoxCollider2D>().enabled = true;

                //  Turn off the boxcollider
                obstacle.GetComponent<BoxCollider2D>().enabled = true;
                //  Get sprite renderer
                render = obstacle.GetComponent<SpriteRenderer>();
                //  get color
                Color tmp = render.color;
                //  change alpha of tmp
                tmp.a = onAlpha;
                //  feedback the changed alpha in tmp 
                render.color = tmp;
            }
        }
        //  else shadowOn is false, lightObs are active and shadowObs are inactive
        else
        {
            foreach (GameObject obstacle in lightObstacles)
            {
                //obstacle.SetActive(true);
                //  Turn oon the boxcollider
                obstacle.GetComponent<BoxCollider2D>().enabled = true;

                //  Turn off the boxcollider
                obstacle.GetComponent<BoxCollider2D>().enabled = true;
                //  Get sprite renderer
                render = obstacle.GetComponent<SpriteRenderer>();
                //  get color
                Color tmp = render.color;
                //  change alpha of tmp
                tmp.a = onAlpha;
                //  feedback the changed alpha in tmp 
                render.color = tmp;

            }
            foreach (GameObject obstacle in shadowObstacles)
            {
                //obstacle.SetActive(false);
                //  Turn off the boxcollider
                obstacle.GetComponent<BoxCollider2D>().enabled = false;

                //  Turn off the boxcollider
                obstacle.GetComponent<BoxCollider2D>().enabled = false;
                //  Get sprite renderer
                render = obstacle.GetComponent<SpriteRenderer>();
                //  get color
                Color tmp = render.color;
                //  change alpha of tmp
                tmp.a = offAlpha;
                //  feedback the changed alpha in tmp 
                render.color = tmp;
            }
        }
    }
}
