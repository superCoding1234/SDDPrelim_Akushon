using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Sprite[] characters;
    [SerializeField] private Sprite[] elements;
    private int characterCounter;
    private int elementCounter;
    private Image im;

    public void CycleForwardCharacter(GameObject image)
    {
        im = image.GetComponent<Image>();
        im.sprite = characters[Mod(++characterCounter, 3)];
    }

    public void CycleBackwardCharacter(GameObject image)
    {
        im = image.GetComponent<Image>();
        im.sprite = characters[Mod(--characterCounter, 3)];
    }

    private int Mod(int x, int y)
    {
        return (x % y + y) % y;
    }
}