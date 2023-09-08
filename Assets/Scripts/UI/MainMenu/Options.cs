using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void MasterVolumeSlider(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void MusicVolumeSlider(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }
    
    public void VoicelineVolumeSlider(float volume)
    {
        audioMixer.SetFloat("voicelineVolume", volume);
    }
    
    public void FXVolumeSlider(float volume)
    {
        audioMixer.SetFloat("fxVolume", volume);
    }
}