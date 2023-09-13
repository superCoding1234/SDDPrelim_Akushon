using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReadingLogic : MonoBehaviour
{
    [SerializeField] private GameObject serpentsortia1, bigpapa1, bomb1, serpentsortia2, bigpapa2, bomb2;
    // Start is called before the first frame update
    void Start()
    {
        switch(PlayerPrefs.GetInt("player1Character"))
        {
            case 0:
                Instantiate (serpentsortia1);
                break;
            case 1:
                Instantiate (bigpapa1);
                break;
            case 2:
                Instantiate(bomb1);
                break;
            default:
                Debug.LogWarning("PlayerPrefs aren't right");
                break;
        }
        switch (PlayerPrefs.GetInt("player2Character"))
        {
            case 0:
                Instantiate(serpentsortia2);
                break;
            case 1:
                Instantiate(bigpapa2);
                break;
            case 2:
                Instantiate(bomb2);
                break;
            default:
                Debug.LogWarning("PlayerPrefs aren't right");
                break;
        }
    }

}
