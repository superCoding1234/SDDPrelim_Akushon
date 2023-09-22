using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterReadingLogic : MonoBehaviour
{
    [SerializeField] private GameObject serpentsortia1, bigpapa1, bomb1, serpentsortia2, bigpapa2, bomb2;
    [SerializeField] private TimeScaleManager tsm;
    [SerializeField] private GameObject tsmFlag1, tsmFlag2;
    [SerializeField] private Image[] abilityFlag1, abilityFlag2;
    [SerializeField] private StandardAbility[] elementals1, elementals2;
    [SerializeField] private Transform spawnPoint1, spawnPoint2;
    [SerializeField] private Sprite serpent, bomb, bigpapa;
    [SerializeField] private Sprite[] elements;
    private PlayerController1 instantiatedPlayer1;
    private PlayerController2 instantiatedPlayer2;
    private GameObject player1, player2;
    // Start is called before the first frame update
    void Awake()
    {
        switch(PlayerPrefs.GetInt("player1Character"))
        {
            case 0:
                player1 = Instantiate(serpentsortia1, spawnPoint1.position, Quaternion.identity);
                instantiatedPlayer1 = player1.GetComponentInChildren<PlayerController1>();
                abilityFlag1[1].sprite = serpent;
                break;
            case 1:
                player1 = Instantiate(bigpapa1, spawnPoint1.position, Quaternion.identity);
                instantiatedPlayer1 = player1.GetComponentInChildren<PlayerController1>();
                abilityFlag1[1].sprite = bigpapa;
                break;
            case 2:
                player1 = Instantiate(bomb1, spawnPoint1.position, Quaternion.identity);
                instantiatedPlayer1 = player1.GetComponentInChildren<PlayerController1>();
                abilityFlag1[1].sprite = bomb;
                break;
            default:
                Debug.LogWarning("PlayerPrefs aren't right");
                break;
        }
        switch (PlayerPrefs.GetInt("player2Character"))
        {
            case 0:
                player2 = Instantiate(serpentsortia2, spawnPoint2.position, Quaternion.identity);
                instantiatedPlayer2 = player2.GetComponentInChildren<PlayerController2>();
                abilityFlag2[1].sprite = serpent;
                break;
            case 1:
                player2 = Instantiate(bigpapa2, spawnPoint2.position, Quaternion.identity);
                instantiatedPlayer2 = player2.GetComponentInChildren<PlayerController2>();
                abilityFlag2[1].sprite = bigpapa;
                break;
            case 2:
                player2 = Instantiate(bomb2, spawnPoint2.position, Quaternion.identity);
                instantiatedPlayer2 = player2.GetComponentInChildren<PlayerController2>();
                abilityFlag2[1].sprite = bomb;
                break;
            default:
                Debug.LogWarning("PlayerPrefs aren't right");
                break;
        }
        instantiatedPlayer1.timeSlow = tsmFlag1;
        instantiatedPlayer1.abilityFlags = new[] { abilityFlag1[0].gameObject, abilityFlag1[1].gameObject };
        instantiatedPlayer1.tsm = tsm;
        instantiatedPlayer1.elemental = elementals1[PlayerPrefs.GetInt("player1Element", 0)];
        instantiatedPlayer1.gameObject.GetComponentInChildren<ElementalManager>().target =
            instantiatedPlayer2.gameObject.transform.GetChild(0).gameObject;
        abilityFlag1[0].sprite = elements[PlayerPrefs.GetInt("player1Element")];
        player1.GetComponentInChildren<ElementalManager>().target = player2.transform.GetChild(0).gameObject;

        instantiatedPlayer2.timeSlow = tsmFlag2;
        instantiatedPlayer2.abilityFlags = new[] { abilityFlag2[0].gameObject, abilityFlag2[1].gameObject };
        instantiatedPlayer2.tsm = tsm;
        instantiatedPlayer2.elemental = elementals2[PlayerPrefs.GetInt("player2Element", 0)];
        instantiatedPlayer2.gameObject.GetComponentInChildren<ElementalManager>().target =
            instantiatedPlayer1.gameObject.transform.GetChild(0).gameObject;
        abilityFlag2[0].sprite = elements[PlayerPrefs.GetInt("player2Element")];
        player2.GetComponentInChildren<ElementalManager>().target = player1.transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        tsmFlag1.GetComponentInChildren<TextMeshProUGUI>().text = $"Score: {PlayerPrefs.GetInt("player1Score", 0)}";
        tsmFlag2.GetComponentInChildren<TextMeshProUGUI>().text = $"Score: {PlayerPrefs.GetInt("player2Score", 0)}";
    }

    private void Update()
    {
        Debug.Log(elements[PlayerPrefs.GetInt("player1Element")]);
    }
}
