using System;
using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        FindFirstObjectByType<AudioManager>().Play("MainMenuMusic");
        PlayerPrefs.DeleteAll();
    }
}