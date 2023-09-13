using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private ToggleAnimation button1, button2;
    private Color inactiveColor;
    [SerializeField] private TextMeshProUGUI text;
    private Image im;
    private Button button;
    private ButtonAnimation ba;

    private void Start()
    {
        im = GetComponent<Image>();
        button = GetComponent<Button>();
        ba = GetComponent<ButtonAnimation>();
        inactiveColor = im.color;
    }

    private void Update()
    {
        if (button1.buttonState && button2.buttonState)
        {
            ba.enabled = true;
            button.interactable = true;
            im.color = Color.white;
            text.color = Color.white;
        }
        else
        {
            ba.enabled = false;
            button.interactable = false;
            im.color = inactiveColor;
            text.color = inactiveColor;
        }
    }
}