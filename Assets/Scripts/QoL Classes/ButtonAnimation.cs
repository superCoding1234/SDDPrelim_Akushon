using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite buttonDown, buttonUp;
    [SerializeField] private RectTransform content;

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = buttonDown;
        content.position += Vector3.down * 4;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = buttonUp;
        content.position += Vector3.up * 4;
    }
}