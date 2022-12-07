using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //  This script deals with playing audio clips, getting the clips from ___. This script is from Brackeys 
    //      Intro to Audio in Unity youtube video

    //      VARIABLES

    public Sound[] sounds;

    public static AudioManager instance;

    // Called before start method
    private void Awake()
    {
        //  Only have one instance of AudioManager in scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            //  Add an audioSource to current object
            s.source = gameObject.AddComponent<AudioSource>();
            //  set the source's values by using the set values for this Sound
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //  Can play the background music from here
        //Play("Theme");
    }

    //  Method for other scripts to use to call a name of the Sound they want to play
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //  throw a warning in consol if the name is not correct, helps with typos
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
