using System.Collections; 
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    
    public void VolumeSlider(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}