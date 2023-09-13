using System;
using System.Collections;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    private void Start()
    {
        FindFirstObjectByType<AudioManager>().Play("MainMenuMusic");
        PlayerPrefs.DeleteAll();
    }
}