using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private Color fadeOutColour;

    [SerializeField] private TextMeshProUGUI text;

    public void FadeOutAll()
    {
        GetComponent<Image>().color = fadeOutColour;
        text.color = fadeOutColour;
        text.gameObject.GetComponent<RectTransform>().position += Vector3.down * 4;
    }
}