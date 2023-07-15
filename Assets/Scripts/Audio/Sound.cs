using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    //reference to AudioSource to play the sound
    [NonSerialized] public List<AudioSource> source = new();
    
    //identifiers
    public string name;

    public AudioClip[] clips;
    public AudioGroup audioGroup;

    [Range(0f, 1f)] public float volume = 1f;
    [Range(.1f, 3f)] public float pitch = 1f;

    public bool loop;
}