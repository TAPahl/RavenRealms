using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GamePreferencesManager : MonoBehaviour
{
    //  This script saves and loads playerpref values. 

    //      VARIABLES

    //  Can be changed in inspector, set each level to a different value.
    [SerializeField] int levelNumber;

    //[SerializeField] private Slider volumeSlider = null;

    const string TimeKey = "Time";
    //  Add this int to the end of TimeKey to have multiple keys. Have a check to change the int for each level
    //      IE: level 1 would use int 0
    //public int[] levelNumberArray = new int[4];

    //  Changing to public
    private float fastestTime;

    //  Have the UI text for fastest be on this script 
    public TextMeshProUGUI fastestTimeUI;

    //  AudioManager ref for volume control
    public AudioMixer audiomixer;

    public static GamePreferencesManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    //  Runs when application Quits, run save method here to save all the data
    //      Do not think I will need this anymore since I call SavePrefs after a fastest time i achived after a level
    //private void OnApplicationQuit()
    //{
    //    
    //}

    //  Method used to check the final time against the fastest time for the current level. 
    public void CheckTime(float finalTime)
    {
        if (0 < finalTime && finalTime < PlayerPrefs.GetFloat(TimeKey + levelNumber, 10000000000))
        {
            fastestTime = finalTime;
            Debug.Log("Fastest Time");
            SavePrefs();
        }
        else
        {
            Debug.Log("Not fastest, Fastest = " + PlayerPrefs.GetFloat(TimeKey + levelNumber));
        }

        //  Save the fastest time to the TMPro UI element, ran here since check time is always ran on win
        fastestTimeUI.text = "Fastest Time: " + (PlayerPrefs.GetFloat(TimeKey + levelNumber, 0).ToString());
        //fastestTimeUI.text = "Fastest Time: " + (PlayerPrefs.GetFloat("Time0", 0).ToString()); Testing with string
    }

    //  All PlayerPrefs being saved. This will be each level's fastest time, and settings values. 
    //      Can call this on WinTrigger if the finaltime is faster.
    public void SavePrefs()
    {
        //  Get the final time on level completion 
        PlayerPrefs.SetFloat(TimeKey + levelNumber, fastestTime);
    }

    //  Run on start, to load the PlayerPrefs saved on the last quit
    public void LoadPrefs()
    {
        PlayerPrefs.GetFloat(TimeKey + levelNumber, 0); 
    }

    //  Volume slider setting, call when slider is changed and take in the slider value
    public void SetVolume (float volume)
    {
        //  Set the exposed master volume on the audioMixer to be the passed value of the slider, with slider set
        //      from 0 to -80, mirroring the audioMixer
        //audiomixer.SetFloat("volume", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("Volume", volume);
        AudioListener.volume = volume;
    }
}
