using System;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    private Dictionary<string, int> tempMemory = new ();

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
                currentSource.outputAudioMixerGroup = s.audioGroup.audioMixerGroup;
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

        tempMemory[names] = UnityEngine.Random.Range(0, s.source.Count);
        s.source[tempMemory[names]].Play();
    }

    public void Stop(string names)
    {
        Sound s = Array.Find(sounds, sound => sound.name == names);
        if (s == null)
        {
            Debug.LogWarning($"Sound of name {name} not found!");
            return;
        }
        
        s.source[tempMemory[names]].Stop();
    }

    public bool IsPlaying(string names)
    {
        Sound s = Array.Find(sounds, sound => sound.name == names);
        if (s == null)
        {
            Debug.LogWarning($"Sound of name {name} not found!");
            return false;
        }

        if (!tempMemory.ContainsKey(names)) return false;
        return s.source[tempMemory[names]].isPlaying;
    }
}