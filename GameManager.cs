using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : RavenInputs
{
    // Start is called before the first frame update

    //  This script deals with the UI right now

    //      VARIABLES
    public TextMeshProUGUI shadowToggleUI;
    //  TimerUI is where the PC leveltimer should be placed when they finish the level.
    public TextMeshProUGUI timerUI;
    //  The win screen timer TMPro
    public TextMeshProUGUI winTimerUI;
    //  The win screen fastest time TMPro
    //public TextMeshProUGUI fastestTimeUI;

    //  TMPro UGUI var for the fastest times main menu screen
    public TextMeshProUGUI l1f;
    public TextMeshProUGUI l2f;
    public TextMeshProUGUI l3f;
    public TextMeshProUGUI l4f;
    public TextMeshProUGUI l5f;

    public GameObject escPanel;

    //  ref level timer

    //made public to allow for Unityevent to change the value (need to switch when the UI button is pressed)
    //  Solved: used properties (Auto Property) which allows the var to be set in unity event
    public bool EscOn { get; set; }

    void Start()
    {
        EscOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        //  Display the current shadownOn bool from RavenRealmToggle
        //      Make this color coded to the Shadow and Light obstacles so player understands better: Shadow (purple) or Light (yellow)
        shadowToggleUI.text = "Shadow: " + RavenRealmToggle.instance.shadowOn.ToString();

        //  stop time ingame, only allow menu selection
        if (EscOn)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        //  Display current time with rounding to hundreths 
        timerUI.text = "Time: " + (Mathf.Round(LevelTimer.levelTimer * 100) * 0.01f).ToString();

        //  Temp placement for saving levelTimer to timerUI, only need to convert on win once so no need to be update
        winTimerUI.text = "Clear Time: " + (Mathf.Round(LevelTimer.levelTimer * 100) * 0.01f).ToString();
        //  Displaying the fastest time with PlayerPrefs.GetFloat but TimeKey and Levelnumber in GamePrefManager are not public
        //fastestTimeUI.text = "Fastest Time: " + PlayerPrefs.GetFloat(GamePreferencesManager.Instance)

    }

    //  When ESC is pressed, pause game and bring up the ESC UI panel.
    //  Resume button will resume game, pressing esc again will also resume game.
    public override void ESC(InputAction.CallbackContext context)
    {
        EscOn = !EscOn;
        escPanel.SetActive(EscOn);
        
    }

    //  Method for updating the main menu fastest time UI, call it when player presses the fastest times button
    //      hardcoded so if I change how the times are saved (the string) then I have to change this
    public void MainMenuFastestTimes()
    {
        l1f.text = "Level 1: " + PlayerPrefs.GetFloat("Time1").ToString();
        l2f.text = "Level 2: " + PlayerPrefs.GetFloat("Time2").ToString();
        l3f.text = "Level 3: " + PlayerPrefs.GetFloat("Time3").ToString();
        l4f.text = "Level 4: " + PlayerPrefs.GetFloat("Time4").ToString();
        l5f.text = "Level 5: " + PlayerPrefs.GetFloat("Time5").ToString();
    }
}
