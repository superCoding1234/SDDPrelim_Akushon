using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Sprite[] characters;
    [SerializeField] private Sprite[] elements;
    private int characterCounter;
    private int elementCounter;

    public void CycleForwardCharacter(GameObject image)
    {
        image.GetComponent<Image>().sprite = characters[Mod(++characterCounter, 3)];
    }

    public void CycleBackwardCharacter(GameObject image)
    {
        image.GetComponent<Image>().sprite = characters[Mod(--characterCounter, 3)];
    }

    public void CycleForwardElement(GameObject image)
    {
        image.GetComponent<Image>().sprite = elements[Mod(++elementCounter, 3)];
    }
    
    public void CycleBackwardElement(GameObject image)
    {
        image.GetComponent<Image>().sprite = elements[Mod(--elementCounter, 3)];
    }

    public void LockInPlayer(int player)
    {
        switch (player)
        {
            case 1:
                PlayerPrefs.SetInt("player1Character", Mod(characterCounter, 3));
                break;
            case 2:
                PlayerPrefs.SetInt("player2Character", Mod(characterCounter, 3));
                break;
            default:
                Debug.LogWarning($"Parameter for LockInPlayer for Player{player} is not valid!");
                break;
        }
        PlayerPrefs.SetInt($"player{player}Element", elementCounter);
        switch (PlayerPrefs.GetInt($"player{player}Character"))
        {
            case 0:
                FindFirstObjectByType<AudioManager>().Play("ViperSuper");
                break;
            case 1:
                FindFirstObjectByType<AudioManager>().Play("SovaSuper");
                break;
            case 2:
                FindFirstObjectByType<AudioManager>(). Play("GeckoSuper");
                break;
            default:
                Debug.LogError("FATAL: _player1Character value is NOT valid somehow!");
                break;
        }
    }

    private int Mod(int x, int y)
    {
        return (x % y + y) % y;
    }
}