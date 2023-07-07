using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        //iterating through each sound of each type to create an AudioSource for it, and also storing each reference in
        //an array for easy accessing
        foreach (Sound s in sounds)
        {
            foreach (AudioClip c in s.clips)
            {
                AudioSource currentSource = gameObject.AddComponent<AudioSource>();
                currentSource.clip = c;
                s.source.Add(currentSource);
                currentSource.volume = s.volume;
                currentSource.pitch = s.pitch;
                currentSource.loop = s.loop;
                currentSource.playOnAwake = false;
            }
        }
    }

    private void Start()
    {
        /*debug
        foreach (Sound s in sounds)
        {
            foreach (AudioSource sour in s.source)
            {
                Debug.Log(sour.clip);
            }
        }
        */
    }

    public void Play(string names)
    {
        Sound s = Array.Find(sounds, sound => sound.name == names);
        if (s == null)
        {
            Debug.LogWarning("Sound of name " + name + " not found!");
            return;
        }
        s.source[Random.Range(0, s.source.Count)].Play();
    }
}