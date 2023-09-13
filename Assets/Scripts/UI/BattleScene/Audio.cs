using System;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private void Update()
    {
        if (!FindFirstObjectByType<AudioManager>().IsPlaying("BattleMusic") &&
            !FindFirstObjectByType<AudioManager>().IsPlaying("BattleMusicMix"))
        {
            FindFirstObjectByType<AudioManager>().Play("BattleMusicMix");
        }
    }
}