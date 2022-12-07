using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneSwitcher : RavenInputs
{
    //  This script deals with changing scenes

    //      VARIABLES
    public int resetSceneIndex;
    //public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    //  Reset level on press (for dev quick restart)
    public override void ResetLevel(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(resetSceneIndex);
    }

    //  I cannot call ResetLevel (above) method from a unity event for a button, idk why
    //public void ResetLevelButton()
    //{
    //    SceneManager.LoadScene(resetSceneIndex);
    //}

    //  Use for all buttons and triggers to change scene, passes a int of the scene Index which will be changed to
    public void ChangeLevelButton(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
