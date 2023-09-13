using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private Color fadeOutColour;
    [SerializeField] private TextMeshProUGUI text;

    private void Update()
    {
        if (GetComponent<ToggleAnimation>().buttonState)
        {
            GetComponent<Image>().color = fadeOutColour;
            text.color = fadeOutColour;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
            text.color = Color.white;
        }
    }
}