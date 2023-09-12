using System.Collections;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    private void Start()
    {
        FindFirstObjectByType<AudioManager>().Play("MainMenuMusic");
        PlayerPrefs.DeleteAll();
    }

    public void CharacterSelectionScene()
    {
        StartCoroutine(AsyncCharacterSelectionAudio());
    }

    private IEnumerator AsyncCharacterSelectionAudio()
    {
        AudioManager am = FindFirstObjectByType<AudioManager>();
        am.Stop("MainMenuMusic");
        am.Play("CharacterSelectionMusic");
        yield return null;
    }
}